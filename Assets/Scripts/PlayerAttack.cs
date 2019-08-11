using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	//PLAYER HAS A LAYER SO DOES NOT COLLIDE WITH ENEMY'S COLLIDER AND PUSH ENEMY AROUND

	[Header("References")]
    public MasterController attackJoystick;
	private Transform spawnParent; //for storing in hierarchy purpose

    [Header("Attributes")]
    public float rotateSpeed;
	private Rigidbody2D rigid;
	public Vector2 direction;
	private Vector2 lookDirection;
	[Header("PlayerHealth")]
	public int health = 50;
	

	[Header("SHooting")]
    private float shootTimer;
    public float shootRate = 2f;
    public GameObject bulletPrefab;
	private Transform playerPos;
	private Transform firePoint;
	

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position + (Vector3)direction * 3f, 0.1f);
	}
	private void Start()
    {

		firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
		rigid = GetComponent<Rigidbody2D>();
		spawnParent = GameObject.Find("BulletClones").GetComponent<Transform>();
    }
    void Update()
    {
		
		
		Aim();
		if(attackJoystick.Direction !=Vector2.zero)
		{
			LookDirection();
			//Time.time always keep going up 
			if (Time.time > shootTimer)
			{
				shootTimer = Time.time + shootRate;
				Shoot();
			}
		}
		direction = attackJoystick.Direction;

		
	}
    public void Shoot()
    {

        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
		Bullet bullet = bulletGo.GetComponent<Bullet>();
        Destroy(bulletGo, 1f);
		bulletGo.transform.SetParent(spawnParent);

	}
    public void Aim()
    {
		rigid.velocity = (new Vector2(attackJoystick.Horizontal, attackJoystick.Vertical) * 0 * Time.deltaTime);
		
	}
	public void LookDirection()
	{
		lookDirection = direction;
		float angle = Mathf.Atan2(lookDirection.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Snap to the look direction
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed);
        //rotate slowly according to time.delta time
       // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

    }
	public void PlayerTakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}



