using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public Text timeText;

   
   ///Cell Door set up 
    public Animator Cell1;
    public Animator Cell2;
    public Animator Cell3;
    public Animator Cell4;
    public Animator Cell5;
   

    //Food stuff
    public GameObject Chow;

    void Start()
    {
        timerIsRunning = true;

        //Triggering Cell Doors to open + sound
        
        Cell1.SetBool("DoorLock", false);
        Cell2.SetBool("DoorLock", false);
        Cell3.SetBool("DoorLock", false);
        Cell4.SetBool("DoorLock", false);
        Cell5.SetBool("DoorLock", false);
        
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }
    void Update()
    {
        

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        
            if (timeRemaining == 1199)
            
                Chow.SetActive(true);
        }
        else
        {
            Debug.Log("Day is over, cells are locking...");
            timeRemaining = 0;
            timerIsRunning = false;

                
            Cell1.SetBool("DoorLock", true);
            Cell2.SetBool("DoorLock", true);
            Cell3.SetBool("DoorLock", true);
            Cell4.SetBool("DoorLock", true);
            Cell5.SetBool("DoorLock", true);

  

            SceneManager.LoadScene("NightyNight");

        }
    }
}
