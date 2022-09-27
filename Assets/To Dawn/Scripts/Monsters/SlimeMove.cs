using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpScale = 5.0f;
    
    private GameObject player;
    private Rigidbody rb;
    private Health health;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        health = GameObject.FindWithTag("Health").GetComponent<Health>();

        StartCoroutine(Jump());
    }

    private void Update() {
        // Look at the player
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        // Adjust to the right posture
        transform.Rotate(new Vector3(-90, 0, 0));
        // Move
        transform.Translate(-Vector3.up * speed * Time.deltaTime, Space.Self);
    }

    IEnumerator Jump(){
        while(true){
            yield return new WaitForSeconds(2f);

            rb.AddForce(Vector3.up * jumpScale, ForceMode.Impulse);
        }
    }
}
