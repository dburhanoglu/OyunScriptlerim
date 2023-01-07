using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScHandGun : MonoBehaviour
{
    //  [SerializeField] float bulletSpeet;
    //[SerializeField] float bulletDamage;
    // Start is called before the first frame update

    [SerializeField]  private GameObject BulletGO;
    [SerializeField] private Transform bulletSpawnPoint;
    public void shoot (float angle){
        Vector3 positionBullet = bulletSpawnPoint.position;
        Quaternion rotationBullet = Quaternion.Euler(0, 0, BulletGO.transform.eulerAngles.z + angle);
        GameObject bullet = Instantiate(BulletGO,positionBullet,rotationBullet,this.transform.parent.transform);
        bullet.GetComponent<ScHandGunBullet>().shootBullet(angle);
            }
}