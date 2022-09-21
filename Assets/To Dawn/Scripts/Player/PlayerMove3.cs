using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3: MonoBehaviour
{
    private bool state = true;

    private Animator controller;

    [SerializeField] private UIController uicontroller; // Inspector

    private void Awake() {
        controller = GetComponent<Animator>();
    }

    private void OnEnable() {
        transform.parent.GetComponent<PlayerState>().thirdEvent += Go;
        transform.parent.GetComponent<PlayerState>().firstEvent += Stop;
        transform.parent.GetComponent<PlayerState>().upperEvent += Stop;
        transform.GetComponent<WinOrDie>().dieEvent += Stop;
        transform.GetComponent<WinOrDie>().winEvent += Stop;
        uicontroller.pauseEvent += Stop;
        uicontroller.dePauseEvent += Go;
    }

    private void Go(){
        state = true;
        StartCoroutine("Move");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Stop(){
        state = false;
    }

    private Vector2 turn = new Vector2(0, 0);
    public float sensitivity = 4.0f;
    IEnumerator Move(){
        while(state){
            // Motion
            if(Input.GetKey(KeyCode.W)){
                controller.SetBool("Forward", true);
            }else{
                controller.SetBool("Forward", false);
            }
            if(Input.GetKey(KeyCode.S)){
                controller.SetBool("Backward", true);
            }else{
                controller.SetBool("Backward", false);
            }
            // Turn
            if(Time.timeScale != 0){
                turn.x += Input.GetAxis("Mouse X");
                transform.localRotation = Quaternion.Euler(0, turn.x * sensitivity, 0);
            }
            
            yield return null;
        }
    }
}
