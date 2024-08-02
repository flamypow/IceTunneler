using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.Instance.LoadGameEnd();
    }
}
