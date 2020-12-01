using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrystal : MonoBehaviour
{
    public int direction;
    public float speed = 2f;
    public GameObject groundEffect;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = new Vector2(0, -speed);
    }

    IEnumerator destroy(){
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground"){
            GameObject newEffect = Instantiate(groundEffect);
            newEffect.transform.position = new Vector2(transform.position.x, transform.position.y);
        }    
    }
}
