using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 using UnityEngine.UI;

public class MostrarTexto : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject MostarLetras;

    void Start(){
         UIObject.SetActive(false);
    }
  
    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){
             UIObject.GetComponent<Animator>().SetBool("texto", true);
    
            UIObject.SetActive(true);
             
        }
    }

  
}
