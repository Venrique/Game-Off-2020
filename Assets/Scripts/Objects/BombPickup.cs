using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : Pickup
{
    protected override void onPickUp(){
        Player.bombs = true;
        Player.boss1Defeated = true;
    }
}
