using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrDie : MonoBehaviour
{
    [SerializeField] private Health health; // Inspector
    [SerializeField] private Score score; // Inspector
    [SerializeField] private LevelController levelController; // Inspector
    private Animator controller;

    private void Awake() {
        controller = GetComponent<Animator>();
    }

    private void OnEnable() {
        levelController.startEvent += Go;
        GetComponent<Reborn>().rebornEvent += Go;
    }

    private void Go(){
        StartCoroutine("DetectWinOrDie");
    }

    public delegate void eventDelegate();
    public event eventDelegate dieEvent;
    public event eventDelegate winEvent;

    IEnumerator DetectWinOrDie(){
        while(true){
            if(health.healthText.text == "0"){ // Die
                dieEvent?.Invoke();
                StartDying();

                break;
            }
            if(score.scoreText.text == "5"){
                winEvent?.Invoke();
                StartWin();

                break;
            }
            yield return null;
        }
    }

    private void StartDying(){
        controller.SetBool("Die", true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void StartWin(){
        controller.SetBool("Win", true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
