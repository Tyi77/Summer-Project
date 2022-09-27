using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    private Reborn reborn;

    private void Awake()
    {
        scoreText = this.GetComponent<Text>();
        scoreText.text = "0";
        reborn = GameObject.FindWithTag("Player").GetComponent<Reborn>();
    }

    // private void OnEnable() {
    //     reborn.rebornEvent += Restart;
    // }

    private void Restart(){
        score = 0;
        scoreText.text = "0";
    }

    public void addScore()
    {
        score += 1;
        setScoreText();
    }

    // public void subScore()
    // {
    //     score -= 1;
    //     setScoreText();
    // }

    public void setScoreText(){
        scoreText.text = score.ToString();
    }
}
