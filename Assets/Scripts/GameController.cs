using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public const string SHAKE_HORIZIONTAL = "SHAKELEFT";
    public const string SHAKE_VERTICAL = "SHAKEVERTICAL";
    public float cash;
    public int startHour;
    public Text cashText;
    public Text timeText;
    public float secondLength;
    public bool isPaused = false;
    public GameObject pauseMenu;
    AudioSource audioSource;
    float totalSlots = 0;
    System.DateTime timeObject; 
    System.DateTime endTime;
    float colorBonus;
    float soundBonus;
 
    void Start()
    {
        StartCoroutine("StartTime");
        timeObject = new System.DateTime(1, 1, 1, startHour, 0, 0);
        System.TimeSpan oneDay = System.TimeSpan.FromDays(1);
        endTime = timeObject.Add(oneDay);
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
       if(Input.GetButtonDown("Cancel")){
           if(isPaused){
                UnPause();
           }
           else{
                Pause();
           }
       }
       if(timeObject > endTime){
           Debug.Log("end");
       }
       cashText.text = "$" + cash.ToString(); 
       timeText.text = timeObject.ToString(@"hh\:mm tt");
    }

    public void AdjustCash(float amount){
       cash += amount; 
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void UnPause(){
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UnPause();
    }

    public void Quit(){
        Application.Quit();
    }

    public void Resume(){
        isPaused = false;
        Time.timeScale = 1.0f;
        UnPause(); 
    }

    public float CalculatePayout(float input, float soundCode, float colorCode){
        float threshold = 60;
        float payout = 0;
        if(soundCode == soundBonus){
            threshold -= 10;
        }
        if(colorCode == colorBonus){
            threshold -= 10;
        }
        float spin = Random.Range(1, 100);
        Debug.Log(spin);
        Debug.Log(threshold);
        if(spin > threshold){
             payout = input * 2f + (spin - threshold); 
        }
        Debug.Log(payout);
        return payout;
    }

    public 

    IEnumerator StartTime(){
       System.TimeSpan oneMinute = System.TimeSpan.FromMinutes(1);
       while(true){
           timeObject = timeObject.Add(oneMinute);  
           yield return new WaitForSeconds(secondLength);
       } 
    }
}
