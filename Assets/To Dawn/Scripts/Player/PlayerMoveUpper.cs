using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveUpper: MonoBehaviour
{
    public Camera upper; // Inspector
    private bool state = false;

    private Animator controller;

    [SerializeField] private UIController uicontroller; // Inspector

    private void Awake() {
        controller = GetComponent<Animator>();
    }

    private void OnEnable() {
        transform.parent.GetComponent<PlayerState>().thirdEvent += Stop;
        transform.parent.GetComponent<PlayerState>().firstEvent += Stop;
        transform.parent.GetComponent<PlayerState>().upperEvent += Go;
        transform.GetComponent<WinOrDie>().dieEvent += Stop;
        transform.GetComponent<WinOrDie>().winEvent += Stop;
        uicontroller.pauseEvent += Stop;
        uicontroller.dePauseEvent += Go;
    }

    private void Go(){
        state = true;
        StartCoroutine("Move");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void Stop(){
        state = false;
    }

    Ray cameraRay;
    RaycastHit hit;
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
            cameraRay = upper.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity)){
                this.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }

            yield return null;
        }
    }
}
