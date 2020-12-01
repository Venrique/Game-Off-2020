using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class proximity : MonoBehaviour
{
    GameObject player;
    Transform playertransform;
    public GameObject imagen;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertransform = player.transform;
    }
    void Update()
    {
        Vector3 playerPosition = playertransform.position;
        float distancia = (playerPosition.x - transform.position.x);
        float division = Math.Abs(distancia / 255);
       
        float maximo = (1-(division*9))*255;
    
        //Debug.Log(maximo);
        if(Math.Abs(distancia) <=25){
            imagen.GetComponent<Image>().color = new Color32(14,14,14,Convert.ToByte(Convert.ToInt32(maximo)));
        }
        else if(Math.Abs(distancia) <=1){
                imagen.GetComponent<Image>().color = new Color32(14,14,14,255);
        }else{
            imagen.GetComponent<Image>().color = new Color32(14,14,14,0);
        }
    }
}
