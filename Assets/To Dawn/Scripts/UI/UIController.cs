using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private WinOrDie winordie; // Inspector
    [SerializeField] private Reborn reborn; // Inspector
    
    private void OnEnable() {
        winordie.dieEvent += gameOver;
        winordie.winEvent += gameWin;
        reborn.rebornEvent += gameRestart;
    }

    public delegate void eventDelegate();
    public event eventDelegate pauseEvent;
    public event eventDelegate dePauseEvent;

    private bool pauseState = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.P)){
            Pause();
        }
    }

    private CursorLockMode oldMode;

    private void Pause(){
        if(pauseState){
            Time.timeScale = 1;
            dePauseEvent?.Invoke();
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            Cursor.lockState = oldMode;
        }else{
            Time.timeScale = 0;
            pauseEvent?.Invoke();
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            oldMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        pauseState = !pauseState;
    }

    private void gameWin(){
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
    }

    private void gameOver(){
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
    }

    private void gameRestart(){
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        pauseState = false;
    }
}
