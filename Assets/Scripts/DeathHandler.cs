using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    void Start() 
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;    //stop time (it s not start again)
        Cursor.lockState = CursorLockMode.None;     //we have lock state and we want the cursor lock mode to be of a value of none
        Cursor.visible = true;     //unlock the cursor
    }
}