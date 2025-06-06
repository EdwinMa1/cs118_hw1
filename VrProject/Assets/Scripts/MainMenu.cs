using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleStartButton() 
    {
        SceneManager.LoadScene("assignment_5_game_scene 1");
    }

    public void HandleQuitButton() 
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
