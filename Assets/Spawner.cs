using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform spawn;

	public float spawnTime;

	public static bool isWorking = false;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn()
	{
		if(isWorking)
		{
			Instantiate(spawn, transform.position, Quaternion.identity);
		}
		Invoke("Spawn", spawnTime);
	}

}
