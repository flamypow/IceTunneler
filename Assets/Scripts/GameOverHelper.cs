using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHelper : MonoBehaviour
{
    private int currentStageIndex;

    private void OnEnable()
    {
        currentStageIndex = GameManager.Instance.GetStageIndex();
    }

    public void RestartFromCheckpoint()
    {
        //need to be built later.
        GameManager.Instance.LoadLevel(currentStageIndex);
    }
    
    public void RestartLevel()
    {
        GameManager.Instance.LoadLevel(currentStageIndex);
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
