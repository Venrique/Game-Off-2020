using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShowMines : MonoBehaviour
{
    public GameObject[] objs;

    private void Start() {

        MostrarEnemigos(false);
    }

   private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Destroy(gameObject);
            MostrarEnemigos(true);
    }
   }

   void MostrarEnemigos(bool bl){
         foreach (GameObject obj in objs)
        {
            obj.SetActive(bl);
        }
   }
}

