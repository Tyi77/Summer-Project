using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reborn : MonoBehaviour
{
    private Animator controller;

    private void Awake() {
        controller = GetComponent<Animator>();
    }

    private void Update() {
        if(controller.GetBool("Die") || controller.GetBool("Win")){
            state = true;
            StartCoroutine("RePlay");
        }
    }

    private bool state = false;

    public delegate void eventDelegate();
    public event eventDelegate rebornEvent; 

    IEnumerator RePlay(){
        while(state){
            if(Input.GetKey(KeyCode.C)){
                transform.position = new Vector3(0, 0, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                GameObject[] slimeArray = GameObject.FindGameObjectsWithTag("Monster");

                foreach(GameObject slime in slimeArray){
                    Destroy(slime.gameObject);
                }

                Time.timeScale = 1;

                rebornEvent?.Invoke();

                controller.SetBool("Die", false);
                controller.SetBool("Win", false);

                state = false;
            }
            yield return null;
        }

        
    }
}
