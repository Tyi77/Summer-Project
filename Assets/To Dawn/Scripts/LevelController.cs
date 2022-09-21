using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public delegate void eventDelegate();
    public event eventDelegate startEvent;

    private void Start() {
        Time.timeScale = 1;
        startEvent?.Invoke();
    }


    public void Level1(){

    }

    public void Level2(){

    }

    public void Level3(){

    }
}
