using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Serializable Fields
    [Header("Jump")]
    [SerializeField]
    protected float jumpVelocity = 5.0f;
    [Header("Movement")]
    [SerializeField]
    protected float speed = 50.0f;

    #endregion
    #region Private Variables
    protected Rigidbody2D rb;
    protected GroundCheck groundCheck;
    protected bool isJumping = false;
    protected bool isGrounded = false;
    protected Vector2 movementVector;


    #endregion


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }
    public virtual void HandleJump()
    {
        Debug.Log("Jump");

        if (!isJumping && (groundCheck.IsGrounded))

        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isJumping = true;
        }

    }
    public virtual void JumpReleased()
    {
        isJumping = false;
    }
    public virtual void Move(Vector2 movement)
    {
        this.movementVector.x = movement.x;
    }
    public virtual void AttachToParent(Transform newParent)
    {
        this.transform.parent = newParent;
    }
    void Start()
    {

    }

    protected virtual void FixedUpdate()
    {
        rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
    }
}
