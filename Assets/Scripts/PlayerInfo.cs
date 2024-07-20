using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : Singleton <PlayerInfo>
{
    [SerializeField] private int playerStartHealth;
    private int playerCurrentHealth;


    void Start()
    {
        playerCurrentHealth = playerStartHealth;
    }

    public void PlayerTakeDamage(int damageAmount)
    {
        playerCurrentHealth -= damageAmount;
        Debug.Log(playerCurrentHealth);
        if (playerCurrentHealth <= 0)
        {
            playerCurrentHealth = playerStartHealth;
            GameManager.Instance.LoadGameOver();
        }
    }

    public void PlayerGainHealth(int healAmount)
    {
        playerCurrentHealth += healAmount;
    }

    public void PlayerSetHealth(int setTo)
    {
        playerCurrentHealth = setTo;
    }

    public void PlayerSetFullHealth()
    {
        playerCurrentHealth = playerStartHealth;
    }

    public int GetCurrentHealth()
    {
        return playerCurrentHealth;
    }
}
