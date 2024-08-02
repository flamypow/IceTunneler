using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : BaseEnemy
{
    public bool shouldMove = true;
    [Header("Move")]
    [SerializeField] private GameObject[] waypoints;
    private int currentDestinationNum = 0;
    [SerializeField] private int numChange = 1;
    private Transform currentDestination;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float movePrecision = 0.4f;
    [Header("Idle")]
    private bool idling = false;
    [SerializeField] private float idleDuration;
    private float idleTimer;
    [Header("Attack")]
    private bool seePlayer = false;
    private bool attacking = false;
    [SerializeField] private EnemySight enemySight;
    [Header("Perish")]
    private bool hasDied = false;

    private void Update()
    {
        if (hasDied == false)
        {
            if (waypoints.Length != 0)
            {
                SeeAndAttack();
                if (shouldMove)
                {
                    MoveAndIdle();
                }
            }
        }

        
    }

    void SeeAndAttack()
    {
        seePlayer = enemySight.getSeePlayer();
        if (seePlayer)
        {
            shouldMove = false;
            enemyAnimator.SetBool("IsAttacking", true);
        }
    }

    void FinishAttacking()
    {
        enemyAnimator.SetBool("IsAttacking", false);
    }

    void MoveAndIdle()
    {
        if (!idling)
        {
            enemyAnimator.SetBool("IsWalking", true);
            if (currentDestination == null)
            {
                currentDestination = waypoints[0].transform;
            }
            if (currentDestination.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            transform.position = Vector2.MoveTowards(transform.position, currentDestination.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, currentDestination.position) < movePrecision)
            {
                idling = true;
                idleTimer = idleDuration;
                if (currentDestinationNum == waypoints.Length - 1)
                {
                    numChange = -1;
                }
                else if (currentDestinationNum == 0)
                {
                    numChange = 1;
                }
                currentDestinationNum += numChange;
                currentDestination = waypoints[currentDestinationNum].transform;
            }
        }else
        {
            enemyAnimator.SetBool("IsWalking", false);
            idleTimer -= Time.deltaTime;
            if (idleTimer < 0f)
            {
                idling = false;
            }
        }
    }

    public void AllowedToMove()
    {
        shouldMove = true;
    }

    public override void TakeDamage()
    {
        currentHealth--;
        if (currentHealth == 0)
        {
            Perish();
        }
        else
        {
            shouldMove = false;
            //play animation
            enemyAnimator.Play("Base Layer.Skeleton_TakeHit");
        }
    }

    public override void Perish()
    {
        shouldMove = false;
        //play animation
        enemyAnimator.Play("Base Layer.Skeleton_Die");
        //disable colliders
        enemyCollider.enabled = false;
        hasDied = true;
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        //if block, perish
        if (collider.gameObject.layer == 7)
        {
            Perish();
        }

        //if player attack, take damage
        if (collider.gameObject.layer == 6) //I'll switch this to enum later
        {
            TakeDamage();
        }

        //if player body, hit player
        if (collider.gameObject.layer == 8)
        {
            GameManager.Instance.PlayerTakeHit(attackStrength, this.transform, knockbackStrength);
        }
    }

}
