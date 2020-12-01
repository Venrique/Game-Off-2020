using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDie : MonoBehaviour
{
    public EnemyLife boss;
    public AudioSource music;
    public GameObject drop;

    public GameObject text;

    public GameObject trigger;
    public GameObject bossTrigger;

    void Start(){
        if (Player.boss1Defeated){
            bossTrigger.SetActive(false);
        }
    }

    void Update(){
        if (boss.dead || boss == null){
            music.Stop();
            Instantiate(drop, transform.position, transform.rotation);
            Destroy(this.gameObject);
            text.SetActive(true);
            trigger.SetActive(true);
        }
    }
}
