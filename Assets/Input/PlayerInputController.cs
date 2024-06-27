using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    void OnEnable()
    {
        PlayerInput playerI = new PlayerInput();
        if (playerI != null)
        {
            //add in attack here once I am ready.
            playerI.PlayerAvatar.Jump.performed += (val) => PlayerController.Instance.OnJump();
            playerI.PlayerAvatar.Jump.canceled += (val) => PlayerController.Instance.JumpReleased();
            playerI.PlayerAvatar.LRMovement.performed += (val) => PlayerController.Instance.OnMove(val.ReadValue<float>());
            playerI.PlayerAvatar.Attack.performed += (val) => PlayerController.Instance.OnAttack();
        }
        playerI.Enable();
    }
}
