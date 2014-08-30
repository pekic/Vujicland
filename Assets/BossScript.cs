using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	public float maxHealth;

	public float health;
	
	public float speed;
	
	public float damage;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt(PlayerScript.thePlayer.transform);
		Vector3 r = transform.rotation.eulerAngles;
		r.x = 0;
		r.z = 0;
		transform.rotation = Quaternion.Euler(r);
		Vector3 v = transform.forward;
		v.y = 0;
		v.Normalize();
		v.y = rigidbody.velocity.y / speed;
		rigidbody.velocity = v * speed;
		if(health <= 0)
		{
			Camera.main.GetComponent<GameManagerScript>().Win();
			Destroy(this.gameObject);
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
