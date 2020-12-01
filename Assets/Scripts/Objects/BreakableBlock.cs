using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public bool breaksWithWeapon;
    public bool breaksWithBomb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Weapon"){
            if (breaksWithWeapon){
                StartCoroutine(destroy());
            }
        }
        if(other.tag == "Bomb"){
            if (breaksWithBomb){
                StartCoroutine(destroy());
            }
        }     
    }

    IEnumerator destroy(){
        GetComponent<Animator>().SetBool("break", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
