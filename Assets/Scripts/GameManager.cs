using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton <GameManager>
{
    //pause menu 
    [SerializeField] GameObject pauseMenu;
    public bool gamePaused = false;

    public void PauseUnpause()
    {
        gamePaused = !gamePaused;
        pauseMenu?.SetActive(gamePaused);
    }

    void Update()
    {        
        Time.timeScale = gamePaused ? 0.0f : 1.0f;   
    }

    public void PlayerTakeHit(int amount, Transform source)
    {
        if (source.position.x > PlayerController.Instance.transform.position.x)
        {
            Debug.Log("Skeleton x"+ source.position.x);
            Debug.Log("Player x" + PlayerController.Instance.transform.position.x);
            Debug.Log("attacked from right");
            PlayerController.Instance.OnTakingHit(false);
        }
        else
        {
            Debug.Log("Skeleton x" + source.position.x);
            Debug.Log("Player x" + PlayerController.Instance.transform.position.x);
            Debug.Log("attacked from left");
            PlayerController.Instance.OnTakingHit(true);
        }
        PlayerInfo.Instance.playerTakeDamage(amount);
    }

    public void StopPlayerMovement()
    {
        PlayerController.Instance.SetPlayerCanMove(false);
    }

    public void LoadLevel(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
