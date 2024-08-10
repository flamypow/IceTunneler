using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    void FixedUpdate()
    {
        textMeshPro.text = "Health: " + PlayerInfo.Instance.GetCurrentHealth();
    }
}
