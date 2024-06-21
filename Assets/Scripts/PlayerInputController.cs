using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    #region Serializable Fields

    #endregion
    #region Private Variables
    PlayerController playerController;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    void OnEnable()
    {
        PlayerInputs, player.Move = new player.Jump();
        if (playerInputs != null)
        {
            playerInputs.PlayerActions.Jump.performed += (val) => playerController.HandleJump();
            playerInputs.PlayerActions.Jump.canceled += (val) => playerController.JumpReleased();
            playerInputs.PlayerMovement.Move.performed += (val) => playerController.Move(val.ReadValue<Vector2>());
        }
        playerInputs.Enable();

    }
}

