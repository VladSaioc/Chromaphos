using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{

    void CheckTouch()
    {
        if (Input.touchCount >= 1)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                PlayerPrefs.SetFloat("PlayLevelReturn", 1);
                SceneManager.LoadScene("Menu");
            }
        }
        else
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp0 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchPos0 = new Vector2(wp0.x, wp0.y);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos0))
            {
                PlayerPrefs.SetFloat("PlayLevelReturn", 1);
                SceneManager.LoadScene("Menu");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
    }
}
