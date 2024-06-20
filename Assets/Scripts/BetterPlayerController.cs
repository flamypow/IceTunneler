using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerController : MonoBehaviour
{
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2.0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }

    protected override void FixedUpdate()
    {

        // If you are falling
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

        rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
    }
}
