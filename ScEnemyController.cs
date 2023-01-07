using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//DOGRU MU YAZDIM
using UnityEngine.SceneManagement;
public class ScEnemyController : MonoBehaviour
{
    public OyunBittiEkraný OyunBittiEkraný;

    [SerializeField] private GameObject PlayerGO;
    private Transform PlayerT;
    private Vector2 HomePos;
    UnityEngine.AI.NavMeshAgent agent;
    // NavMesh agent
    // Start is called before the first frame update
    private float TargetDist;

    [SerializeField] private float followRange=8f;
    void Start()
    {   if(PlayerGO == null) //buradaki if blogunu gülsahdan aldým
        {
            PlayerGO = GameObject.FindWithTag("Player");
        }
        PlayerT=PlayerGO.transform; 
        HomePos = new Vector2(this.transform.position.x, this.transform.position.y);
       agent = GetComponent<NavMeshAgent>();//
       agent.updateRotation = false;//
        agent.updateUpAxis = false;//
       // agent=getComponent
    }

    // Update is called once per frame
    void Update()
    {
        /*TargetDist = Vector2.Distance(PlayerT.position, this.transform.position);
        if(TargetDist< followRange)
        {
            agent.SetDestination(PlayerT.position);
        }
            
        else
        {//buradan emin deðilim
            //Debug.Log(agent.speed);
         //   this.transform.position = Vector2.MoveTowards(transform.position, HomePos, agent.speed*Time.deltaTime);
             agent.SetDestination(HomePos);
        } 
         
        */
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Enemy Trigger"+col.gameObject.name + ":" + gameObject.name + ":" + Time.time);

        if (col.gameObject.tag == "Bullet")
        { 
            Debug.Log("Enemy is hit with a bullet");
            // Destroy(col.gameObject);
           // Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Enemy Collision - " + col.gameObject.name + ":" + gameObject.name + ":" + Time.time);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Collision with player");
            //col.gameObject.SendMessage("ApplyDamage",10);
            col.gameObject.SendMessage("hurt", 30f);//GL,
            SceneManager.LoadScene("LoseScreen");/////////

        }
      /*  public float getMinHealth() { return this.min_Health; } //68-80 arasý gl
        public float getCurrHealth() { return this.curr_Health; }
        public void setHealth(float healthAmount)
        {
            if(healthAmount > this.max_Health)
            {
                this.curr_Health = this.max_Health;
            }
            else
            {
                this.curr_Health = healthAmount;
            }
        }*/

    }
    void OnMouseDown()
    {
        Debug.Log("mouse");
    }
    public void GameOver()
    {
       // OyunBittiEkraný.Setup(maxPlatform);
    }
}
