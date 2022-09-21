using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGo : MonoBehaviour
{   
    public float bulletSpeed = 30.0f;
    private Score score;

    private void Awake() {
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
    }

    private void Start() {
        StartCoroutine("CheckDestroyed"); // Check the bullet will be destroyed
    }
    private void Update() {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Monster"){
            Destroy(gameObject);
            Destroy(other.gameObject);

            // score.addScore();
        }
    }

    IEnumerator CheckDestroyed(){
        while(true){
            if(transform.position.x > 300 || transform.position.x < -300 || transform.position.y > 300 || transform.position.y < -300 || transform.position.z > 300 || transform.position.z < -300){
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(5.0f);
        }
    }
}
