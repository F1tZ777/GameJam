using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public GameObject BG;

    // Start is called before the first frame update
    void Start()
    {
        ScreenCrendtials();
    }

    public void ScreenCrendtials()
    {
        var height = Camera.main.orthographicSize * 2;
        var width = height * Screen.width / Screen.height;
        var backg = BG.GetComponent<SpriteRenderer>().sprite;
        var unitWidth = backg.textureRect.width / backg.pixelsPerUnit;
        var unitHeight = backg.textureRect.height / backg.pixelsPerUnit;
        BG.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(width / unitWidth, height / unitHeight);

    }
}
