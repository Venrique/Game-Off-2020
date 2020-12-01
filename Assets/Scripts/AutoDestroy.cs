using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time = 1f;

    void Start(){
        StartCoroutine(destroy());
    }

    IEnumerator destroy(){
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
