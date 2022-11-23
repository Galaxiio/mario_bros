using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeValue = 900; // 15 minutes
    public TextMeshProUGUI timerText;


    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
            timeValue -= Time.deltaTime;
        else
            timeValue = 0;

        DisplayTime(timeValue);
    }

    //Ne d�passe 60
    void DisplayTime (float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = "Time : " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
