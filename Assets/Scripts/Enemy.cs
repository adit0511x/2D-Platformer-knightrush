using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Enemy : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public int maxhealth = 100;
    [SerializeField] int currenthealth;
    public Animator animator;
    
    private Transform playerpos;
    [SerializeField]public int enemyspeed = 1;
    [SerializeField] private LayerMask playerlayermask;
    private bool followtrigger;
    private bool isfacingleft = true;
  
    
    
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        
        
        
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
        
        
    }

    // Update is called once per frame
    void Update(){
         Debug.DrawRay(boxCollider2D.bounds.center,Vector2.left*3f,Color.green);
         

         if(!followtrigger){

            RaycastHit2D raycasthitleft = Physics2D.Raycast(boxCollider2D.bounds.center,Vector2.left,4f,playerlayermask);
            RaycastHit2D raycasthitright = Physics2D.Raycast(boxCollider2D.bounds.center,Vector2.right,4f,playerlayermask);
            
            if (raycasthitleft.collider !=null ||raycasthitright.collider !=null){followtrigger = true;}


            
         }

         if(followtrigger){
            transform.position = Vector2.MoveTowards(transform.position,playerpos.position,enemyspeed*Time.deltaTime);
         }

         if(!isfacingleft && transform.position.x -playerpos.position.x>0f){Flip();}
        if(isfacingleft && transform.position.x -playerpos.position.x<0f){Flip();}
    }

    private void Flip(){
        isfacingleft = !isfacingleft;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    } 

   

    

     public void TakeDamage(int damage){
        animator.SetTrigger("ishit");
        currenthealth -= damage;
       
        
        if (currenthealth<=0){Die();
        }
    }

    void Die(){
        Debug.Log("Enemy ded");
        animator.SetBool("isdead",true);
        boxCollider2D.enabled = false;
        }
}
