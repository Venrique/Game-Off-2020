using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : Pickup
{
    protected override void onPickUp(){
        Player.maxHP += 1;
        Player.hp = Player.maxHP;
    }
}
