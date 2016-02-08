using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour
{
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    void Start()
    {
        int number = PlayerPrefs.GetInt("MenuAdCounter");
        if (number >= 3)
        {
            ShowAd();
            number = 1;
        }
        else
        {
            number++;
        }
        PlayerPrefs.SetInt("MenuAdCounter", number);
    }
}