using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : BaseEnemy
{
    
    public override void TakeDamage()
    {
        currentHealth--;
        if (currentHealth == 0)
        {
            Perish();
        }
        else
        {
            //play animation
            enemyAnimator.Play("Base Layer.Skeleton_TakeHit");
        }
    }

    public override void Perish()
    {
        //play animation
        enemyAnimator.Play("Base Layer.Skeleton_Die");
        //disable colliders
        enemyCollider.enabled = false;
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        //if block, perish
        if (collider.gameObject.layer == 7)
        {
            Perish();
        }

        //if player attack, take damage
        if (collider.gameObject.layer == 6) //I'll need to switch this to enum later
        {
            TakeDamage();
        }

        //if player body, hit player
        if (collider.gameObject.layer == 8)
        {
            GameManager.Instance.PlayerTakeHit(attackStrength, this.transform);
        }
    }

}
