using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    public void canMoveAgain()
    {
        PlayerController.Instance.SetPlayerCanMove(true);
    }
}
