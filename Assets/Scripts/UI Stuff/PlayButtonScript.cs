using UnityEngine;
using System.Collections;

public class TestCameraLerp : MonoBehaviour {

	public GameObject mainCamera;
	public Vector3 dest = new Vector3(20, 20, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
			mainCamera.GetComponent<MenuCameraMovement> ().MoveCamera (dest);
	}
}
