using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    private bool fullScreen;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F11)){
            if(fullScreen){
                Screen.fullScreen = false;
            }else{
                Screen.fullScreen = true;
            }
            fullScreen = !fullScreen;
        }
    }
}
