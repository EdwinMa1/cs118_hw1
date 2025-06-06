using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class UI : MonoBehaviour
{
    public Button pauseButton;
    public TMP_Text ratKillCountDisplay;
    public int ratKillNumber = 0;
    public static UI instance;

    void Awake() 
    {
        instance = this;
    }

    public void UpdateRatCounterText() 
    {
        ratKillCountDisplay.text = "Rats Killed: " + ratKillNumber;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateRatCounterText();
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

    public void BackToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
