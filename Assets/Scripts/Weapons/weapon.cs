using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
  
    public Transform Firepoint;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Disparar();
        }
    }

    void Disparar(){
        Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);

    }

}
