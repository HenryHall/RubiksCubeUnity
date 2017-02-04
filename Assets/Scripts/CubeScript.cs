using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	public GameObject Cube1, Cube2, Cube3, Cube4, Cube5, Cube6, Cube7, Cube8, Cube9, Cube10, Cube11, Cube12, Cube13, Cube14, Cube15, Cube16, Cube17, Cube18, Cube19, Cube20, Cube21, Cube22, Cube23, Cube24, Cube25, Cube26, Cube27;
	public float RotationSpeed = 360.0f;  //How fast the cube will rotate
	public int MouseMovementThreashhold = 1;  //How much movement from the mouse will trigger the cube to rotate
	public GameObject RubeCubeObject;  //Physical unity object
	public GameObject Selector;  //Visual unity selector around cube

	public string defaultAxis = "x";  //X axis
	public int defaultIndex = 1;  //Middle index

	GameObject newRotation;  //A temporary object to hold the cubes that will be rotated
	GameObject[,,] RubeCube;  //An array to hold the data for cube positions



	// Use this for initialization
	void Start () {
		RubeCube = new GameObject[3, 3, 3] { { {Cube1, Cube10, Cube19}, {Cube4, Cube13, Cube22}, {Cube7, Cube16, Cube25} }, { {Cube2, Cube11, Cube20}, {Cube5, Cube14, Cube23}, {Cube8, Cube17, Cube26} }, { {Cube3, Cube12, Cube21}, {Cube6, Cube15, Cube24}, {Cube9, Cube18, Cube27} } };
	}


	private void Update () {

		//Rotation Input:  rotation takes in: axis(x, y, or z), index(row/column), and rotation direction(based on keydown)
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
			// Selector.transform.Rotate ( new Vector3 (), Space.Self);
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

		GameObject[,,] tempCube = (GameObject[,,])RubeCube.Clone();

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {

				switch (axis) {
					case "x":
						RubeCube [index, i, j].transform.parent = newRotation.transform;

						if (direction == -1) {
							tempCube [index, i, j] = RubeCube [index, 2-j, i];
						} else if (direction == 1) {
							tempCube [index, i, j] = RubeCube [index, j, 2-i];
						}


						break;
					case "y":
						RubeCube [i, index, j].transform.parent = newRotation.transform;

						if (direction == -1) {
							tempCube [i, index, j] = RubeCube [j, index, 2-i];
						} else if (direction == 1) {
							tempCube [i, index, j] = RubeCube [2-j, index, i];
						}

						break;

					case "z":
						RubeCube [i, j, index].transform.parent = newRotation.transform;

						if (direction == -1) {
							tempCube [i, j, index] = RubeCube [j, 2-i, index];
						} else if (direction == 1) {
							tempCube [i, j, index] = RubeCube [2-j, i, index];
						}

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

		//Reset the parent
		foreach (GameObject cube in RubeCube) {
			cube.transform.parent = RubeCubeObject.transform;
		}

		Destroy (newRotation);

		//Update the RubeCube array with the new rotations on tempCube
		RubeCube = tempCube;
	}

}
