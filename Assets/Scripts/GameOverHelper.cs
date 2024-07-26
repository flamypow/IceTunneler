using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHelper : MonoBehaviour
{
    private int currentStageIndex;
    [SerializeField] private int checkpointID;

    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        currentStageIndex = GameManager.Instance.GetStageIndex();
        checkpointID = GameManager.Instance.GetCheckpointID();
    }

    public int getCheckpoint()
    {
        return checkpointID;
    }

    public void RestartFromCheckpoint()
    {
        GameManager.Instance.LoadLevel(currentStageIndex);
    }
    
    public void RestartLevel()
    {
        GameManager.Instance.LoadLevel(currentStageIndex);
        Destroy(this.gameObject);
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
