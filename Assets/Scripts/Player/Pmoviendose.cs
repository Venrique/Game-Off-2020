using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class Pmoviendose : MonoBehaviour
{
    // ------------ KNOCKBACK ---------------

    public float knockback;
    public float knockbackLenght;

    public float knockbackCount;
    public bool knockRight;
    public float knockbackUp;
    

    //-----------------------------------------
   public static Pmoviendose instance;
    Rigidbody2D miTransform;
    public float runSpeed = 2;
    public float jumpSpeed = 3;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    
    public float moveVelocity;
    public bool facingRight;

    public bool move;
    
    VidaPlayer life;

    // ---------- scene mines -------------
    Scene currentScene; 

     string sceneName;
    
    public static int WakingUpAnimation = 0;

   // ------------------------------------- 
   
   private void Awake() {
       instance = this;
   }

    void Start()
    {   
        
        currentScene = SceneManager.GetActiveScene ();

        sceneName = currentScene.name;
        move = true;
        if(sceneName == "NivelMinas" && WakingUpAnimation == 0){
            
            StartCoroutine(Standing());
            
        }

        facingRight = true;
        miTransform = GetComponent<Rigidbody2D>();
        life = GetComponent<VidaPlayer>();
       
        
    }
    IEnumerator Standing(){
        move = false;
        this.GetComponent<Animator>().SetBool("standing", true);
        yield return new WaitForSeconds(3.5f);
        this.GetComponent<Animator>().SetBool("standing", false);
        move = true;
        WakingUpAnimation ++;
    }
    // Update is called once per frame
    void Update()
    {
       
         
            if(Player.hp > 0 && move == true){
                moveVelocity = 0f;
                
                float horizontal = Input.GetAxis("Horizontal");
                    
                if(CheckGround.isGrounded){
                    
                    GetComponent<Animator>().SetBool("caer",false);
                }
                //Saltar
                if (Input.GetKey("space") && CheckGround.isGrounded){
                    Saltar();
                }

                
                if (Input.GetKey(KeyCode.D)){
                    moveVelocity = runSpeed;
                    moverDerecha();
                }
                if (Input.GetKey(KeyCode.A)){
                    moveVelocity = -runSpeed;
                    moverIzquierda();
                } 
                
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
                    QuedarseQuieto();
                }

                if(miTransform.velocity.y < 0){
                    Caer();
                }else if(miTransform.velocity.y > 0 ){
                    GetComponent<Animator>().SetBool("caer", false);
                }

                if(betterJump){
                        SaltoMejorado();
                }


                // -------------- KNOCK BACK ------------------

                if(knockbackCount <=0){
                    miTransform.velocity = new Vector2(moveVelocity, miTransform.velocity.y);
                }else{
                    if(knockRight){
                        miTransform.velocity = new Vector2(-knockback, knockbackUp);

                    }
                    if(!knockRight){
                        miTransform.velocity = new Vector2(knockback, knockbackUp);
                    }
                    knockbackCount -= Time.deltaTime;
                    
                }
            }else{
                miTransform.velocity = new Vector2(0, miTransform.velocity.y);
            }
        

    }

//Metodos
   
        
        //KnockBack
public IEnumerator Knockback(float knockDuration, float knockPower, Transform obj){
    float timer = 0;
    while(knockDuration > timer){

        timer += Time.deltaTime;
        Vector2 direction = (obj.transform.position - this.transform.position).normalized;
        miTransform.AddForce(-direction * knockPower);
    }

    yield return 0;
}
  

    private void Flip(float horizontal){
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight){
            facingRight= !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
      
    }

    private void Caer(){
        GetComponent<Animator>().SetBool("saltar", false);
        GetComponent<Animator>().SetBool("caer", true);
    }

    private void moverDerecha()
    {
      
        if (CheckGround.isGrounded){
            
            GetComponent<Animator>().SetBool("correr", true);
        
        }else{
            GetComponent<Animator>().SetBool("correr", false);
            
        }
        Flip(1);
        miTransform.velocity = new Vector2(runSpeed, miTransform.velocity.y);
        
    }

    private void moverIzquierda()
    {
        
        if (CheckGround.isGrounded){
            
            GetComponent<Animator>().SetBool("correr", true);
            
        }else{
            GetComponent<Animator>().SetBool("correr", false);
            
        }
        Flip(-1);
        miTransform.velocity = new Vector2(-runSpeed, miTransform.velocity.y);
    }


    private void QuedarseQuieto()
    {
        GetComponent<Animator>().SetBool("correr", false);
        miTransform.velocity = new Vector2(0, miTransform.velocity.y);
       
    }

    private void Saltar(){
        GetComponent<Animator>().SetBool("saltar", true);
        miTransform.velocity = new Vector2(miTransform.velocity.x, jumpSpeed);
    }

    private void SaltoMejorado(){
        if(miTransform.velocity.y < 0){
            miTransform.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        }

            if(miTransform.velocity.y > 0 && !Input.GetKey("space")){
            miTransform.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Enemy"){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
