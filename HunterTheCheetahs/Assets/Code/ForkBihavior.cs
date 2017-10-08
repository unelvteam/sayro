using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkBihavior : MonoBehaviour {
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "chicken")
			Debug.Log ("Triggered");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
