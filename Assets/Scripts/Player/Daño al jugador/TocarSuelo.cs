using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarSuelo : MonoBehaviour
{
    VidaPlayer playerVida;
    public int cantidad = 10;
    PosicionInicial inicial;
    GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();   
        inicial = GameObject.FindWithTag("Player").GetComponent<PosicionInicial>();
        jugador = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){

            playerVida.takeDamage(cantidad);
            jugador.transform.position = inicial.posInicial;

        }
    }
}
