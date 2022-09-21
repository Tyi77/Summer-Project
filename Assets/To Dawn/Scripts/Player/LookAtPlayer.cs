using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Vector3 oldPlayerPosition;
    private Vector3 offset;

    public Transform player; // Inspector

    private void Awake() {
        oldPlayerPosition = player.position;
    }

    private void Update() {
        offset = player.position - oldPlayerPosition;
        oldPlayerPosition = player.position;

        transform.Translate(offset, Space.World);
    }
}
