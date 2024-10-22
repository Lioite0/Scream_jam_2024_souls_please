using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Mechanic : MonoBehaviour
{
    //Assign day and quota perday
    [Header("GameValues")]
    public int startQuota=15;
    public int dayQuota = 10;
    public static int currentQuota;
    private int dayNumber = 1;

    //Assign Timer
    public TMP_Text timerText;
    private float duration = 300f;
    public static float currentTime = 0f;

    public static bool completedQuota = false;
    public static bool startGame = false;

    private UI_Manager uiManagerScript;

    [Header("GameObjects")]
    public GameObject[] soulPref;
    public Transform spawnPoint;
    public Transform destinationPoint;
    private GameObject[] soulNumb;


    private Vector3 spacing = new Vector3(0.5f, 0f, 0f);

    private void Start()
    {
        currentQuota = startQuota;
        currentTime = duration;
        uiManagerScript = GetComponent<UI_Manager>();
    }

    private void Update()
    {
        //Find all the soul in a scene
        soulNumb = GameObject.FindGameObjectsWithTag("Souls");

        if (soulNumb.Length == 0 && !completedQuota && startGame)
        {
            NewDay();
        }
        if (!completedQuota && currentTime > 0 && startGame)
        {
            TimerStart();
        }

        if (dayNumber > 5)
        {
            EndGame();
        }
    }

    public void TimerStart()
    {

         currentTime -= Time.deltaTime;
         timerText.text = Mathf.Floor(currentTime).ToString("00");
    }

    public void NewDay()
    {
        //Instantiate Souls in Newday
            for (int i = 0; i < currentQuota; i++)
            {
                int randomIndex = Random.Range(0, soulPref.Length);
                Vector3 pos = spawnPoint.position + i * spacing;
                Instantiate(soulPref[randomIndex], pos, Quaternion.identity);
            }
        uiManagerScript.dayText.text = ("Day" + dayNumber);
        dayNumber++;
        completedQuota = false;
        currentQuota = startQuota + dayQuota*(dayNumber-1);
    }

    public void EndGame()
    {

    }
}
