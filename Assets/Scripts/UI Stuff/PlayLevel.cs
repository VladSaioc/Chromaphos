using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevel : MonoBehaviour {

	public string levelNumber;
	private bool highlighted;
	private float duration;

	// Use this for initialization
	void Start () {
		highlighted = false;
	}

	public bool GetHighlight() {
		return highlighted;
	}



	void CheckTouch()
	{	
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				//if(highlighted && duration > 1)
					SceneManager.LoadScene(levelNumber);
				//else {
				//	highlighted = true;
				//}
			}
			//else highlighted = false;
		}
		else if(Input.GetMouseButton (0)) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				//if(highlighted && duration > 1)
					SceneManager.LoadScene(levelNumber);
				//else highlighted = true;
			}
			//else highlighted = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		CheckTouch ();
		if (highlighted)
			duration += Time.deltaTime;
		else
			duration = 0;
	}
}
