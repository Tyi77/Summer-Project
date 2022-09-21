using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    Health health;

    private void Awake() {
        health = GameObject.FindWithTag("Health").GetComponent<Health>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Monster"){
            health.subHealth();
        }
    }
}
