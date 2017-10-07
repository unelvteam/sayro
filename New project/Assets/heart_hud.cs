using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart_hud : MonoBehaviour {


    public int lives;
    public Texture live_texture;
    public int live_x;
    public int live_y;
	// Use this for initialization
	void Start () {
        lives = 3;
        live_x = 10;
        live_y = 10;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Z))
        {
            lives++;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            lives--;
        }
    }

    private void OnGUI()
    {
        for (int i = 0; i < lives; i++)
        {
            GUI.DrawTexture(new Rect(live_x + i * 64, live_y, 64, 64), live_texture);
        }
    }
}
