using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int startingHealth;
    protected int currentHealth;

    [SerializeField] protected Animator enemyAnimator;
    [SerializeField] protected Collider2D enemyCollider; //Just in case I want multiple later

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public virtual void TakeDamage()
    { }

    public virtual void Perish()
    { }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    { }

}
