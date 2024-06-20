using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{

    #region Serializable Fields
    [Header("Jump")]
    [SerializeField] private float jumpVelocity = 5.0f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2.0f;
    [SerializeField] private GroundCheck groundCheck;
    //coyoteTimeVariables
    [SerializeField] private float coyoteTime = 0.3f;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 50.0f;
    #endregion

    #region Private Variables
    private Rigidbody2D rb;
    private bool isJumping = false;
    private Vector2 movementVector;

    //coyoteTimeVariables
    private float _lastGroundedTime;
    private float _lastJumpTime;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnJump()
    {
        if (!isJumping && (groundCheck.IsGrounded() || IsInCoyoteTime()))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isJumping = true;
        }
    }

    public void JumpReleased()
    {
        isJumping = false;
    }


    public void OnMove(float movement)
    {
        this.movementVector.x = movement;
    }

    protected void FixedUpdate()
    {
        //coyote time implementation
        if (groundCheck.IsGrounded())
        { 
            _lastGroundedTime = Time.time;
        } 

        if (rb.velocity.y < 0)
        {
            //add more to the existing y velocity
            rb.velocity += Vector2.up * (Physics2D.gravity.y * Time.fixedDeltaTime * fallMultiplier);
        }
        // If you are going up, but not holding the jump button
        else if (rb.velocity.y > 0 && !isJumping)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * Time.fixedDeltaTime * lowJumpMultiplier);
        }

        rb.velocity = new Vector2(movementVector.x * moveSpeed, rb.velocity.y);
    }

    private bool IsInCoyoteTime()
    {
        return (Time.time - _lastGroundedTime) <= coyoteTime;
    }
}
