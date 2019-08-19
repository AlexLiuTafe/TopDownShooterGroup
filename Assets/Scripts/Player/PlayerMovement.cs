using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 20f;
    public MasterController moveJoystick;
    public Vector2 minimumBoundary;
    public Vector2 maximumBoundary;
    Rigidbody2D rigid;


	
	private void Start()
    {
		
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();

    }

    public void Move()
    {
        //using vector.normalized always return max movementspeed
        rigid.velocity = ( new Vector2(moveJoystick.Horizontal,moveJoystick.Vertical).normalized* movementSpeed * Time.deltaTime);
		
	}
   
}
