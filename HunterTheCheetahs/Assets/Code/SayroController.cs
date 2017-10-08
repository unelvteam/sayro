using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayroController : MonoBehaviour {


	public Animator anim;
	public GameObject cam;
	public GameObject isGroundedCheker;
	public Rigidbody rb;
	public float JumpForce,moveSpeed,attackTime;
	public bool collided,grounded;

	private float GroundDist;

	public Vector3 hit_position;



	public float Rotation_Speed;
	public float Rotation_Friction; //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].
	public float Rotation_Smoothness; //Believe it or not, adjusting this before anything else is the best way to go.
	private float Resulting_Value_from_Input;
	private Quaternion Quaternion_Rotate_From;
	private Quaternion Quaternion_Rotate_To;







	// Use this for initialization
	void Start () {
		GroundDist = GetComponent<Collider> ().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {

		attackTime -= Time.deltaTime;
		if(Input.GetButtonDown ("Fire1") ){attackTime = 0.5f;}

		if (attackTime <= 0)
		{
			anim.SetBool ("Attack", false);
		} else 
		{
			anim.SetBool ("Attack", true);
		}



			Vector3 NextDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			if (NextDir != Vector3.zero) {
				Quaternion_Rotate_From = transform.rotation;
				var lol = Quaternion.LookRotation (cam.transform.TransformDirection (NextDir));
				var eLol = lol.eulerAngles;
				eLol.x = 0;
				eLol.z = 0;

				Quaternion_Rotate_To = Quaternion.Euler (eLol);
				transform.rotation = Quaternion.Lerp (Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * Rotation_Smoothness);
			}




	}


	Vector3 GetRotationFromCamera()
	{

		var thisRotation = transform.localEulerAngles;
		thisRotation.y = cam.transform.localEulerAngles.y;
		return thisRotation;
	}

	bool GroundCheck()
	{
		RaycastHit hit;
		var temp =	Physics.SphereCast (isGroundedCheker.transform.position,2.5f, -transform.up, out hit,3);
		try{}
		catch{}
		return temp;
	}


	public void OnCollisionEnter(){
		collided =true;
	}

	public void OnCollisionExit(){
		collided =false;
	}


	void FixedUpdate()
	  {
		Vector3 NextDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));

		grounded = GroundCheck ();

		anim.SetBool("isGrounded",grounded);

	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	



		RaycastHit aim_hit;
		Physics.Raycast (ray, out aim_hit);
		Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.green);
		hit_position = aim_hit.point;




		var h = Input.GetAxis ("Horizontal") * moveSpeed;
		var v = Input.GetAxis ("Vertical") * moveSpeed;


		if (grounded )
		{				if (Input.GetButton ("Jump")) {
					rb.AddRelativeForce ((Vector3.up * JumpForce));
		}}
	


		else 
		{
			if (collided) { rb.velocity = new Vector3 (0,rb.velocity.y,0); } else 
	
		
		{
			
				if (NextDir != Vector3.zero) {
					rb.velocity = transform.TransformDirection (new Vector3 (rb.velocity.x, rb.velocity.y, 25));
				} else {rb.velocity = new Vector3 (0,rb.velocity.y,0);
				}
			}
	
	
	}




		anim.SetBool("Jump",Input.GetButton("Jump"));

		var temp = 0.0f;
		if (Mathf.Abs(Input.GetAxis ("Horizontal")) >= Mathf.Abs(Input.GetAxis ("Vertical"))) {temp = Mathf.Abs(Input.GetAxis ("Horizontal"));}
		else{temp =Mathf.Abs(Input.GetAxis ("Vertical")) ;}

		anim.SetFloat ("Run", temp);


	}

}
