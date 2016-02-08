using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	void Action()
	{
        int coefIndex = GetComponent<PhotonMovement>().coefIndex;
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.DownArrow)) && coefIndex > 1) 
				GetComponent<PhotonMovement>().RegisterChange(coefIndex - 1);
        if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.UpArrow)) && coefIndex < 6)
            GetComponent<PhotonMovement>().RegisterChange(coefIndex + 1);
    }

	// Update is called once per frame
	void Update () {
		Action ();
	}
}
