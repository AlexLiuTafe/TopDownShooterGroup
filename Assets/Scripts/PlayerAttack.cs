using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    public MasterController attackJoystick;
    [Header("Attributes")]
    public float rotateSpeed;

    private float shootTimer;
    public float shootRate = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;


    private void Start()
    {
        
       // firePoint = GameObject.Find("FirePoint").transform;
    }
    void Update()
    {

        Rotate();
        if (Time.time > shootTimer)
        {
            shootTimer = Time.time + shootRate;
            Shoot();
        }

    }
    public void Shoot()
    {

        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bullet.Fire();
        Destroy(bulletGo, 1f);

        

    }
    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, attackJoystick.Horizontal), rotateSpeed);
    }
}



