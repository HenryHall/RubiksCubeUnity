using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	public GameObject Cube1, Cube2, Cube3, Cube4, Cube5, Cube6, Cube7, Cube8, Cube9, Cube10, Cube11, Cube12, Cube13, Cube14, Cube15, Cube16, Cube17, Cube18, Cube19, Cube20, Cube21, Cube22, Cube23, Cube24, Cube25, Cube26, Cube27;
	public float RotationSpeed = 360.0f;
	public int MouseMovementThreashhold = 1;
	public GameObject RubeCubeObject;
	public GameObject Selector;

	public string defaultAxis = "x";
	public int defaultIndex = 1;

	GameObject newRotation;


	// Use this for initialization
	void Start () {

	}


	private void Update () {

		//Rotation Input
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			rotation(defaultAxis, defaultIndex, -1);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rotation(defaultAxis, defaultIndex, 1);
		}


		//Axis Input
		if (Input.GetKeyDown (KeyCode.Z)) {
			toggleAxis ();
		}


		//Index Input
		if (Input.GetKeyDown (KeyCode.X)) {
			toggleIndex ();
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


	void toggleAxis () {

		switch (defaultAxis) {
		case "x":
			defaultAxis = "y";
			break;
		case "y":
			defaultAxis = "z";
			break;
		case "z":
			defaultAxis = "x";
			break;

		}

	}


	void toggleIndex () {

		switch (defaultIndex) {
		case 0:
			defaultIndex = 1;
			break;
		case 1:
			defaultIndex = 2;
			break;
		case 2:
			defaultIndex = 0;
			break;

		}

	}


	void rotation (string axis, int index, int direction) {

		float rotationDirection = 90.0f * direction;

		newRotation = new GameObject ("What does this do?");
		newRotation.transform.rotation = RubeCubeObject.transform.rotation;

		GameObject[,,] RubeCube = new GameObject[3, 3, 3] { { {Cube1, Cube10, Cube19}, {Cube4, Cube13, Cube22}, {Cube7, Cube16, Cube25} }, { {Cube2, Cube11, Cube20}, {Cube5, Cube14, Cube23}, {Cube8, Cube17, Cube26} }, { {Cube3, Cube12, Cube21}, {Cube6, Cube15, Cube24}, {Cube9, Cube18, Cube27} } };

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {

				switch (axis) {
					case "x":
						RubeCube [index, i, j].transform.parent = newRotation.transform;
						break;
					case "y":
						RubeCube [i, index, j].transform.parent = newRotation.transform;
						break;
					case "z":
						RubeCube [i, j, index].transform.parent = newRotation.transform;
						break;
				}

			}
		}

		switch (axis) {
		case "x":
			newRotation.transform.Rotate (new Vector3(rotationDirection, 0, 0), Space.Self);
			break;
		case "y":
			newRotation.transform.Rotate (new Vector3(0, rotationDirection, 0), Space.Self);
			break;
		case "z":
			newRotation.transform.Rotate (new Vector3(0, 0, rotationDirection), Space.Self);
			break;
		}


		foreach (GameObject cube in RubeCube) {
			cube.transform.parent = RubeCubeObject.transform;
		}
		
		Destroy (newRotation);

	}
	

}


