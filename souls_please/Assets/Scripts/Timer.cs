using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float duration = 300f;
    private float currentTime = 0f;
    void Start()
    {
        currentTime = duration;
    }
    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            timerText.text = Mathf.Floor(currentTime).ToString("00");
        }
    }
}
