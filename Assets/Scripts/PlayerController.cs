using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour{

    public float jumpForce = 5f;

    public Animator animator;

    public float runningSpeed = 1.5f;

    private Rigidbody2D rigidbody;

    void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isAlive", true);
        animator.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update(){
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Aquí, el usuario acaba de bajar la tecla espacio
                Jump();
            }
        }

        animator.SetBool("isGrounded", IsTouchingTheGround());
    }

    void FixedUpdate(){
        if (rigidbody.velocity.x < runningSpeed){
            rigidbody.velocity = new Vector2(runningSpeed, rigidbody.velocity.y);
        }  
    }

    void Jump(){
        //f = m * a ========> a = F/m
        if (IsTouchingTheGround()){
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public LayerMask groundLayer;

    bool IsTouchingTheGround(){
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer)){
            return true;
        }else{
            return false;
        }
        
    }   
}
