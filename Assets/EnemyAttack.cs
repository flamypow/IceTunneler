using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int attackStrength;
    [SerializeField] private float knockbackStrength;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        //if player body, hit player
        if (collider.gameObject.layer == 8)
        {
            GameManager.Instance.PlayerTakeHit(attackStrength, this.transform, knockbackStrength);
        }
    }
}
