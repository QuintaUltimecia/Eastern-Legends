using System;
using System.Net.Http;
using UnityEngine;
using UnityEngine.iOS;

public class WebviewController : MonoBehaviour
{
    public static WebviewController instance;
    public int Times;

    [SerializeField] 
    private UniWebView webView;

    [SerializeField]
    private string _policy = "https://google.com";

    private const string KEY_URL_LINK = "url_link";

    private float _width;
    private float _height;

    private ScreenOrientation _defaultOrientation;

    private bool _isInitialized = false;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (_isInitialized) return;
        _isInitialized = true;

        instance = this;

        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            _width = Screen.width;
            _height = Screen.height;
        }
        else
        {
            _width = Screen.height;
            _height = Screen.width;
        }

        _defaultOrientation = Screen.orientation;
    }

    public void GetAppRate()
    {
        Device.RequestStoreReview();
    }

    public void ShowPolicy()
    {
        Initialize();

        //Screen.orientation = ScreenOrientation.AutoRotation;

        webView.Frame = GetCurrentResolutionWithOffset(Screen.orientation);

        webView.Load(_policy);
        webView.Show();
        UniWebView.SetJavaScriptEnabled(true);

        webView.OnPageFinished += (view, statusCode, url) =>
        {
            if (statusCode == 200)
            {
                CheckSite(url);
            }
        };

        webView.OnOrientationChanged += (view, orientation) =>
        {
            webView.Frame = GetCurrentResolutionWithOffset(orientation);
        };

        webView.OnShouldClose += (view) =>
        {
            return false;
        };
    }

    public void DefindAndOpen()
    {
        //PlayerPrefs.SetString("End", "True");
        //PlayerPrefs.Save();

        //string url;

        //if (PlayerPrefs.HasKey("CacheU"))
        //    url = PlayerPrefs.GetString("CacheU");
        //else
        //    url = FirebaseInitializer.instance.GetStringByKey(KEY_URL_LINK);

        //OpenWebView(url);
    }

    public void CloseWebview()
    {
        Screen.orientation = _defaultOrientation;
        webView.Hide();
    }

    public void OpenWebView(string Url)
    {
        Initialize();

        PlayerPrefs.SetString("WasShowed", "1");
        PlayerPrefs.Save();
        Screen.orientation = ScreenOrientation.AutoRotation;

        webView.SetSupportMultipleWindows(true, true);
        webView.SetContentInsetAdjustmentBehavior(UniWebViewContentInsetAdjustmentBehavior.Always);
        webView.Load(Url);
        webView.Show();
        webView.Frame = GetCurrentResolution(Screen.orientation);

        UniWebView.SetJavaScriptEnabled(true);

        webView.OnPageFinished += (view, statusCode, url) =>
        {
            if (statusCode == 200)
            {
                CheckSite(url);
            }
        };

        webView.OnOrientationChanged += (view, orientation) =>
        {
            webView.Frame = GetCurrentResolution(orientation);
        };

        webView.OnShouldClose += (view) =>
        {
            return false;
        };
    }

    public async void CheckSite(string url)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        request.RequestUri = new Uri(url);

        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    PlayerPrefs.SetString("CacheU", url);
                    PlayerPrefs.Save();
                }
            }
        }
        catch
        {
            Debug.Log($"Url not cached: {url}");
        }
    }

    private Rect GetCurrentResolution(ScreenOrientation orientation)
    {
        switch (orientation) 
        {
            case ScreenOrientation.Portrait:
                return new Rect(0, 0, _height, _width);

            case ScreenOrientation.PortraitUpsideDown:
                return new Rect(0, 0, _height, _width);

            case ScreenOrientation.LandscapeLeft:
                return new Rect(0, 0, _width, _height);

            case ScreenOrientation.LandscapeRight:
                return new Rect(0, 0, _width, _height);

            default:
                return new Rect(0, 0, _width, _height);
        }        
    }

    private Rect GetCurrentResolutionWithOffset(ScreenOrientation orientation)
    {
        float offset = 200;

        switch (orientation)
        {
            case ScreenOrientation.Portrait:
                return new Rect(0, offset, _height, _width - offset);

            case ScreenOrientation.PortraitUpsideDown:
                return new Rect(0, 0, _height, _width - offset);

            case ScreenOrientation.LandscapeLeft:
                return new Rect(offset, 0, _width - offset, _height);

            case ScreenOrientation.LandscapeRight:
                return new Rect(0, 0, _width - offset, _height);

            default:
                return new Rect(0, 0, _width - offset, _height);
        }
    }
}
