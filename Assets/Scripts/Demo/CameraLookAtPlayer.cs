using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    public Transform player;

    Vector3 oldPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldPlayerPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = player.position - oldPlayerPosition;
        oldPlayerPosition = player.position;
        transform.Translate(offset, Space.World);
    }
}
