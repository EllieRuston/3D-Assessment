using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeValue = 90f;
    public Text timeText;
    [SerializeField] GameObject player;
    [SerializeField] public float bonusTime = 30f;
    public float timeToDisplay;


    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }


        // create minutes (rounded down)
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        // shows remainders
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


     void onTrigger(Collision collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {   
            timeValue =+ bonusTime;
        }
    }
}
