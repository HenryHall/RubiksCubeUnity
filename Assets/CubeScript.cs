﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	public GameObject Cube1, Cube2, Cube3, Cube4, Cube5, Cube6, Cube7, Cube8, Cube9, Cube10, Cube11, Cube12, Cube13, Cube14, Cube15, Cube16, Cube17, Cube18, Cube19, Cube20, Cube21, Cube22, Cube23, Cube24, Cube25, Cube26, Cube27;
	public float RotationSpeed = 360.0f;
	public int MouseMovementThreashhold = 1;
	public GameObject RubeCubeObject;

	GameObject newRotation;


	// Use this for initialization
	void Start () {

	}


	private void Update () {


		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			leftRotation ();
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rightRotation ();
		}



		//Cube Movement aka Camera
		if(Input.GetAxis("Mouse X")<MouseMovementThreashhold) {
			//Moving Left
			RubeCubeObject.transform.Rotate(Vector3.up * Time.deltaTime * -Input.GetAxis("Mouse X") * RotationSpeed, Space.World);
		}

		if(Input.GetAxis("Mouse X")>-MouseMovementThreashhold) {
			//Moving Right
			RubeCubeObject.transform.Rotate(Vector3.down * Time.deltaTime * Input.GetAxis("Mouse X") * RotationSpeed, Space.World);
		}

		if(Input.GetAxis("Mouse Y")<MouseMovementThreashhold) {
			//Moving Down
			RubeCubeObject.transform.Rotate(Vector3.left * Time.deltaTime * -Input.GetAxis("Mouse Y") * RotationSpeed, Space.World);
		}

		if(Input.GetAxis("Mouse Y")>-MouseMovementThreashhold) {
			//Moving Up
			RubeCubeObject.transform.Rotate(Vector3.right * Time.deltaTime * Input.GetAxis("Mouse Y") * RotationSpeed, Space.World);
		}

	}


	void leftRotation () {

		newRotation = new GameObject ("What does this do?");
		newRotation.transform.rotation = RubeCubeObject.transform.rotation;

		GameObject[,,] RubeCube = new GameObject[3, 3, 3] { { {Cube1, Cube10, Cube19}, {Cube4, Cube13, Cube22}, {Cube7, Cube16, Cube25} }, { {Cube2, Cube11, Cube20}, {Cube5, Cube14, Cube23}, {Cube8, Cube17, Cube26} }, { {Cube3, Cube12, Cube21}, {Cube6, Cube15, Cube24}, {Cube9, Cube18, Cube27} } };

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				RubeCube [0, i, j].transform.parent = newRotation.transform;
			}
		}

		newRotation.transform.Rotate (new Vector3(-90, 0, 0), Space.Self);

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				RubeCube [0, i, j].transform.parent = RubeCubeObject.transform;
			}
		}

		Destroy (newRotation);

	}

	void rightRotation () {

		newRotation = new GameObject ("What does this do?");
		newRotation.transform.rotation = RubeCubeObject.transform.rotation;

		GameObject[,,] RubeCube = new GameObject[3, 3, 3] { { {Cube1, Cube10, Cube19}, {Cube4, Cube13, Cube22}, {Cube7, Cube16, Cube25} }, { {Cube2, Cube11, Cube20}, {Cube5, Cube14, Cube23}, {Cube8, Cube17, Cube26} }, { {Cube3, Cube12, Cube21}, {Cube6, Cube15, Cube24}, {Cube9, Cube18, Cube27} } };

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				RubeCube [0, i, j].transform.parent = newRotation.transform;
			}
		}

		newRotation.transform.Rotate (90, 0, 0);

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				RubeCube [0, i, j].transform.parent = RubeCubeObject.transform;
			}
		}

		Destroy (newRotation);

	}


	

}
