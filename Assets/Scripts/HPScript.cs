using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HPScript : MonoBehaviour
{
    [SerializeField] private int hpSlot; //what heart is this? first one second third etc.
    private Image m_Image;
    [SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartEmpty;
    [SerializeField] private bool isFull;
    private int playerHp;

    void Start()
    {
        m_Image = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        playerHp = PlayerInfo.Instance.GetCurrentHealth();
        if (playerHp < hpSlot && isFull == true)
        {
            isFull = false;
            m_Image.sprite = heartEmpty;
        }
        else if (playerHp >= hpSlot && isFull == false)
        {
            isFull = true;
            m_Image.sprite = heartFull;
        }
    }
}
