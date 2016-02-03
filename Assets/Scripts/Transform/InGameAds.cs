using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class InGameAds : MonoBehaviour {

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    void Start()
    {
        int number = PlayerPrefs.GetInt("AdCounter");
        if (number >= 4)
        {
            ShowAd();
            number = 1;
        }
        else
        {
            number++;
        }
        PlayerPrefs.SetInt("AdCounter", number);
    }
}
