using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelCave : MonoBehaviour {
	public GameObject FadeIn;
	public float timer;
	public bool start;
	void OnTriggerEnter()
	{
		Debug.Log ("Hi");
		FadeIn.SetActive (true);
		start = true;

	}

	// Use this for initialization
	void Start () {
		timer = 1f;
	}
	
	// Update is called once per frame
	void Update () {

		if(start)timer -= Time.deltaTime;
		if (timer <= 0)
			SceneManager.LoadScene (2);
	}
}
