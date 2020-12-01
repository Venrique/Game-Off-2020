 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public Text dialogueText;
    public bool finished = false;
    public AudioSource textSound;
    public GameObject checkmark;

    private string[] fullText;
    private string currentText;
    public int index;
    private int charIndex;
    private bool currentTextCompleted;
    private bool dialogueActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dialogueText.text = currentText;
        if (dialogueActive){
            if (Input.GetKeyUp("space") || Input.GetButtonDown("Fire1")){
                if (currentTextCompleted){
                    index++;
                    if (index >= fullText.Length){
                        CloseDialogue();
                    } else {
                        NextText();
                    }
                } else {
                    SkipAnimation();
                }
            }
        }
    }

    IEnumerator TextAnimationCoroutine(){
        yield return new WaitForSeconds(0.03f);
        if (currentText.Length >= fullText[index].Length){
            currentTextCompleted = true;
            textSound.Stop();
            checkmark.SetActive(true);
        } else {
            currentText += fullText[index][charIndex];
            charIndex++;
            StartCoroutine(TextAnimationCoroutine());
        }
    }

    private void NextText(){
        GetComponent<AudioSource>().Play();
        textSound.Play();
        checkmark.SetActive(false);
        currentText = "";
        charIndex = 0;
        currentTextCompleted = false;
        StartCoroutine(TextAnimationCoroutine());
    }

    private void SkipAnimation(){
        currentText = fullText[index];
        charIndex = fullText[index].Length;
        currentTextCompleted = true;
        StopAllCoroutines();
        textSound.Stop();
        checkmark.SetActive(true);
    }

    public void ShowDialogue(string[] text){
        fullText = text;
        index = 0;
        charIndex = 0;
        dialogueText.text = "";
        currentText = "";
        currentTextCompleted = false;
        gameObject.SetActive(true);
        dialogueActive = true;
        NextText();
    }

    public void CloseDialogue(){
        fullText = new string[]{};
        index = 0;
        charIndex = 0;
        dialogueText.text = "";
        currentText = "";
        currentTextCompleted = false;
        gameObject.SetActive(false);
        dialogueActive = false;
        StopAllCoroutines();
        finished = true;
    }
}
