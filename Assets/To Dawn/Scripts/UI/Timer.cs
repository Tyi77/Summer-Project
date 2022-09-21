using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    public float timer;
    
    private float minutes = 0;
    private float seconds = 0;
    private string minutesText = "00";
    private string secondsText = "00";

    private Reborn reborn;

    private void Awake() {
        timerText = GetComponent<Text>();
        reborn = GameObject.FindWithTag("Player").GetComponent<Reborn>();
    }

    private void OnEnable() {
        reborn.rebornEvent += Restart;
    }

    private void Restart(){
        timer = 0f;
    }

    private void Update() {
        timer += Time.deltaTime;
        setTimer();
    }

    private void setTimer(){
        minutes = Mathf.Floor(timer / 60);
        seconds = Mathf.RoundToInt(timer%60);

        if(minutes < 10) {
            minutesText = "0" + minutes.ToString();
        }else{
            minutesText = minutes.ToString();
        }
        if(seconds < 10) {
            secondsText = "0" + Mathf.RoundToInt(seconds).ToString();
        }else{
            secondsText = seconds.ToString();
        }

        timerText.text = minutesText + ":" + secondsText;
    }

    public float getTimer(){
        return timer;
    }
}
