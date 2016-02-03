using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	public KeyCode[] speeds;

	// Use this for initialization
	void Start () {
	}

	void Action()
	{
		for(int i = 1; i < 8; i++){
			if(Input.GetKey(speeds[i]) && GetComponent<PhotonDeath>().alive == true)
			{

				GetComponent<PhotonMovement>().RegisterChange(i);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		Action ();
	}
}
