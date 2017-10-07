using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {

    public Transform[] Cubes;
    public Transform RotateParent;


    public int RotateSpeed;
    bool Rotate;
    Transform[] RotateObjects;
    int Axis;

    public Transform[] ObjChecked;
    bool Connected;
    void Start()
    {
        RotateObjects = new Transform[4];
    }

    void Update()
    {

        if (!Connected)
        {
            if (!Rotate)
            {
                Connected = true;
                for (int i = 0; i < ObjChecked.Length; i++)
                {
                    if (ObjChecked[i].eulerAngles != new Vector3(270, 0, 0))
                        Connected = false;
                }
                if(Connected)
                {
                    this.GetComponent<Animator>().enabled = true;
                }


				if (Input.GetKeyDown (KeyCode.Alpha1)) {
					RotateObjects [0] = Cubes [0];
					RotateObjects [1] = Cubes [1];
					RotateObjects [2] = Cubes [2];
					RotateObjects [3] = Cubes [3];
					RotateObjects [0].SetParent (RotateParent.transform);
					RotateObjects [1].SetParent (RotateParent.transform);
					RotateObjects [2].SetParent (RotateParent.transform);
					RotateObjects [3].SetParent (RotateParent.transform);
					Axis = 3;
					Rotate = true;
					Transform Cube = Cubes [3];
					Cubes [3] = Cubes [2];
					Cubes [2] = Cubes [1];
					Cubes [1] = Cubes [0];
					Cubes [0] = Cube;
				} else {

					if (Input.GetKeyDown (KeyCode.Alpha2)) {
						RotateObjects [0] = Cubes [4];
						RotateObjects [1] = Cubes [5];
						RotateObjects [2] = Cubes [6];
						RotateObjects [3] = Cubes [7];
						RotateObjects [0].SetParent (RotateParent.transform);
						RotateObjects [1].SetParent (RotateParent.transform);
						RotateObjects [2].SetParent (RotateParent.transform);
						RotateObjects [3].SetParent (RotateParent.transform);

						Axis = 3;
						Rotate = true;

						Transform Cube = Cubes [7];
						Cubes [7] = Cubes [6];
						Cubes [6] = Cubes [5];
						Cubes [5] = Cubes [4];
						Cubes [4] = Cube;
					} else {

						if (Input.GetKeyDown (KeyCode.Alpha3)) {
							RotateObjects [0] = Cubes [1];
							RotateObjects [1] = Cubes [2];
							RotateObjects [2] = Cubes [5];
							RotateObjects [3] = Cubes [6];
							RotateObjects [0].SetParent (RotateParent.transform);
							RotateObjects [1].SetParent (RotateParent.transform);
							RotateObjects [2].SetParent (RotateParent.transform);
							RotateObjects [3].SetParent (RotateParent.transform);
							Axis = 1;
							Rotate = true;


							Transform Cube = Cubes [5];
							Cubes [5] = Cubes [6];
							Cubes [6] = Cubes [2];
							Cubes [2] = Cubes [1];
							Cubes [1] = Cube;
						} else {

							if (Input.GetKeyDown (KeyCode.Alpha4)) {
								RotateObjects [0] = Cubes [3];
								RotateObjects [1] = Cubes [4];
								RotateObjects [2] = Cubes [7];
								RotateObjects [3] = Cubes [0];
								RotateObjects [0].SetParent (RotateParent.transform);
								RotateObjects [1].SetParent (RotateParent.transform);
								RotateObjects [2].SetParent (RotateParent.transform);
								RotateObjects [3].SetParent (RotateParent.transform);
								Axis = 1;
								Rotate = true;


								Transform Cube = Cubes [3];
								Cubes [3] = Cubes [0];
								Cubes [0] = Cubes [4];
								Cubes [4] = Cubes [7];
								Cubes [7] = Cube;
							} else {


								if (Input.GetKeyDown (KeyCode.Alpha5)) {
									RotateObjects [0] = Cubes [0];
									RotateObjects [1] = Cubes [4];
									RotateObjects [2] = Cubes [5];
									RotateObjects [3] = Cubes [1];
									RotateObjects [0].SetParent (RotateParent.transform);
									RotateObjects [1].SetParent (RotateParent.transform);
									RotateObjects [2].SetParent (RotateParent.transform);
									RotateObjects [3].SetParent (RotateParent.transform);
									Axis = 2;
									Rotate = true;


									Transform Cube = Cubes [1];
									Cubes [1] = Cubes [5];
									Cubes [5] = Cubes [4];
									Cubes [4] = Cubes [0];
									Cubes [0] = Cube;
								} else {


									if (Input.GetKeyDown (KeyCode.Alpha6)) {
										RotateObjects [0] = Cubes [3];
										RotateObjects [1] = Cubes [7];
										RotateObjects [2] = Cubes [6];
										RotateObjects [3] = Cubes [2];
										RotateObjects [0].SetParent (RotateParent.transform);
										RotateObjects [1].SetParent (RotateParent.transform);
										RotateObjects [2].SetParent (RotateParent.transform);
										RotateObjects [3].SetParent (RotateParent.transform);
										Axis = 2;
										Rotate = true;


										Transform Cube = Cubes [2];
										Cubes [2] = Cubes [6];
										Cubes [6] = Cubes [7];
										Cubes [7] = Cubes [3];
										Cubes [3] = Cube;
									}
								}
							}
						}
					}
				}
            }
            else
            {
                if (RotateParent.eulerAngles.x != 90 && Axis == 1)
                {
                    if (Mathf.Abs(90 - RotateParent.eulerAngles.x) > RotateSpeed * Time.deltaTime)
                    {
                        RotateParent.eulerAngles += new Vector3(RotateSpeed * Time.deltaTime, 0, 0);
                    }
                    else
                        RotateParent.eulerAngles = new Vector3(90, 0, 0);
                }
                else
                {
                    if (RotateParent.eulerAngles.y != 90 && Axis == 2)
                    {
                        if (Mathf.Abs(90 - RotateParent.eulerAngles.y) > RotateSpeed * Time.deltaTime)
                        {
                            RotateParent.eulerAngles += new Vector3(0, RotateSpeed * Time.deltaTime, 0);
                        }
                        else
                            RotateParent.eulerAngles = new Vector3(0, 90, 0);
                    }
                    else
                    {

                        if (RotateParent.eulerAngles.z != 90 && Axis == 3)
                        {
                            if (Mathf.Abs(90 - RotateParent.eulerAngles.z) > RotateSpeed * Time.deltaTime)
                            {
                                RotateParent.eulerAngles += new Vector3(0, 0, RotateSpeed * Time.deltaTime);
                            }
                            else
                                RotateParent.eulerAngles = new Vector3(0, 0, 90);
                        }
                        else
                        {
                            Rotate = false;
                            for (int i = 0; i < RotateObjects.Length; i++)
                            {
                                RotateObjects[i].parent = this.transform;
                            }
                            RotateParent.eulerAngles = new Vector3(0, 0, 0);
                        }
                    }
                }
            }
        }else
        {
        }
    }

}
