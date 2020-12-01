using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject weapon;
    //public Sprite pickaxeSprite;

    public static int hp = 5;
    public static int maxHP = 5;
    public static int attackBonus;
    public static bool pickaxe = true;
    public static bool bombs = true;
    public static bool key1;
    public static bool boss1Defeated;
    //public static int currentWeapon = -1;
    //public static bool[] weaponUnlocked;
    public static float spawnPositionX;
    public static float spawnPositionY;
    public static bool useSpawnPosition;

    //private string[] weaponName;
    //private Sprite[] weaponSprite;
    //private float[] weaponDamage;

    // Start is called before the first frame update
    void Start()
    {
        //weaponUnlocked = new bool[]{false};
        //weaponName = new string[]{"Pickaxe"};
        //weaponSprite = new Sprite[]{pickaxeSprite};
        //weaponDamage = new float[]{1};

        /*if (currentWeapon != -1){
            setWeapon(currentWeapon);
        }*/

        if (useSpawnPosition){
            transform.position = new Vector2(spawnPositionX, spawnPositionY);
        }
        useSpawnPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickaxe){
            weapon.SetActive(true);
        } else {
            weapon.SetActive(false);
        }
        /*if (Input.GetKeyUp(KeyCode.Q)){
            changeWeapon();
        }*/
    }

    /*private void changeWeapon(){
        for (int i=currentWeapon; i<weaponUnlocked.Length; i++){
            if (i >= 0 && weaponUnlocked[i]){
                currentWeapon = i;
                break;
            }
        }
        if (currentWeapon >= weaponUnlocked.Length){
            currentWeapon = 0;
        }
    }*/

    /*private void setWeapon(int id){
        weapon.SetActive(true);
        weapon.GetComponent<SpriteRenderer>().sprite = pickaxeSprite;
    }*/

    /*public void unlockWeapon(int id){
        weaponUnlocked[id] = true;
        currentWeapon = id;
        setWeapon(id);
    }*/

    public void saveAnimation(){
       StartCoroutine(saveAnimationCoroutine());
    }

    IEnumerator saveAnimationCoroutine(){
        GetComponent<Animator>().SetBool("save", true);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().SetBool("save", false);
    }
}
