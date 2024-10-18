using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject settingPanel;
    public static bool isPaused = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
            isPaused = !settingPanel.activeSelf;
            PauseGame();
        }
    }

    void PauseGame() 
    {
        if (settingPanel.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
