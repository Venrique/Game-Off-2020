using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public AudioClip sound;
    public GameObject audioPlayer;
    protected Player player;
    protected VidaPlayer playerVida;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Destroy(gameObject);
            GameObject newAudioPlayer = Instantiate(audioPlayer);
            newAudioPlayer.transform.position = transform.position;
            newAudioPlayer.GetComponent<AudioSource>().clip = sound;
            newAudioPlayer.GetComponent<AudioSource>().Play();
            onPickUp();
        }
    }

    protected abstract void onPickUp();
}
