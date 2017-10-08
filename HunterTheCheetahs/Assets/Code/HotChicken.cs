using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotChicken : MonoBehaviour {

    public float timer = 3;
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0,50000,0));
    }
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
            Destroy(this.gameObject);
    }
}
