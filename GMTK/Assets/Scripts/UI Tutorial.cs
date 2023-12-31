using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class UITutorial : MonoBehaviour
{
    [SerializeField] Button _back;
    public Animator transition;
    public float transitiontime;
    public AudioSource UIsfx;
    private bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        _back.onClick.AddListener(Back);
    }

    private void Back()
    {
        StartCoroutine(mainmenu());
    }

    IEnumerator mainmenu()
    {
        if(!pressed) 
        { 
            UIsfx.Play();
            pressed = true;
        }
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.Instance.LoadMainMenu();
    }

}
