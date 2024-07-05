using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBlocks : MonoBehaviour
{
    [SerializeField] private bool affectedByGravity;
    private Rigidbody2D rb2D;
    [SerializeField] private bool _beingHit = false;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        _beingHit = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.layer == 6)
        {
            _beingHit = true;
            if (transform.position.x < PlayerController.Instance.transform.position.x)
            {

                //Debug.Log("Player Right of block");
                rb2D.bodyType = RigidbodyType2D.Dynamic;
                rb2D.AddForce(transform.right * -1000f);
                StartCoroutine(NoLongerBeingHit());
            }
            else
            {
                //Debug.Log("Player Left of block");
                rb2D.bodyType = RigidbodyType2D.Dynamic;
                rb2D.AddForce(transform.right * 1000f);
                StartCoroutine(NoLongerBeingHit());
            }
        }

    }

    IEnumerator NoLongerBeingHit()
    {
        yield return new WaitForSeconds(1.0f);
        _beingHit = false;
    }

        private void FixedUpdate()
    {
        if (!_beingHit)
        { 
            if (Mathf.Abs(rb2D.velocity.x) < 0.01f)
            {
                rb2D.bodyType = RigidbodyType2D.Static;
            }
        }
    }

    
}
