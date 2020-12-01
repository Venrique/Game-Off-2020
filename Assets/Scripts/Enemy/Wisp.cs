using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : EnemyController
{
    private int counter = 0;

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if ((player.transform.position - this.transform.position).sqrMagnitude < 5*5){
            if (player.transform.position.x > this.transform.position.x){
                SetDirection(1);
            } else {
                SetDirection(-1);
            }
            Vector2 directionVector = (this.transform.position - player.transform.position).normalized;
            myRigidBody.velocity = directionVector*-speed;
        } else {
            myRigidBody.velocity = new Vector2(speed*Mathf.Cos(counter/10), speed*Mathf.Sin(counter/10));
            counter++;
        }
    }
}
