using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour {

    public Transform Camera;
    public int MoveSpeed;
    public int JumpSpeed;
    public int RotateSpeed;
    bool Rotate;
    bool Move;





    public float Rotation_Speed;
    float Rotation_Friction; //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].
    public float Rotation_Smoothness; //Believe it or not, adjusting this before anything else is the best way to go.
    private float Resulting_Value_from_Input;
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;


    void Start () {
		
	}
	
	void FixedUpdate()
    {
		if(Input.GetKey(KeyCode.W))
        {
            Move = true;
            Rotate = true;
        }
        else
            Move = false;

        if(Move && Rotate)
        {
            Debug.Log("Rotate");
            Vector3 NextDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (NextDir != Vector3.zero)
            {
                Quaternion_Rotate_From = transform.rotation;
                var lol = Quaternion.LookRotation(Camera.TransformDirection(NextDir));
                var eLol = lol.eulerAngles;
                eLol.x = 0;
                eLol.z = 0;

                Quaternion_Rotate_To = Quaternion.Euler(eLol);
                transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * Rotation_Smoothness);
            }
        }

    }
}
