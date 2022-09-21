using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText; // Inspector

    private void Start() {
        if(StaticVariables.playerName == null){
            nameText.text = "Name";
        }else{
            nameText.text = StaticVariables.playerName;
        }
    }
}
