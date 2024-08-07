using System.Collections;
using UnityEngine;

public class WebViewBootstrap : MonoBehaviour
{
    [SerializeField] private UniWebView _webViewPrefab;
    [SerializeField] private string _url;

    [Header("Reachibility settings")]

    [SerializeField]private bool _useReachibility = true;
    [SerializeField][Min(0.01f)] private float _reachibilityWaitDellay = 1f;

    private UniWebView _webView;

    public UniWebView Boot()
    {
        UniWebView webView = FindObjectOfType<UniWebView>();

        if (webView == null)
        {
            webView = Instantiate(_webViewPrefab);
        }

        webView.SetBackButtonEnabled(false);

        _webView = webView;

        InitialiOrientation();

        if (_useReachibility == false)
        {
            LoadWebPage();
        }
        else
        {
            StartCoroutine(nameof(LoadWebViewWithReacibility));
        }

        return webView;
    }

    private IEnumerator LoadWebViewWithReacibility()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            yield return new WaitForSeconds(_reachibilityWaitDellay);
        }

        LoadWebPage();
    }

    private void LoadWebPage()
    {
        _webView.Load(_url);
        _webView.Show();
    }

    private void InitialiOrientation()
    {
        ApplyCurrentOrientation();

        _webView.OnOrientationChanged += (UniWebView view, ScreenOrientation orientation) => 
        {
            ApplyCurrentOrientation();
        };
    }

    private void ApplyCurrentOrientation()
    {
        _webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
    }
}