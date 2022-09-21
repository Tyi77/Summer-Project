using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public delegate void Dead();
    public event Dead dead;
    
    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Player"){
            Destroy(gameObject);
        }
        if(other.transform.tag == "Bullet"){
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        dead?.Invoke();
    }
}
