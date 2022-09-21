using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 10.0f;

    private void Update()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        // ���oWASD�ƾ�
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // ���oVector3(LR value, 0, ForwardAndBack value)
        Vector3 move = Vector3.right * moveX + Vector3.forward * moveZ; // direction
        player.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        yield return null;
    }
}
