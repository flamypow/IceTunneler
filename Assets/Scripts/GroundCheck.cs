using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool _onGround = false;
    //This is a simpler version of ground check, it uses a collider2D and just check for triggers.
    public bool IsGrounded()
    {
        return _onGround;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        _onGround = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _onGround = false;
    }

}
