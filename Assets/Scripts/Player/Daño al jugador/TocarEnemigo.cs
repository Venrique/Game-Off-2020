using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarEnemigo : MonoBehaviour
{
    public int cantidad = 1;
    VidaPlayer playerVida;
    Rigidbody2D playerrb;
    public EnemyLife enemyLife;
    public bool isProyectile = false;

    // Start is called before the first frame update
    void Start()
    {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();   
        playerrb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            if (!isProyectile && enemyLife.dead){
                return;
            }
            if (playerVida.invulnerable){
                return;
            }
            playerVida.takeDamage(cantidad);
            //StartCoroutine(Pmoviendose.instance.Knockback(KnockBackDuration, KnockBackPower, this.transform));
            var player = other.GetComponent<Pmoviendose>();
            player.knockbackCount = player.knockbackLenght;
            player.knockbackUp = player.knockback;
            if(other.transform.position.y > transform.position.y){
                player.knockbackUp *= 1;
            }else if(other.transform.position.y < transform.position.y){
                player.knockbackUp *= -1;
            }else{
                player.knockbackUp = playerrb.velocity.y;
            }

            if(other.transform.position.x < transform.position.x){
                player.knockRight = true;
            }else{
                player.knockRight = false;
            }
        }
    }
}
