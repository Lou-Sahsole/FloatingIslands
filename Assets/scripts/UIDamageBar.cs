using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDamageBar : MonoBehaviour
{
    public static UIDamageBar instance { get; private set; }

    public Image mask;
    float originalSize;

    void Awake()
    {
        originalSize = mask.rectTransform.rect.width;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        instance = this;
    }

    //void Start()
    //{
    //    originalSize = mask.rectTransform.rect.width;
    //}

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
        Debug.Log(originalSize);
    }
}
