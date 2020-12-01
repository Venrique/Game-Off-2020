using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public DialogueBox dialogueBox;
    public GameObject imagen;

    private string[] dialogue = new string[]{
        "August 24th, 2030",
        "In recent years, the International Space Research Institute (ISRI) has been investigating the possible presence of an unknown civilization hidden in the dark side of the moon.",
        "As part of this investigation multiple launches have been performed in order to scout the surroundings.",
        "Sadly, all these operations have been declared a failure.",
        "All the courageous men who were sent to the moon in the previous four launches…",
        "…never returned…",
        "Since the first failure, all of the operations have been focused on finding out what happened to our lost men.",
        "Needless to say, we still don’t really know…",
        "However, our last operation gave us a hint of what may be happening.",
        "During a radio transmission, Michael Martínez (the man in charge of the operation) managed to tell us what he saw before it cut off.",
        "“They’re here” he said…",
        "That message was both a ray of hope, and probably also a curse.",
        "We have to get to the bottom of this and, in the best-case scenario, rescue every astronaut who disappeared mysteriously.",
        "That’s the objective of our next mission, so we have prepared our best man: James Martínez.",
        "He is Michael’s younger brother, so he insisted in going. They may be siblings almost the same age, but the difference between them is like night and day.",
        "James has received military training, and he also was a survivalist in a TV program called “Survivorperson”.",
        "“James, we’re putting the future of ISRI… no, the future of mankind on your shoulders. You’re the only one who can reach the truth”",
        "And so… James was sent to the moon, not knowing if he would ever return.",
        "This is the beginning of operation codename “The Frontier”."
    };

    // Start is called before the first frame update
    void Start()
    {
        imagen.SetActive(false);
        dialogueBox.ShowDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.finished){
            StartCoroutine(fade());
            
        }
    }

    IEnumerator fade(){
        imagen.SetActive(true);
        yield return new WaitForSeconds(3f);
        GameManager.NewGame();
    }
}
