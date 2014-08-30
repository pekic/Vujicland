using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

	public Transform bullet;

	public int num;

	public bool fired= false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && !fired)
		{
			fired = true;
			for (int i = 0; i < num; i++) 
			{
				Instantiate(bullet, transform.position, Quaternion.Euler(0, 360 * i / num ,0));		
			}
			Destroy(gameObject);
		}
	}
}
