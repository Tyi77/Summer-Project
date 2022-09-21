using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : MonoBehaviour
{
    public float rotateSpeed;

    Score score;

    private void Start() {
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
    }

    void Update()
    {
        this.transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f, Space.World);
    }
    
    public delegate void EventDelegate();
    public event EventDelegate destroyEvent;
    
    private void OnDestroy() {
        destroyEvent?.Invoke();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            score.addScore();
            Destroy(gameObject);
        }
    }
}
