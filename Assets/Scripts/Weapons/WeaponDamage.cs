using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDamage : MonoBehaviour
{
    public float dmg = 1;
   
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Enemy"){
            collision.GetComponent<EnemyLife>().takeDamage(dmg);
        }
    }
}