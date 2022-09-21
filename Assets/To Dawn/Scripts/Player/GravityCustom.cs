using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCustom : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate() {
        rb.AddForce(-Vector3.up * 9.81f);
        Debug.Log(1);
    }
}
