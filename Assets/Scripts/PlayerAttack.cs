using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    public MasterController attackJoystick;

    [Header("Attributes")]
    public float rotateSpeed;
	private Rigidbody2D rigid;
	public Vector2 direction;
	private Vector2 lookDirection;

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
    }
    void Update()
    {
		
		
		Aim();
		if(attackJoystick.Direction !=Vector2.zero)
		{
			LookDirection();
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
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

	}
}



