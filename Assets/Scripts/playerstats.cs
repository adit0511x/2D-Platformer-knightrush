using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class playerstats : MonoBehaviour




{

    public float maxhealth = 100;
    public float currenthealth;
    public BoxCollider2D enemycollider;
    public DeathControl deathcontrol;
    public UnityEngine.UI.Image healthbar;
    public CoinManager coins;
  

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        deathcontrol = GetComponent<DeathControl>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currenthealth<=0){
            deathcontrol.Die();   
        }

        healthbar.fillAmount = currenthealth/100f;


        
    }

   void OnCollisionStay2D(Collision2D colinfo) {
        if (colinfo.collider.tag=="enemy"){
            currenthealth-=0.6f;
           
        }}
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("coin")){
            coins.coinCount++;
            Destroy(other.gameObject);
        }
        
    }
    
        
    }
    
    
    




    

    
