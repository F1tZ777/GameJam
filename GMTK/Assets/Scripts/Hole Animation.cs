using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleAnimation : MonoBehaviour
{
    [SerializeField] private GameObject hole;
    private float animationtime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0,0,0);
        LeanTween.scale(gameObject, Vector3.one, animationtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
