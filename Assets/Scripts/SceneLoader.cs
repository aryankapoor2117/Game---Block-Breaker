using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //[SerializeField] AudioClip backgroundMusic;

    public void LoadNextScene()
    {
       // AudioSource.PlayClipAtPoint(backgroundMusic, Camera.main.transform.position);
        int currentSceneIndex= SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadStartScene()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(0);
        
    }
    public void LoadStartSceneAfterVictory()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(0);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
