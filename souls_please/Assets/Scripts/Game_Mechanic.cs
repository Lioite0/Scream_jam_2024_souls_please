using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Mechanic : MonoBehaviour
{
    //Assign day and quota perday
    public int startQuota=15;
    public int dayQuota = 10;
    private int currentQuota;
    private int dayNumber = 1;

    //Assign Timer
    public TMP_Text timerText;
    private float duration = 300f;
    private float currentTime = 0f;

    public static bool completedQuota = false;

    private UI_Manager uiManagerScript;

    public GameObject soulPref;
    private GameObject[] soulNumb;
    private float spacing;

    private void Start()
    {
        currentQuota = startQuota;
        currentTime = duration;
        uiManagerScript = GetComponent<UI_Manager>();
    }

    private void Update()
    {
        InstantiateSouls();
        TimerStart();
        //Find all the soul in a scene
        soulNumb = GameObject.FindGameObjectsWithTag("Souls");
    }

    void InstantiateSouls()
    {
        //Instantiate Souls 
        for (int i = 0; i < currentQuota; i++)
        {
            if (soulNumb.Length < 10)
            {
                Vector3 position = new Vector3(i * spacing, 0, 0);
                GameObject instantiateSoul = Instantiate(soulPref, position, Quaternion.identity);
            }
        }
    }
    void TimerStart()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            timerText.text = Mathf.Floor(currentTime).ToString("00");
        }
    }

    public void NewDay()
    {
        uiManagerScript.resultPanel.SetActive(true);
        DOVirtual.DelayedCall(1f, () =>
        {
            uiManagerScript.resultPanel.SetActive(false);
        }
            );
        uiManagerScript.dayText.text = ("Day" + dayNumber);
        dayNumber++;
        completedQuota = false;
        currentQuota = startQuota + dayQuota*(dayNumber-1);
    }
}