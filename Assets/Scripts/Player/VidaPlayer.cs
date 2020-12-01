using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
  //public int vida = 5;
  //public int maxLives = 5;
  public Image barraDeVida;
  public LifeIcons lifeIcons;
  public AudioClip[] damageSoundClips;
  AudioSource damageSound;
  SpriteRenderer spriteRenderer;
  private int currentAudio = 0;
  public bool invulnerable;

  void Start(){
    damageSound = GameObject.FindWithTag("Damage").GetComponent<AudioSource>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    //La vida no pasara de 0 ni de 100
    Player.hp = Mathf.Clamp(Player.hp, 0, Player.maxHP);
    lifeIcons.updateLifeIcons(Player.maxHP, Player.hp); 

    //barraDeVida.fillAmount = vida/100; 
    if(Player.hp == 0){
      Debug.Log("Me mori");
      
      StartCoroutine(die());
    }  
  }

  public void takeDamage(int dmg){
    if (!invulnerable){
      Player.hp -= dmg;
      damageSound.Stop();
      currentAudio++;
      if (currentAudio > 2){
        currentAudio = 0;
      }
      damageSound.clip = damageSoundClips[currentAudio];
      damageSound.Play();
      invulnerable = true;
      StartCoroutine(invulnerabilityTimer());
    }
  }

  public void restoreLife(int health){
    Player.hp += health;
  }

  IEnumerator die() {
    invulnerable = true;
    GetComponent<Animator>().SetBool("dead",true);
    yield return new WaitForSeconds(4.5f);  
    SceneManager.LoadScene("GameOver");
  }

  IEnumerator invulnerabilityTimer(){
    Color color = spriteRenderer.color;
    color.a = 0.5f;
    spriteRenderer.color = color;
    yield return new WaitForSeconds(1f);
    color.a = 1f;
    spriteRenderer.color = color;
    invulnerable = false;
  }
}
