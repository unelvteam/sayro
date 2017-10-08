using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lvl2Progress : MonoBehaviour {

    public int ChickenKills = 0;
    public int NeedKills;
	void Update () {
		if(ChickenKills >= NeedKills)
        {
            SceneManager.LoadScene("EndScene");
        }
	}
}
