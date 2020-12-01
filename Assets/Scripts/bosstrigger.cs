using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstrigger : MonoBehaviour
{
    public GameObject text;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            StartCoroutine(DestroyGameObjects());


        }
    }
    IEnumerator DestroyGameObjects(){
        Destroy(gameObject);
        text.GetComponent<Animator>().SetBool("textoSubiendo", true);
        yield return new WaitForSeconds(2f);
        Destroy(text);
    }
}
