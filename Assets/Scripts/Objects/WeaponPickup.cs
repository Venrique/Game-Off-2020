using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    public int weaponId = 0;

    protected override void onPickUp(){
        Player.pickaxe = true;
    }
}
