using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercombat : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Attackpoint;
    public float Attackrange = 0.5f;
    public LayerMask enemylayers;
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackControl(InputAction.CallbackContext context){
        if (context.performed){
        Attack();}


    }



    void Attack(){
        animator.SetTrigger("attack");

        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(Attackpoint.position,Attackrange,enemylayers);

        foreach(Collider2D i in hitenemy){
            Debug.Log("we hit"+i.name);
            i.GetComponent<Enemy>().TakeDamage(20);
            
        }
    }

   private void OnDrawGizmosSelected() {
    if(Attackpoint ==null) return;
        Gizmos.DrawWireSphere(Attackpoint.position,Attackrange);
    }
}
