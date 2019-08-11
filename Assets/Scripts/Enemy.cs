using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//ENEMY HAS A LAYER SO DOES NOT COLLIDE WITH PLAYER'S COLLIDER AND PUSH PLAYER AROUND


    private Transform target;
    [Header("Attributes")]
    public int health = 5;
    public float speed = 3f;
	public float stopDistance = 1.5f;
	[Header("EnemyAttack")]
	public int damage = 1;
	public float attackRadius = 0.5f;
	private float attackTimer;
	public float attackRate =2f;



	private void OnDrawGizmos()
	{

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,attackRadius);

	}

	// Start is called before the first frame update
	void Start()
    {
		
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        
    }
    private void Move()
    {

		
		if (Vector2.Distance(transform.position,target.position) <= stopDistance)
		{
			transform.position = this.transform.position;
			Attack();
		}
		else
		{
			Vector2 direction = (target.transform.position - transform.position);
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        //SpeedBuff();
        if(health<=0)
            {
                Destroy(gameObject);
            }
    }
    void SpeedBuff()
    {
        if(health <= 2)
        {
            speed = 4f;
        }
    }
	public void Attack()
	{
		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, attackRadius);
		foreach (var col in cols)
		{
			PlayerAttack player = col.GetComponent<PlayerAttack>();
			if(player)
			{
				if(Time.time >= attackTimer)
				{
					player.PlayerTakeDamage(damage);
					attackTimer = Time.time + attackRate;

				}
			}
		}
	}
}
