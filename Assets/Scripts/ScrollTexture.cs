using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTexture : MonoBehaviour
{
    public RawImage rawImage;
    public Vector2 scrollSpeed = new Vector2(0.1f, 0f);

    private Vector2 offset;

    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        rawImage.uvRect = new Rect(offset, rawImage.uvRect.size);
    }
}