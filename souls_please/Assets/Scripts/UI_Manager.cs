using DG.Tweening;
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
    public GameObject startPanel;

    [Header("Text")]
    public TMP_Text dayText;
    public TMP_Text quotaText;

    [Header("Buttons")]
    public Button newDayBtn;
    public Button startBtn;

    public static bool isPaused = true;
    private Game_Mechanic gameMechanicScript;

    void Start()
    {
        NextDayPanelAppear();
        resultPanel.SetActive(true);
        gameMechanicScript = GetComponent<Game_Mechanic>();
        //newDayBtn.onClick.AddListener(gameMechanicScript.NewDay);
        startBtn.onClick.AddListener(StartGame);
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
            isPaused = !settingPanel.activeSelf;
            PauseGame();
        }
        if (resultPanel.activeSelf)
        {
            DOVirtual.DelayedCall(2f, () =>
            {
                resultPanel.SetActive(false);
            }
        );
        }
        quotaText.text = Game_Mechanic.currentQuota.ToString();
    }

    void StartGame()
    {
        Game_Mechanic.startGame = true;
        Destroy(startPanel);
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

    public void NextDayPanelAppear()
    {
    }


}
