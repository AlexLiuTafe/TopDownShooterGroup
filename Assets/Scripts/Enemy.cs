using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    [Header("Attributes")]
    public int health = 5;
    public float speed = 3f;


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
        Vector2 direction = (target.transform.position - transform.position);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        SpeedBuff();
        if(health<=0)
            {
                Destroy(gameObject);
            }
    }
    void SpeedBuff()
    {
        if(health <= 4)
        {
            speed = 4f;
        }
    }

}
