using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool _onGround = false;
    // Start is called before the first frame update
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
