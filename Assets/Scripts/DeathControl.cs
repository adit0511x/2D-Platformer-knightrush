using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public Animator animator;
    public GameObject player;
    private playerstats playerstat;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerstat = GetComponent<playerstats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -4.5){Die();}
    }

    void OnCollisionEnter2D(Collision2D colinfo) {
        if (colinfo.collider.tag=="obstacle"){
            Die();
            player.isStatic = true;
            

            Debug.Log("we hit obstacle");
        }
        
    }
    public void Die(){
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        playerstat.currenthealth = 0;
        animator.SetBool("isdead",true);
        animator.SetBool("isjump",false);


        StartCoroutine(respawn(1f));

    }
    IEnumerator respawn(float duration){
        yield return new WaitForSeconds(duration);

        
        SceneManager.LoadScene("SampleScene");
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
