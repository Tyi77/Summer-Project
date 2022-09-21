using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    private int health = 3;
    private Reborn reborn;

    private void Awake() {
        healthText = transform.GetComponent<Text>();
        reborn = GameObject.FindWithTag("Player").GetComponent<Reborn>();
        healthText.text = "3";
    }

    private void OnEnable() {
        reborn.rebornEvent += Restart;
    }

    private void Restart(){
        health = 3;
        healthText.text = "3";
    }

    public void addHealth()
    {
        health += 1;
        setHealthText();
    }

    public void subHealth()
    {
        health -= 1;
        setHealthText();
    }

    public void setHealthText(){
        healthText.text = health.ToString();
    }
}
