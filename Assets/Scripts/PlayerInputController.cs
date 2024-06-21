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
        PlayerInputs playerInputs = new PlayerInputs();
        if (playerInputs != null)
        {
            playerInputs.Player.Jump.performed += (val) => playerController.HandleJump();
            playerInputs.Player.Jump.canceled += (val) => playerController.JumpReleased();
            playerInputs.Player.Move.performed += (val) => playerController.Move(val.ReadValue<Vector2>());
        }
        playerInputs.Enable();

    }
}

