using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStation : MonoBehaviour
{
    public GameObject instructions;
    public GameObject text;
    private Player player;
    private bool active = false;
    AudioSource saveSound;

    // Start is called before the first frame update
    void Start()
    {
        saveSound = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetKeyUp(KeyCode.W)){
            Player.hp = Player.maxHP;
            SaveSystem.SaveGame(new SaveData(player));
            saveSound.Play();
            StartCoroutine(showText());
            player.saveAnimation();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            active = true;
            instructions.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player"){
            active = false;
            instructions.SetActive(false);
        }
    }

    IEnumerator showText(){
        text.SetActive(true);
        text.GetComponent<Animator>().Play("Fade");
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
        /*
        text.GetComponent<Animator>().SetBool("texto", true);
        yield return new WaitForSeconds(2f);
        text.GetComponent<Animator>().SetBool("texto", false);
        text.GetComponent<Animator>().SetBool("textoSubiendo", true);
        yield return new WaitForSeconds(2f);
        text.GetComponent<Animator>().SetBool("textoSubiendo", false);
        
        */
    }
}
