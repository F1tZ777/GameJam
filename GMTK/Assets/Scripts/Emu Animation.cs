using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmuAnimation : MonoBehaviour
{
    [SerializeField] private Sprite emu;
    public float animationTime;

    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Click");
            TweenUp();
        }
    }

    private void TweenUp()
    {
        LeanTween.moveLocalY(gameObject, 0.17f, animationTime);
    }
}
