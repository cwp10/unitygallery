using UnityEngine;

public class AndroidPlugin : MonoBehaviour
{
    private static AndroidPlugin _instance = null;
    public static AndroidPlugin Instance
    {
        get 
        {
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    private AndroidJavaObject _unityActivity = null;
    private AndroidJavaObject _unityInstance= null;

    public delegate void OnImageLoad();
    private OnImageLoad _onImageLoad = null;

    public Sprite _sprite = null;

    public void ShowGallery(OnImageLoad onImageLoad)
    {
        this._onImageLoad = onImageLoad;
        _unityInstance.CallStatic("showGallery", _unityActivity);
    }

    private void Awake()
    {
        AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        _unityActivity = ajc.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass ajc2 = new AndroidJavaClass("com.empty.unityplugin.Media");
        _unityInstance = ajc2.CallStatic<AndroidJavaObject>("instance");

        _unityInstance.Call("setContext", _unityActivity);
    }

    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void GetImage(string path)
    {
        WWW www = new WWW("file://" + path);
        Sprite sprite = Sprite.Create(www.texture, new Rect(0f, 0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 100);
        _sprite = sprite;
        _onImageLoad();
        _onImageLoad = null;
    }
}
