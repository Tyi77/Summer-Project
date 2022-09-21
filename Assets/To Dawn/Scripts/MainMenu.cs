using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject nameButton; // Inspector
    [SerializeField] private GameObject nameInput; // Inspector
    private TMP_Text nameButtonText;
    
    private void Awake() {
        nameButtonText = nameButton.transform.Find("Text").GetComponent<TMP_Text>();
    }

    private void Start() {
        if(StaticVariables.playerName == null){
            nameButtonText.text = "Name";
        }else{
            nameButtonText.text = StaticVariables.playerName;
        }
        nameButton.SetActive(true);
        nameInput.SetActive(false);
    }
    
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StaticVariables.playerName = nameButtonText.text;
    }

    public void QuitGame(){
        Debug.Log("Quit!");
        Application.Quit();
    }
    [SerializeField] [Range(100.0f, 1000.0f)] private float moveLength = 550.0f;

    public void displayPlayerName(){
        TMP_InputField nameInputField = nameInput.GetComponent<TMP_InputField>();
        if(string.IsNullOrEmpty(nameInputField.text)){
            nameButtonText.text = "Name";
        }else{
            nameButtonText.text = nameInputField.text;
        }
    }    

    public void nameButtonFO(){
        nameInput.gameObject.SetActive(true);
        StartCoroutine("FadeOut", nameButton);
        StartCoroutine("FadeIn", nameInput);
        StartCoroutine("MoveRight", nameInput);
        StartCoroutine("MoveLeft", nameButton);
    }

    public void nameInputFieldFO(){
        nameButton.gameObject.SetActive(true);
        StartCoroutine("FadeOut", nameInput);
        StartCoroutine("FadeIn", nameButton);
        StartCoroutine("MoveRight", nameButton);
        StartCoroutine("MoveLeft", nameInput);
    }

    IEnumerator FadeIn(GameObject thing){
        CanvasGroup cg = thing.GetComponent<CanvasGroup>();
        while(cg.alpha < 1){
            cg.alpha += Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator FadeOut(GameObject thing){
        CanvasGroup cg = thing.GetComponent<CanvasGroup>();
        while(cg.alpha > 0){
            cg.alpha -= Time.deltaTime;

            yield return null;
        }
        thing.gameObject.SetActive(false);
    }

    IEnumerator MoveRight(GameObject thing){
        float timer = 0;
        RectTransform rt = thing.GetComponent<RectTransform>();
        Vector3 oldPosition = rt.position;
        while(timer < 0.5){
            rt.position += new Vector3(Time.deltaTime * moveLength, 0, 0);
            timer += Time.deltaTime;

            yield return null;
        }
        while(timer < 1){
            rt.position -= new Vector3(Time.deltaTime * moveLength, 0, 0);
            timer += Time.deltaTime;

            yield return null;
        }
        rt.position = oldPosition;
    }

    IEnumerator MoveLeft(GameObject thing){
        float timer = 0;
        RectTransform rt = thing.GetComponent<RectTransform>();
        Vector3 oldPosition = rt.position;
        while(timer < 0.5){
            rt.position -= new Vector3(Time.deltaTime * moveLength, 0, 0);
            timer += Time.deltaTime;

            yield return null;
        }
        while(timer < 1){
            rt.position += new Vector3(Time.deltaTime * moveLength, 0, 0);
            timer += Time.deltaTime;

            yield return null;
        }
        rt.position = oldPosition;
    }
}
