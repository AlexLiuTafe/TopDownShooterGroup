using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour

    
{

    [Header("Attributes")]
    public int damage;
    public float speed;
    private Rigidbody2D rigid;
    private MasterController masterController;
    public Transform playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        rigid = GetComponent<Rigidbody2D>();
        masterController = GetComponent<MasterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
        rigid.velocity = (playerPos.transform.up).normalized * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy)
        {
            //enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
