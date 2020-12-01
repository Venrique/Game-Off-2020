using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
     PosicionInicial PlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = GameObject.FindWithTag("Player").GetComponent<PosicionInicial>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
          PlayerPosition.posInicial = this.transform.position;
           

        }
   }
}
