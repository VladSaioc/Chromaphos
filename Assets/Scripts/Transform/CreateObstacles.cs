using UnityEngine;
using System.Collections;

public class CreateObstacles : MonoBehaviour {

	public string[] obstacles;
	
	// Use this for initialization
	void Start () {
		InstantiateObstacles();
	}

	void InstantiateObstacles() {
		if (obstacles.Length > 0) {
			for(int i = 0; i < obstacles.Length; i++) {
				if(int.Parse (obstacles[i]) > 0) {
					Vector3 position = new Vector3(0, 60 + i * 3f, 0);
					Quaternion noRotation = new Quaternion(0, 0, 0, 0);
					Instantiate(Resources.Load("Gravity "+obstacles[i]), position, noRotation);
				}
				else if(int.Parse (obstacles[i]) < 0) {
					Vector3 position = new Vector3(0, 60 + i * 3f, 0);
					Quaternion noRotation = new Quaternion(0, 0, 0, 0);
					Instantiate(Resources.Load("Dark Energy Band "+obstacles[i].TrimStart('-')), position, noRotation);
				}
			}					      
		}					                            
	}
}
