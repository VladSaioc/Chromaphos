using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
	
	private bool startTimer;
	private float t;
	public float fadeTimer;
	private bool MenuLock;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		MenuLock = false;
	}

	public void SetMenuLock(bool locked) {
		MenuLock = locked;
	}

	
	public bool GetMenuLock() {
		return MenuLock;
	}
	
	void CheckTouch()
	{
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				Application.Quit();
			}
		}
	}

	void FadeIn()
	{
		startTimer = false;
		t = 0;
		foreach(MenuColorChange obj in GetComponentsInChildren<MenuColorChange>())
		{
			obj.check = false;
		}
	}
	
	void FadeOut()
	{
		startTimer = true;
		t = 0;
		foreach(MenuColorChange obj in GetComponentsInChildren<MenuColorChange>())
		{
			obj.ChangeColor();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!MenuLock) CheckTouch ();
		t += Time.deltaTime;
		if (t > fadeTimer && startTimer)
			FadeIn ();
		if (t > fadeTimer && !startTimer)
			FadeOut ();
	}
}
