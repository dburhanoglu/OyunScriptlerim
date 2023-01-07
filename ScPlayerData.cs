using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScPlayerData 
{
    private float max_Health = 100f;
    private float min_Health = 0f;
    private float curr_Health = 50f;

    private float playerPosX;
    private float playerPosY;
  
  public float getMinHealth() { return this.min_Health; }//yeri doðru mu 2.6.dk
  public  float getCurrHealth() { return curr_Health; }
  public  void setHealth(float healthAmount)
    {
        if (healthAmount > this.max_Health)
            this.curr_Health = this.max_Health;
        else
            this.curr_Health = healthAmount;
    }
}
