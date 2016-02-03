using UnityEngine;
using System.Collections;

public class GoBackToMainMenu : MonoBehaviour {

	private Vector3 center = new Vector3(0,0,0);
	private float timer = 0;
	private bool activateTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	void CheckTouch()
	{
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				activateTimer = true;
				timer = 0;
				GameObject.Find ("Main Camera").GetComponent<MenuCameraMovement> ().MoveCamera (center);
			}
		} else
		if (Input.GetMouseButton (0)) {
			Vector3 wp0 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touchPos0 = new Vector2 (wp0.x, wp0.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos0)) {
				activateTimer = true;
				timer = 0;
				GameObject.Find ("Main Camera").GetComponent<MenuCameraMovement> ().MoveCamera (center);
			}
		}
	}

	void ActivateMenu() {
		activateTimer = false;
		timer = 0;
		GameObject.Find ("Quit").GetComponent<QuitGame> ().SetMenuLock (false);
	}

	void Update()
	{
		CheckTouch ();
		if (activateTimer)
			timer += Time.deltaTime;
		if (timer > 1)
			ActivateMenu ();
	}
}
