using UnityEngine;
using System.Collections;

public class ObstacleDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Photon").transform.position.y - 15 > transform.position.y)
            Destroy(gameObject);
	}
}
