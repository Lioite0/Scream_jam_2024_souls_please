using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject settingPanel;
    public GameObject resultPanel;
    public GameObject startPanel;
    public GameObject sheet;
    public Camera mainCam;

    [Header("Text")]
    public TMP_Text dayText;
    public TMP_Text quotaText;

    [Header("Buttons")]
    public Button newDayBtn;
    public Button startBtn;

    public static bool isPaused = true;
    private Game_Mechanic gameMechanicScript;
    private bool isZoomed = false;
    private Vector3 originalPos;
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == sheet)
            {
                if (isZoomed)
                {
                    sheet.transform.SetParent(null);
                    sheet.transform.rotation = Quaternion.Euler(0, 180, 0);
                    sheet.transform.position = new Vector3(-0.588f, 1.03f, -8.75f);
                }
                else
                {
                    sheet.transform.SetParent(mainCam.transform);
                    sheet.transform.rotation = Quaternion.Euler(60, 180, 15);
                }
                isZoomed = !isZoomed;
            }
        }
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
