using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health health;

    private void Start() {
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
    }

    public delegate void EventDelegate();
    public event EventDelegate destroyEvent;

    private void OnDestroy() {
        destroyEvent?.Invoke();
    }
}
