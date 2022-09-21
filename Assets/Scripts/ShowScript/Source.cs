using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision enter: " + other.transform.name);
    }

    void OnCollisionStay(Collision other)
    {
        Debug.Log("collision stay: " + other.transform.name);
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("collision exit: " + other.transform.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter: " + other.transform.name);
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger stay: " + other.transform.name);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exit: " + other.transform.name);
    }
}
