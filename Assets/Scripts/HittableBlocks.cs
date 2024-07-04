using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBlocks : MonoBehaviour
{
    [SerializeField] private bool affectedByGravity;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.layer == 6)
        {
            if (transform.position.x < PlayerController.Instance.transform.position.x)
            {

                //Debug.Log("Player Right of block");
                rb2D.bodyType = RigidbodyType2D.Dynamic;
                rb2D.AddForce(transform.right * -1000f);
            }
            else
            {
                //Debug.Log("Player Left of block");
                rb2D.bodyType = RigidbodyType2D.Dynamic;
                rb2D.AddForce(transform.right * 1000f);
            }
        }

    }
}
