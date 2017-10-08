using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDcode : MonoBehaviour {

	public void NewGame()
	{
		SceneManager.LoadScene (1);
	}
	public void CloseApp()
	{
		Application.Quit ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}
}
