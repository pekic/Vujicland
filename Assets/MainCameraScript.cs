using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {

	public Transform target;

	public float constraintX, constraintZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(target.position.x, -constraintX, constraintX); 
		pos.z = Mathf.Clamp(target.position.z, -constraintZ, constraintZ); 
		transform.position = pos;
	}
}
