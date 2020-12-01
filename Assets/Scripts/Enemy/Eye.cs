using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : EnemyController
{
    public Shot shot;
    public GameObject shotSpawnPoint;
    public float cooldown = 2f;
    public float shotSpeed = 2f;
    public bool playerClose;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if ((player.transform.position - this.transform.position).sqrMagnitude < 10*10){
            if (!playerClose){
                StartCoroutine(Shoot());
            }
            playerClose = true;
        } else {
            playerClose = false;
            StopAllCoroutines();
        }
    }

    IEnumerator Shoot(){
        Shot newShot = Instantiate(shot, shotSpawnPoint.transform.position, this.transform.rotation);   
        newShot.SetDirection(direction);
        newShot.speed = shotSpeed;
        GetComponent<Animator>().SetBool("shoot", true);
        yield return new WaitForSeconds(cooldown/2f);
        GetComponent<Animator>().SetBool("shoot", false);
        yield return new WaitForSeconds(cooldown/2f);
        StartCoroutine(Shoot());
    }
}
