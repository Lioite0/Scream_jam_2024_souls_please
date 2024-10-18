using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingPanel;
    public GameObject resultPanel;

    [Header("Text")]
    public TMP_Text dayText;


    [Header("Buttons")]
    public Button newDaybtn;

    public static bool isPaused = true;
    private Game_Mechanic gameMechanicScript;

    void Start()
    {
        gameMechanicScript = GetComponent<Game_Mechanic>();
        newDaybtn.onClick.AddListener(gameMechanicScript.NewDay);
    }
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
