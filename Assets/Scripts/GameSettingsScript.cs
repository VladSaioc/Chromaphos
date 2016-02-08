using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSettingsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            if (PlayerPrefs.GetFloat("GameSpeed") != 0)
                Time.timeScale = PlayerPrefs.GetFloat("GameSpeed");
            else
                Time.timeScale = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!SceneManager.GetActiveScene().name.Equals("Menu"))
            {
                PlayerPrefs.SetFloat("PlayLevelReturn", 1);
                SceneManager.LoadScene("Menu");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
