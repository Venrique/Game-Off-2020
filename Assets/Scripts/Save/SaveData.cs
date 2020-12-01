using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public int hp;
    public int maxHP;
    public int attackBonus;

    public int scene;
    public float positionX;
    public float positionY;

    //public bool[] weaponUnlocked;
    //public int currentWeapon;

    public bool pickaxe;
    public bool bombs;
    public bool key1;

    public bool boss1Defeated;
    public int WakingUpAnimation;

    public SaveData(Player player){
        this.hp = Player.hp;
        this.maxHP = Player.maxHP;
        this.attackBonus = Player.attackBonus;

        //this.weaponUnlocked = Player.weaponUnlocked;
        //this.currentWeapon = Player.currentWeapon;
        this.pickaxe = Player.pickaxe;

        this.bombs = Player.bombs;
        this.key1 = Player.key1;

        this.boss1Defeated = Player.boss1Defeated;
        this.WakingUpAnimation = Pmoviendose.WakingUpAnimation;

        this.scene = SceneManager.GetActiveScene().buildIndex;
        this.positionX = player.transform.position.x;
        this.positionY = player.transform.position.y;
    }
}
