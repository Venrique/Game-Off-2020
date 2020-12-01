using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitarLetras : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject MostarLetras;
    public GameObject QuitarL;

    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            UIObject.GetComponent<Animator>().SetBool("textoSubiendo", true);
            Destroy(UIObject,10);
            Destroy(MostarLetras, 0);
            Destroy(QuitarL,0);

        }
    }
}
