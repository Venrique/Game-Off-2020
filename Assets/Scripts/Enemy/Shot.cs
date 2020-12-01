using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int direction;
    public float speed = 2f;
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
        myRigidBody.velocity = new Vector2(speed*direction, 0);
    }

    public void SetDirection(int direction){
        this.direction = direction;
        if (direction > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    IEnumerator destroy(){
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
