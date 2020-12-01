using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonTransitionToMines : MonoBehaviour
{
    public DialogueBox dialogueBox;
    public GameObject imagen;

    public GameObject imagen2;
    private string[] dialogue = new string[]{
      "James kept walking for a while, and then he thought that maybe he should return to pick up his flashlight.",
      "He just wanted to scout the surroundings before taking his full equipment.",
      "But suddenly, he tripped with a small rock.",
      "“Oh shoot!” he thought",
      "He hoped that he would fall in flat terrain, but he kept falling and falling. And then he realized…",
      "…He just kept falling!",
      "He was falling into what appeared to be a giant chasm, hidden in the depths of the dark side of the moon.",
      "He lost all hope, and whispered something to himself…",
      "“I’m sorry mike… I’ve failed you…”",
      "“I won’t be able to rescue you…”",
      "And then...",
      "He passed out...",
      "But he somehow managed to survive..."

    };

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.ShowDialogue(dialogue);
        imagen.SetActive(false);
        imagen2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueBox.index == 5){
            imagen.SetActive(true);
        }
        if (dialogueBox.finished){
            StartCoroutine(fade());
           
        }
    }
    IEnumerator fade(){
        imagen2.SetActive(true);
        yield return new WaitForSeconds(4f);
        Player.spawnPositionX = 7.1f;
        Player.spawnPositionY = -3.09f;
        GameManager.ChangeScene(2);

    }
}


