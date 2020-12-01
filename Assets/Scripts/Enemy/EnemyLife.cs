using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    public float maxVida = 100;
    private float vida = 100;
    private bool invulnerable;
    public bool dead = false;

    public GameObject flashSprite;
    public ParticleSystem particles;
    public GameObject enemyDieEffect;
    private SpriteRenderer spriteRenderer;
    private SpriteMask spriteMask;
    private AudioSource hitSound;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteMask = GetComponent<SpriteMask>();
        hitSound = GetComponent<AudioSource>();
        vida = maxVida;
    }
   
    // Update is called once per frame
    void Update()
    {
        //La vida no pasara de 0 ni de 100
        vida = Mathf.Clamp(vida, 0, maxVida); 
    }

    public void takeDamage(float dmg){
        if (!invulnerable){
            vida -= dmg;
            invulnerable = true;
            StartCoroutine(invulnerableTimer());
            StartCoroutine(flash());
            particles.Play();
            hitSound.Play();
            GetComponent<EnemyController>().onDamage();

            if(vida <= 0){
                dead = true;
                die();
            }

            if (vida < maxVida*0.5){
                flashSprite.GetComponent<SpriteRenderer>().color = new Color(1f,1f,0,1f);
            } else if (vida < maxVida*0.25){
                flashSprite.GetComponent<SpriteRenderer>().color = new Color(1f,0,0,1f);
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Weapon"){
           
        }    
    }*/

    /*private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Weapon"){
            invulnerable = false;
        }    
    }*/

    IEnumerator flash(){
        spriteMask.sprite = spriteRenderer.sprite;
        flashSprite.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        flashSprite.SetActive(false);
    }

    IEnumerator invulnerableTimer(){
        yield return new WaitForSeconds(0.1f);
        invulnerable = false;
    }

    private void die(){
        GetComponent<EnemyController>().onDie();
        GameObject newEnemyDieEffect = Instantiate(enemyDieEffect, transform.position, transform.rotation);
        newEnemyDieEffect.GetComponent<AudioSource>().clip = hitSound.clip;
        newEnemyDieEffect.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }
}