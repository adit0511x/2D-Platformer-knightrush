using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovt : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    [SerializeField]float MaxSpeed = 6f;
    [SerializeField]float accdec = 10f;
    [SerializeField]float jumppower = 6f;
    [SerializeField]float currentspeed = 1f;
    private bool isFacingRight = true;
    bool btnpress=false;
    [SerializeField]float targetspeed;
    public BoxCollider2D boxcollider2d;
    [SerializeField] private LayerMask platformlayermask;
    public Animator animator;
  
    
   
  
 
  
    
    
    
    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxcollider2d = transform.GetComponent<BoxCollider2D>();
        
    }
    
    void Update()
    {


        UpdateSpeed();
        animator.SetFloat("Speed",Mathf.Abs(currentspeed));
       
        animator.SetBool("isjump",!isGrounded());
        
         
          //accelarate and decelarate in motion
        if(horizontal==1){
          
          
            rb.velocity = new Vector2(currentspeed,rb.velocity.y);
        }
        else if(horizontal==0 && rb.velocity.x>0){
            rb.velocity = new Vector2(rb.velocity.x-Time.deltaTime*accdec,rb.velocity.y);}
        else if(horizontal==0 && rb.velocity.x<0){
            rb.velocity = new Vector2(rb.velocity.x+Time.deltaTime*accdec,rb.velocity.y);}
        else if(horizontal==-1){
            rb.velocity = new Vector2(-currentspeed,rb.velocity.y);
        }
        
        
        //turning left or right
        if(!isFacingRight && horizontal>0f){Flip();}
        if(isFacingRight && horizontal<0f){Flip();}
    }

    public void Jump(InputAction.CallbackContext context){
        Debug.Log(context.phase);
        if (context.performed && isGrounded() ){
            
            
            rb.velocity = new Vector2(rb.velocity.x,jumppower +(0.5f + Time.fixedDeltaTime * -rb.gravityScale)/rb.mass); }
        if (context.canceled){
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 0.5f*rb.velocity.y); }
    }

    public void Move(InputAction.CallbackContext context){
        Debug.Log(context.ReadValue<Vector2>());
        horizontal = context.ReadValue<Vector2>().x;
        if(context.started){btnpress = true;}
        if(context.canceled){ 
            btnpress = false;
        }
        
    }

    public void onlanding(){
        animator.SetBool("isjump",false);
    }

   


    private void Flip(){
        isFacingRight = !isFacingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    } 

    public void UpdateSpeed(){
        if(btnpress && currentspeed<MaxSpeed){currentspeed += Time.deltaTime*accdec;}
        else if(!btnpress && currentspeed>0f) {currentspeed -= Time.deltaTime*accdec;}
    }  


    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider2d.bounds.center,boxcollider2d.size,0f,Vector2.down,0.1f,platformlayermask);
        return raycastHit.collider;
        
    }

    
 
    
}
