using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private bool state = true; // Go or Stop
    private int cameraState = 0; // 0 = 3rd, 1 = 1st, 2 = upper

    public delegate void EventDelegate();
    public event EventDelegate thirdEvent;
    public event EventDelegate firstEvent;
    public event EventDelegate upperEvent;

    [SerializeField] private WinOrDie winordie; // Inspector
    [SerializeField] private Reborn reborn; // Inspector
    [SerializeField] private LevelController levelController; // Inspector
    [SerializeField] private UIController uicontroller; // Inspector

    private void OnEnable() {
        levelController.startEvent += Go;
        winordie.dieEvent += Stop;
        winordie.winEvent += Stop;
        reborn.rebornEvent += Go;
        uicontroller.pauseEvent += Pause;
        uicontroller.dePauseEvent += Go;
    }

    private void Go(){
        state = true;
        StartCoroutine("StartChanging");
        thirdEvent?.Invoke();
    }

    private void Stop(){
        state = false;
        cameraState = 0;
        thirdEvent?.Invoke();
    }

    private void Pause(){
        state = false;
        cameraState = 0;
    }

    IEnumerator StartChanging() {
        while(state){
            if(Input.GetKeyDown(KeyCode.E)){
                switch(cameraState){
                    case 0:
                        cameraState = 1;
                        break;
                    case 1:
                        cameraState = 2;
                        break;
                    case 2:
                        cameraState = 0;
                        break;
                }
                switch(cameraState){
                    case 0:
                        thirdEvent?.Invoke();
                        break;
                    case 1:
                        firstEvent?.Invoke();
                        break;
                    case 2:
                        upperEvent?.Invoke();
                        break;
                }
            }

            yield return null;
        }
    }

}
