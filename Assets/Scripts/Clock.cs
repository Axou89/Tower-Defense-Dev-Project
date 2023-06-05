using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Clock : MonoBehaviour
{
    public Text ClockText;
    public float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        if (minutes == 7)
        {
            // Time over
        }
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        ClockText.text = timerString;
    }

}
