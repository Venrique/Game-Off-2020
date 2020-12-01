using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : EnemyController
{
    public Transform groundSensor;

    // Update is called once per frame
    void Update()
    {
        base.Update();
        myRigidBody.velocity = new Vector2(speed*direction, myRigidBody.velocity.y);

        RaycastHit2D wallRay = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 0.1f, LayerMask.GetMask("Ground"));
        if (wallRay.collider != null){
            SwitchDirection();
        }

        RaycastHit2D groundRay = Physics2D.Raycast(groundSensor.position, new Vector2(0, -1), 1f, LayerMask.GetMask("Ground"));
        if (groundRay.collider == null){
            SwitchDirection();
        }
    }
}
