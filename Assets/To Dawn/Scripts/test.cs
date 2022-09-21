using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Rigidbody rb;
    
    private void Start() {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Jump());
    }

    IEnumerator Jump(){
        while(true){
            yield return new WaitForSeconds(2.0f);
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

    
}
