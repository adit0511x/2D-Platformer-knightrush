using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameoverui;
    public Transform player;
    public CoinManager coins;
    void Start()
    {
        gameoverui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(coins.coinCount == 29f){
            player.gameObject.SetActive(false);
            Gameover();}
        
    }

    public void Gameover(){
        gameoverui.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("Scene1");
    }

    


}
