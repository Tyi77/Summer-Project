using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Animator controller;
    public GameObject bullet; // Inspector
    public GameObject gun; // Inspector
    [SerializeField] private UIController uicontroller; // Inspector
    [SerializeField] private LevelController levelController; // Inspector

    private bool loopState = false; // Shoot loop

    private bool state = true; // Wheather can shoot
    
    private void Awake() {
        controller = GetComponent<Animator>();
    }

    private void OnEnable() {
        levelController.startEvent += Go;
        transform.GetComponent<WinOrDie>().dieEvent += Stop;
        transform.GetComponent<WinOrDie>().winEvent += Stop;
        transform.GetComponent<Reborn>().rebornEvent += Go;
        uicontroller.pauseEvent += Stop;
        uicontroller.dePauseEvent += Go;
    }

    private void Stop(){
        state = false;
    }

    private void Go(){
        state = true;
        StartCoroutine("StartShoot");
    }

    IEnumerator StartShoot(){
        while(state){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                controller.SetBool("Shoot", true);
                loopState = true;
                GameObject bulletClone = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
                bulletClone.transform.parent = transform;
                StartCoroutine("loopShoot");
            }
            
            if(Input.GetKeyUp(KeyCode.Mouse0)){
                controller.SetBool("Shoot", false);
                loopState = false;
            }

            yield return null;
        }
    }

    private float timer = 0.0f;
    private float endTime = 0.6f;
    IEnumerator loopShoot(){
        while(loopState){
            if(timer < endTime){
                timer += Time.deltaTime;
            }else{
                GameObject bulletClone = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
                bulletClone.transform.parent = transform;
                timer = 0.0f;
            }

            yield return null;
        }
    }
}
