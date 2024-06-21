using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    bool showDebug = false;
    public bool IsGrounded { get; private set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = CheckGrounded();
    }

    bool CheckGrounded()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        #region First Method
        // 
        // float extraHeight = .05f;
        // RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeight,  LayerMask.GetMask("Ground"));
        // Color rayColor;
        // if(raycastHit.collider)
        // {
        // 	rayColor = Color.red;
        // }
        // else
        // 	rayColor = Color.green;
        // Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        // return raycastHit.collider != null;
        #endregion
        #region Second Method
        float extraHeight = .05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeight, LayerMask.GetMask("Ground"));
        if (showDebug)
        {
            Color rayColor;
            if (raycastHit.collider)
            {
                rayColor = Color.red;
            }
            else
                rayColor = Color.green;
            //Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * extraHeight, rayColor);
            //Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
            Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, boxCollider2D.bounds.extents.y + extraHeight), Vector2.right * 2f * (boxCollider2D.bounds.extents.x), rayColor);
            Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, boxCollider2D.bounds.extents.y - extraHeight), Vector2.right * 2f * (boxCollider2D.bounds.extents.x), rayColor);
        }

        return raycastHit.collider != null;
        #endregion
        //return false;
    }
}
