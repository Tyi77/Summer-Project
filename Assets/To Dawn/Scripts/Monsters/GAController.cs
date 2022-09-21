using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAController : MonoBehaviour
{
    List<GameObject> North = new List<GameObject>();
    List<GameObject> East = new List<GameObject>();
    List<GameObject> South = new List<GameObject>();
    List<GameObject> West = new List<GameObject>();
    
    public GameObject slime;
    public int maxSlime = 20;
    private int numSlime = 0;

    public static float timer = 0f;

    public Timer timerUI;

    private void Awake() {
        timerUI = GameObject.Find("Timer").GetComponent<Timer>();
    }

    private void Start() {
        foreach (Transform child in transform){
            if(child.tag == "North"){
                foreach (Transform child2 in child){
                    North.Add(child2.gameObject);
                }
            }else if(child.tag == "East"){
                foreach (Transform child2 in child){
                    East.Add(child2.gameObject);
                }
            }else if(child.tag == "South"){
                foreach (Transform child2 in child){
                    South.Add(child2.gameObject);
                }
            }else if(child.tag == "West"){
                foreach (Transform child2 in child){
                    West.Add(child2.gameObject);
                }
            }
        }
    }

    private int areaCount = 1; // Count the number of the area
    private int dice;
    
    private void Update() {
        timer = timerUI.getTimer();
        if(0 <= timer && timer < 30.0f){
            areaCount = 1;
            N();
        }else if(30.0f <= timer && timer < 60.0f){
            areaCount = 2;
            dice = Random.Range(0, 2);
            switch(dice){
                case 0:
                    N();
                    break;
                case 1:
                    E();
                    break;
            }
        }else if(60.0f <= timer && timer < 90.0f){
            areaCount = 3;
            dice = Random.Range(0, 3);
            switch(dice){
                case 0:
                    N();
                    break;
                case 1:
                    E();
                    break;
                case 2:
                    S();
                    break;
            }
        }else if(90.0f <= timer && timer < 120.0f){
            areaCount = 4;
            dice = Random.Range(0, 4);
            switch(dice){
                case 0:
                    N();
                    break;
                case 1:
                    E();
                    break;
                case 2:
                    S();
                    break;
                case 3:
                    W();
                    break;
            }
        }else if(120.0f <= timer && timer < 150.0f){
            areaCount = 2;
            dice = Random.Range(0, 2);
            switch(dice){
                case 0:
                    N();
                    break;
                case 1:
                    S();
                    break;
            }
        }else if(150.0f <= timer && timer < 180.0f){
            areaCount = 2;
            dice = Random.Range(0, 2);
            switch(dice){
                case 0:
                    E();
                    break;
                case 1:
                    W();
                    break;
            }
        }else{
            areaCount = 4;
            dice = Random.Range(0, 4);
            switch(dice){
                case 0:
                    N();
                    break;
                case 1:
                    E();
                    break;
                case 2:
                    S();
                    break;
                case 3:
                    W();
                    break;
            }
        }
        if(areaCount == 1){
            maxSlime = 20;
        }else if(areaCount == 2){
            maxSlime = 50;
        }else if(areaCount == 3){
            maxSlime = 80;
        }else if(areaCount == 4){
            maxSlime = 110;
        }
    }

    private void N(){
        if(numSlime < maxSlime){
            GameObject slimeClone = Instantiate(slime, North[Random.Range(0, North.Count)].transform.position, Quaternion.Euler(0, 0, 0), transform);
            slimeClone.GetComponent<Slime>().dead += slimeKilled;
            slimeClone.transform.parent = transform;
            numSlime++;
        }
    }
    private void E(){
        if(numSlime < maxSlime){
            GameObject slimeClone = Instantiate(slime, East[Random.Range(0, East.Count)].transform.position, Quaternion.Euler(0, 0, 0), transform);
            slimeClone.GetComponent<Slime>().dead += slimeKilled;
            slimeClone.transform.parent = transform;
            numSlime++;
        }
    }
    private void S(){
        if(numSlime < maxSlime){
            GameObject slimeClone = Instantiate(slime, South[Random.Range(0, South.Count)].transform.position, Quaternion.Euler(0, 0, 0), transform);
            slimeClone.GetComponent<Slime>().dead += slimeKilled;
            slimeClone.transform.parent = transform;
            numSlime++;
        }
    }
    private void W(){
        if(numSlime < maxSlime){
            GameObject slimeClone = Instantiate(slime, West[Random.Range(0, West.Count)].transform.position, Quaternion.Euler(0, 0, 0), transform);
            slimeClone.GetComponent<Slime>().dead += slimeKilled;
            slimeClone.transform.parent = transform;
            numSlime++;
        }
    }

    private void slimeKilled(){
        numSlime--;
    }
}
