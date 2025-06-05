using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Button pauseButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.instance.fpsMode) { return; }
        if (Input.GetKeyDown("escape")) 
        {
            pauseButton.onClick.Invoke();
            Cursor.lockState = CursorLockMode.None;

        }
    }

    public void HandlePauseButton() 
    {
        Time.timeScale = 0f;
    }
    public void HandleResumeButton() 
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
