 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScHandGunBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDamage;
    [SerializeField] float lifeTime = 1f;


    public void shootBullet(float angle)
    {
        // x ve y ekseninde merminin hýzlanmasý (pozitif veya negatif olabilir)
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * Mathf.Cos(angle * Mathf.PI / 180), bulletSpeed * Mathf.Sin(angle * Mathf.PI / 180));
        Destroy(this.gameObject, lifeTime);  //Merminin kaybolmasý

    }

    //Merminin duvardan sekmesi için 
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Bullet Trigger"+col.gameObject.name + " : " + gameObject.name + " : " + Time.time );        
        if (col.CompareTag("Obstacle"))
        {
            //Debug.Log("Obstacle");
            BoxCollider2D m_ObjectCollider = this.gameObject.GetComponent<BoxCollider2D>();
            m_ObjectCollider.isTrigger = false;
        }

    }
}