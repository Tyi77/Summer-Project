using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSwitcher : MonoBehaviour
{
    public Camera third; // Inspector
    public Camera first; // Inspector
    public Camera upper; // Inspector

    private void Awake() {
        transform.parent.GetComponent<PlayerState>().thirdEvent += thirdPerspective;
        transform.parent.GetComponent<PlayerState>().firstEvent += firstPerspective;
        transform.parent.GetComponent<PlayerState>().upperEvent += upperPerspective;
    }

    private void thirdPerspective(){
        third.gameObject.SetActive(true);
        first.gameObject.SetActive(false);
        upper.gameObject.SetActive(false);
    }
    private void firstPerspective(){
        third.gameObject.SetActive(false);
        first.gameObject.SetActive(true);
        upper.gameObject.SetActive(false);
    }
    private void upperPerspective(){
        third.gameObject.SetActive(false);
        first.gameObject.SetActive(false);
        upper.gameObject.SetActive(true);
    }
}
