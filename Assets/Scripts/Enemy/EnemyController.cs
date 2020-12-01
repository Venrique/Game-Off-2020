using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;
    public int direction = 1;
    protected Rigidbody2D myRigidBody;
    protected GameObject player;
    public EnemyLife enemyLife;

    // Start is called before the first frame update
    protected void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        Physics2D.IgnoreCollision(player.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        SetDirection(direction);
    }

    // Update is called once per frame
    protected void Update()
    {
        if (enemyLife.dead){
            myRigidBody.velocity = new Vector2(0,0);
            enabled = false;
            StopAllCoroutines();
        }
    }

    protected void SetDirection(int direction){
        this.direction = direction;
        if (direction > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    protected void SwitchDirection(){
        SetDirection(direction*-1);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player"){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    public virtual void onDie(){

    }

    public virtual void onDamage(){

    }
}
