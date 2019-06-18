using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdController : MonoBehaviour
{
    private BannerView bannerView;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        this.RequestBanner();

    }

    private void RequestBanner()
    {
            #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-9566929645426734/1128202273";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

}
