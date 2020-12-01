using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static void PlayIntro(){
        SceneManager.LoadScene("IntroScene");
    }

  
    public static void NewGame(){
        Player.spawnPositionX = -1;
        Player.spawnPositionY = -1;
        Player.hp = 5;
        Player.maxHP = 5;
        Player.attackBonus = 0;
        Player.pickaxe = false;
        Player.bombs = false;
        Player.key1 = false;
        Player.boss1Defeated = false;
        Pmoviendose.WakingUpAnimation = 0;
        SceneManager.LoadScene(1);
    }

    public static void Continue(){
        SaveData data = SaveSystem.LoadGame();
        if (data != null){
            Player.hp = data.hp;
            Player.maxHP = data.maxHP;
            Player.attackBonus = data.attackBonus;
            Player.pickaxe = data.pickaxe;
            Player.bombs = data.bombs;
            Player.key1 = data.key1;
            Player.boss1Defeated = data.boss1Defeated;
            //Player.weaponUnlocked = data.weaponUnlocked;
            //Player.currentWeapon = data.currentWeapon;
            Player.spawnPositionX = data.positionX;
            Player.spawnPositionY = data.positionY;
            Pmoviendose.WakingUpAnimation = data.WakingUpAnimation;
            ChangeScene(data.scene);
        }
    }

    public static void ChangeScene(int sceneId){
        Player.useSpawnPosition = true;
        SceneManager.LoadScene(sceneId);
    }

    public static void MainMenu(){
        SceneManager.LoadScene("MenuScene");
    }
}
