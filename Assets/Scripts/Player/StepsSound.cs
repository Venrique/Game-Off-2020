using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StepsSound : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audiosrc;
    AudioSource jumpSound;
    public GameObject walkEffect;
    public GameObject jumpEffect;
    bool isMoving = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        audiosrc =  GameObject.FindWithTag("Run").GetComponent<AudioSource>();
        jumpSound =  GameObject.FindWithTag("Jump").GetComponent<AudioSource>(); 
    }
    
    void Update()
    {
        if (rb.velocity.magnitude > 1 && CheckGround.isGrounded){
            if (!isMoving){
                audiosrc.Play();
                walkEffect.SetActive(true);
            }
            isMoving = true;
        } else {
            audiosrc.Stop();
            isMoving = false;
            walkEffect.SetActive(false);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded){
            jumpSound.Play();
            GameObject newJumpEffect = Instantiate(jumpEffect);
            newJumpEffect.transform.position = new Vector2(transform.position.x, transform.position.y-0.3f);
        }
    }
}
