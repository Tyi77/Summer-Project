using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Health health;

    private void Start() {
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);

            health.subHealth();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Supply"){
            Destroy(other.gameObject);

            health.addHealth();
        }
    }
}
