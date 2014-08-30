using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float maxHealth;

	public float health;
	
	public float speed;
	
	public float damage;

	public Transform pickup;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var s = transform.FindChild("Plane").transform.localScale;
		s.x = 0.3f * health / maxHealth;
		transform.FindChild("Plane").transform.localScale = s;
		transform.LookAt(PlayerScript.thePlayer.transform);
		Vector3 r = transform.rotation.eulerAngles;
		r.x = 0;
		r.z = 0;
		transform.rotation = Quaternion.Euler(r);
		Vector3 v = transform.forward;
		v.y = 0;
		v.Normalize();
		rigidbody.velocity = v * speed;
		if(health <= 0)
		{
			if(Random.Range(0,5) == 0)
			{
				Instantiate(pickup, transform.position, Quaternion.identity);
			}
			PlayerScript.thePlayer.audio.Play();
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Bullet")
		{
			health -= other.GetComponent<BulletScript>().damage;
			
			Destroy(other.gameObject);
		}
	}
	
	void OnTriggerStay(Collider other) 
	{
		if(other.tag == "Player")
		{
			PlayerScript.thePlayer.health -= Time.deltaTime * damage;
		}
	}
}
