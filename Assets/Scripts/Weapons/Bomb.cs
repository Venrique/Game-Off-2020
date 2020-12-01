using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator explode(){
        yield return new WaitForSeconds(1f);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);    
    }
}
