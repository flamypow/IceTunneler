using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public bool seePlayer = false;

    public void OnTriggerStay2D(Collider2D collider)
    {
        //if player body, hit player
        if (collider.gameObject.layer == 8)
        {
            seePlayer = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8)
        {
            seePlayer = false;
        }
    }

    public bool getSeePlayer()
    {
        return seePlayer;
    }
}
