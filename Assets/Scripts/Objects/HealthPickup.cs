using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public int health = 1;

    protected override void onPickUp(){
        playerVida.restoreLife(health);
    }
}
