using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image image = null;

    public void OnClickButtonDown()
    {
        AndroidPlugin.Instance.ShowGallery(GetImage);
    }

    private void GetImage()
    {
        image.sprite = AndroidPlugin.Instance._sprite;
    }
}
