using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()    //at play again button' on click list' reloadGame added, because of why again button is reload the game:))
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;     //when press the again button, play the game again
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
