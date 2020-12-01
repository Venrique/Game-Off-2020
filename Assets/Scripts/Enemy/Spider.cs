using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : EnemyController
{
    // Update is called once per frame
    void Update()
    {
        base.Update();
        if ((player.transform.position - this.transform.position).sqrMagnitude < 5*5){
            if (Mathf.Abs(player.transform.position.x - this.transform.position.x) > 0.1f){
                if (player.transform.position.x > this.transform.position.x){
                    SetDirection(1);
                } else {
                    SetDirection(-1);
                }
                myRigidBody.velocity = new Vector2(speed*direction, myRigidBody.velocity.y);
                GetComponent<Animator>().SetBool("move", true);
            } else {
                myRigidBody.velocity = new Vector2(0, myRigidBody.velocity.y);
            }
        } else {
            myRigidBody.velocity = new Vector2(0, myRigidBody.velocity.y);
            GetComponent<Animator>().SetBool("move", false);
        }
    }
}
