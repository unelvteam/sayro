using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChickenScript : MonoBehaviour {

    float timer;
    public int MoveSpeed;
    public int Distance;
    public int PDistance;
    GameObject Player;
    Lvl2Progress LevelObj;
    public GameObject hotChick;
    bool P;
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        LevelObj = GameObject.Find("LevelObj").GetComponent<Lvl2Progress>();
    }

    void Update()
    {

          if (timer < 0)
            NewRotate();
        else
            timer -= Time.deltaTime;
        float Gravity = this.GetComponent<Rigidbody>().velocity.y;
        this.GetComponent<Rigidbody>().velocity = MoveSpeed * Time.deltaTime * this.transform.up;
        this.GetComponent<Rigidbody>().velocity += new Vector3(0, Gravity, 0);
        RaycastHit hit;

        Ray ray = new Ray(this.transform.position, this.transform.up);
        if (Physics.Raycast(ray, out hit))
        {
            if(Vector3.Distance(this.transform.position,hit.point) < Distance)
                NewRotate();
        }
        if (Vector3.Distance(Player.transform.position, this.transform.position) < PDistance && !P)
            NewRotate();


    }
    void NewRotate()
    {
        timer = Random.Range(1, 3);
        if(Vector3.Distance(Player.transform.position,this.transform.position) > PDistance)
        {
            this.transform.eulerAngles = new Vector3(90, Random.Range(0, 360), 0);
        }
        else
        {
            float Angles = Mathf.Atan2(this.transform.position.x - Player.transform.position.x, this.transform.position.z - Player.transform.position.z) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3(90, Angles, 0);
        }
    }



    void OnTriggerEnter(Collider col)
    {
		if(col.transform.tag == "vilka")
        {
            Instantiate(hotChick).transform.position = this.transform.position;
            Destroy(this.gameObject);
            LevelObj.ChickenKills++;
        }
    }
}
