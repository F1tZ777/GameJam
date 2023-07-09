using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIAnimation : MonoBehaviour
{
    private float animationtime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, Vector3.one, animationtime);
    }
}