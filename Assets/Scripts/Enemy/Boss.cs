using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyController
{
    public GameObject spawnP1;
    public GameObject spawnP2;
    public BossCrystal[] crystals;
    public float cooldown = 2f;
    public float shotSpeed = 2f;
    public GameObject dieAnimation;
    private int nextCrystal = 0;
    private int hitCounter = 0;

    void Start()
    {
        base.Start();
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        myRigidBody.velocity = new Vector2(speed*direction, myRigidBody.velocity.y);

        RaycastHit2D wallRay = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 1f, LayerMask.GetMask("Ground"));
        if (wallRay.collider != null){
            SwitchDirection();
            hitCounter = 0;
        }
    }

    IEnumerator Shoot(){
        BossCrystal crystal = crystals[nextCrystal];
        nextCrystal++;
        if (nextCrystal > 2){
            nextCrystal = 0;
        }
        BossCrystal newShot = Instantiate(crystal);
        newShot.transform.position = new Vector2(Random.Range(spawnP1.transform.position.x, spawnP2.transform.position.x), spawnP1.transform.position.y);   
        newShot.speed = shotSpeed;

        yield return new WaitForSeconds(cooldown);
        StartCoroutine(Shoot());
    }

    public override void onDie(){
        GameObject newDieAnimation = Instantiate(dieAnimation);
        newDieAnimation.transform.position = new Vector2(transform.position.x, transform.position.y+0.4f);
        newDieAnimation.transform.rotation = transform.rotation;
    }

    public override void onDamage(){
        hitCounter++;
        if (hitCounter >= 3){
            if (direction > 0 && player.transform.position.x < transform.position.x){
                SwitchDirection();
                hitCounter = 0;
            } else if (direction < 0 && player.transform.position.x > transform.position.x){
                SwitchDirection();
                hitCounter = 0;
            }
        }
    }
}
