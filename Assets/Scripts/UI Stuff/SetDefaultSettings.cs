﻿using UnityEngine;
using System.Collections;

public class SetDefaultSettings : MonoBehaviour {
	
	private bool startTimer;
	private float t;
	public float fadeTimer;
	private bool highlighted;
	private float duration;

	// Use this for initialization
	void Start () {
	}

	public bool GetHighlight() {
		return highlighted;
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
	
	void CheckTouch()
	{		
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				if(highlighted && duration > 0.5f
				   && Input.GetTouch(0).phase == TouchPhase.Began)
					PlayerPrefs.DeleteAll();
				else {
					highlighted = true;
				}
			}
			else highlighted = false;
		}
		else 
		if (Input.GetMouseButtonDown (0)) {
			Vector3 wp0 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touchPos0 = new Vector2 (wp0.x, wp0.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos0)) {
				if(highlighted)
					PlayerPrefs.DeleteAll();
				else {
					highlighted = true;
				}
			}
			else highlighted = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if(!GameObject.Find("Quit").GetComponent<QuitGame>().GetMenuLock()) CheckTouch ();
		t += Time.deltaTime;
		if (t > fadeTimer && startTimer)
			FadeIn ();
		if (t > fadeTimer && !startTimer)
			FadeOut ();
		if (highlighted)
			duration += Time.deltaTime;
		else
			duration = 0;
		CheckTouch ();
	}
}