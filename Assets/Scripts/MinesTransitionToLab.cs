using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesTransitionToLab : MonoBehaviour
{
    public DialogueBox dialogueBox;
    public GameObject imagen;
    public GameObject imagen2;
    public GameObject fadeImage;

    private string[] dialogue = new string[]{
      "James suddenly found a strange facility, one with extremely advanced technology.",
      "“What the hell is this?” he asked himself in a rather scared tone.",
      "Inside that room he saw several capsules with a dense green liquid.",
      "But that wasn’t the scary part…",
      "Inside those tubes, he found his fellow astronauts from ISRI…",
      "“T-this… i-i-is insane…” He said with trembling lips.",
      "“They re-really are here…”",
      "Will James be able to scape from this hellish place and rescue all of his colleagues?",
      "We may find out someday in the future.",
      "To be continued…"
    };

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.ShowDialogue(dialogue);
        imagen.SetActive(false);
        imagen2.SetActive(false);
        fadeImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueBox.index == 2){
            imagen.SetActive(true);
        }
        if(dialogueBox.index == 4){
            imagen2.SetActive(true);
        }
        if (dialogueBox.finished){
            imagen.SetActive(false);
            imagen2.SetActive(false);
            StartCoroutine(fade());
        }
    }
    IEnumerator fade(){
        fadeImage.SetActive(true);
        yield return new WaitForSeconds(4f);
        GameManager.ChangeScene(10);
    }
}
