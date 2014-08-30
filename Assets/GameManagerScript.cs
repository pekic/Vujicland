using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public float t;

	public float surviveTime;

	public GameObject Boss;

	public GUITexture init, win, lose;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		t = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(t < surviveTime)
		{
			t += Time.fixedDeltaTime;
		}
		else
		{
			t = surviveTime;
			Spawner.isWorking = false;
			if(Boss != null)
			{
				Boss.rigidbody.useGravity =true;
				Boss.GetComponent<BossScript>().enabled = true;
			}
		}
	}

	void OnGUI()
	{
		if(Time.timeScale != 0)
		{
			var s = new GUIStyle();
			s.fontSize = 30;
			GUI.Label(new Rect(Screen.width/2, 50, 300, 30), (surviveTime - t).ToString().Substring(0, Mathf.Min(5,(surviveTime - t).ToString().Length)), s);
		}
	}

	public void StartGame()
	{
		init.enabled = false;
		init.GetComponent<InitScript>().enabled = false;
		Time.timeScale = 1;
		Spawner.isWorking = true;
	}

	public void Death()
	{
		lose.enabled = true;
		lose.GetComponent<LoseScript>().enabled= true;
	}

	public void Win()
	{
		win.enabled = true;
		Time.timeScale = 0;
		win.GetComponent<WinScript>().enabled= true;
	}
}
