using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDest : MonoBehaviour {

	public GameObject []objs;
	public float timer;
	// Use this for initialization
	void Start () {
		timer = 13f;

	

	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{	foreach (var x in objs) 
			{
				x.SetActive (true);
			}

			Destroy (gameObject);
		}
	}
}
