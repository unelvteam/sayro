using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSec : MonoBehaviour {

	public GameObject Cub1,Cub2,rcub1,rcub2;
	bool isLocked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.O) && Input.GetKey (KeyCode.P)) {
			if (!isLocked) { 
				isLocked = true;
				Cub1.SetActive (false);
				Cub2.SetActive (false);
				rcub1.SetActive (true);
				rcub2.SetActive (true);

			}
		}
		
	}
}
