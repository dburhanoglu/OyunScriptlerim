using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScPlayerDM : MonoBehaviour
{
    private ScPlayerData Player1Data;
    private bool isPlayerAlive;

    void Start()
    {
        Player1Data = new ScPlayerData();
        //Player1Data = new Player1Data();
        isPlayerAlive = true;
    }
   void Update()
    {
        if (isPlayerAlive && Input.GetKeyDown(KeyCode.KeypadPlus))
        {

            Player1Data.setHealth(Player1Data.getCurrHealth() + 10f);

        }
        if (isPlayerAlive && Input.GetKeyDown(KeyCode.KeypadMinus))
        {

            Player1Data.setHealth(Player1Data.getCurrHealth() -10f);

        }
        if (isPlayerAlive && Player1Data.getCurrHealth() <= Player1Data.getMinHealth())
        {
            Time.timeScale = 0;
            isPlayerAlive=false;
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);

        }
    }
    public void hurt(float damageAmount)
    {
        Player1Data.setHealth(Player1Data.getCurrHealth() + damageAmount);
        Debug.Log("player hurt- current health" + Player1Data.getCurrHealth());
    }
}
