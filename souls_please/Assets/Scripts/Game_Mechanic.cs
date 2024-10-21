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
    public static float currentTime = 0f;

    public static bool completedQuota = false;
    public static bool startGame = false;

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
        //Find all the soul in a scene
        //soulNumb = GameObject.FindGameObjectsWithTag("Souls");
        
        if (!completedQuota && currentTime > 0 && startGame)
        {
            TimerStart();
        }

        if (dayNumber > 5)
        {
            EndGame();
        }
    }

    /*void InstantiateSouls()
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
    }*/
    public void TimerStart()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            timerText.text = Mathf.Floor(currentTime).ToString("00");
        }
    }

    public void NewDay()
    {
        //Instantiate Souls in Newday
        // InstantiateSouls();      
        uiManagerScript.dayText.text = ("Day" + dayNumber);
        dayNumber++;
        completedQuota = false;
        currentQuota = startQuota + dayQuota*(dayNumber-1);
    }

    public void EndGame()
    {

    }
}
