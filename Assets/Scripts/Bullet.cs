using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour

    
{

    [Header("Attributes")]
    public int damage;
    public float speed;
    private Rigidbody2D rb;
    private PlayerAttack playerAttack;
    private Vector2 bulletDir;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		GameObject player = GameObject.Find("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
		bulletDir = playerAttack.direction;
		transform.up = bulletDir;
	}

    // Update is called once per frame
    void Update()
    {
		//rb.AddForce(bulletDir.normalized * speed, ForceMode2D.Impulse);
		rb.velocity = bulletDir.normalized * speed;
	}
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
