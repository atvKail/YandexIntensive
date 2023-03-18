using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEqualToResolution : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
