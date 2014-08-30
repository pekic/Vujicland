using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;

	public Transform bullet;

	public bool shooting;

	public float attackSpeed;

	public float health;

	public static PlayerScript thePlayer;

	public float GUIMaxHP;

	public Texture guiLabel;

	// Use this for initialization
	void Start () {
		thePlayer = this;
	}


	void FixedUpdate () {
		int vertical = 0;
		int horizontal = 0;

		if(Input.GetKey(KeyCode.A))
		{
			horizontal += -1;
		}
		if(Input.GetKey(KeyCode.D))
		{
			horizontal += 1;
		}

		if(Input.GetKey(KeyCode.S))
		{
			vertical += -1;
		}
		if(Input.GetKey(KeyCode.W))
		{
			vertical += 1;
		}

		Vector3 v = new Vector3(horizontal, 0, vertical);
		v.Normalize();
		v = v * speed;

		rigidbody.velocity = v;

		if(Input.GetMouseButtonDown(0) && !IsInvoking("Shoot"))
		{
			shooting = true;
			Shoot();
		}
		if(Input.GetMouseButtonUp(0))
		{
			shooting = false;
		}
		if(health <= 0)
		{
			Death();
		}
	}


	void Shoot()
	{
		if(Input.GetMouseButton(0))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector2 v = new Vector2(r.direction.x, r.direction.z);
			v.Normalize();
			float angle = Vector2.Angle( new Vector2(0, 1), v) * Mathf.Sign(r.direction.x);
			Instantiate(bullet, transform.position, Quaternion.Euler(0, angle, 0));
			Invoke("Shoot", attackSpeed);
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(35,35, (GUIMaxHP * (health / 100)),30), guiLabel, ScaleMode.StretchToFill);

	}

	void Death()
	{
		Camera.main.GetComponent<GameManagerScript>().Death();
	}
}
