using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject pickaxe;
    public GameObject bomb;
    VidaPlayer life;
    Rigidbody2D miTransform;
    Player player;
    private bool attacking;
    private bool bombUsed;

    private void Start() {
        pickaxe.GetComponent<BoxCollider2D>().enabled = false;   
        life = GetComponent<VidaPlayer>(); 
        miTransform = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Player.hp >0){
        //Disparar
            if(Player.pickaxe && !attacking){
                if(Input.GetButtonDown("Fire1")){
                    atacar();
                    attacking = true;
                    StartCoroutine(attackCooldown());
                }
            }
            if (Player.bombs && !attacking){
                if (Input.GetButtonDown("Fire2")){
                    throwBomb();
                }
            }
        }else{
            miTransform.velocity = new Vector2(0, miTransform.velocity.y);
        }   
    }

    private void atacar() {
        if (!CheckGround.isGrounded){
            GetComponent<Animator>().SetTrigger("atacar");
        } else {
            GetComponent<Animator>().SetTrigger("atacaraire");
        }
        GetComponent<AudioSource>().Play();     
    }

    private void throwBomb(){
        if (!bombUsed){
            GameObject newBomb = Instantiate(bomb);
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), newBomb.GetComponent<Collider2D>());
            newBomb.transform.position = new Vector2(transform.position.x, transform.position.y+0.3f);
            int direction = -1;
            if (GetComponent<Pmoviendose>().facingRight){
                direction = 1;
            }
            newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2((3+Mathf.Abs(miTransform.velocity.x))*direction,3);
            bombUsed = true;
            StartCoroutine(bombCooldown());
        }
    }

    IEnumerator attackCooldown(){
        yield return new WaitForSeconds(0.2f);
        attacking = false;
    }

    IEnumerator bombCooldown(){
        yield return new WaitForSeconds(1f);
        bombUsed = false;
    }  
}
