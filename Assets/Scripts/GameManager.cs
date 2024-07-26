using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton <GameManager>
{
    //pause menu 
    [SerializeField] GameObject pauseMenu;
    public bool gamePaused = false;
    private int currentStageIndex;
    private Transform currentCheckpoint;
    private int currentCheckpointID;
    [SerializeField] Transform playerStartingPosition;
    [SerializeField] Transform playerTransform;

    public void PauseUnpause()
    {
        gamePaused = !gamePaused;
        pauseMenu?.SetActive(gamePaused);
    }

    void Start()
    {
        currentStageIndex = SceneManager.GetActiveScene().buildIndex;
        GameOverHelper helper = FindAnyObjectByType<GameOverHelper>();
        if (helper != null) //helper stores info on checkpoint
        {
            int i = helper.getCheckpoint();
            currentCheckpoint = LevelInfo.Instance.GetCheckpoint(i);
        }
        if (currentCheckpoint == null)
        {
            currentCheckpoint = playerStartingPosition;
        }
        playerTransform.position = currentCheckpoint.position;
        Destroy(helper);
    }

    void Update()
    {        
        Time.timeScale = gamePaused ? 0.0f : 1.0f;   
    }

    public void PlayerTakeHit(int amount, Transform source, float knockbackStrength)
    {
        if (source.position.x > PlayerController.Instance.transform.position.x)
        {
            PlayerController.Instance.OnTakingHit(false, knockbackStrength);
        }
        else
        {
            PlayerController.Instance.OnTakingHit(true, knockbackStrength);
        }
        PlayerInfo.Instance.PlayerTakeDamage(amount);
    }

    public void PlayerHealToFull()
    {
        PlayerInfo.Instance.PlayerSetFullHealth();
    }

    public void StopPlayerMovement()
    {
        PlayerController.Instance.SetPlayerCanMove(false);
    }

    public int GetStageIndex()
    {
        return currentStageIndex;
    }

    public void LoadLevel(int sceneNum)
    {
        currentStageIndex = sceneNum;
        SceneManager.LoadScene(sceneNum);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void ResetCheckpoint()
    {
        currentCheckpoint = playerStartingPosition;
    }

    public int GetCheckpointID()
    {
        return currentCheckpointID;
    }

    public void SetCheckpointID(int index)
    {
        currentCheckpointID = index;
    }

}
