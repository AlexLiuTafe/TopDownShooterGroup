using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaster : MonoBehaviour
{
	public GameObject enemy;
	public Transform[] spawnPoints;
	private Transform spawnParent;//for storing purpose
	private float spawnTimer;
	public float spawnRate;

	private void Awake()
	{
		spawnPoints = new Transform[transform.childCount];
		for (int i = 0; i < spawnPoints.Length; i++)
		{
			spawnPoints[i] = transform.GetChild(i);
		}
	}
	private void Start()
	{
		spawnParent = GameObject.Find("EnemyClones").GetComponent<Transform>();
	}
	// Update is called once per frame
	void Update()
    {
		//Time.time always going up 
		if (Time.time > spawnTimer)
		{
			spawnTimer	= Time.time + spawnRate;
			Spawn();
		}
	}
	void Spawn()
	{
		int randomPos = Random.Range(0, spawnPoints.Length);
		//Storing prefab as a GameObject
		GameObject clone = Instantiate(enemy, spawnPoints[randomPos].position, Quaternion.identity);
		//Storing the GameObject in an empty gameobject in a hierarchy
		clone.transform.SetParent(spawnParent);
	}
}
