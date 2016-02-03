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
        ShowAd();
    }
}