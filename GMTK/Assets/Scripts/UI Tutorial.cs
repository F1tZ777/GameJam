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
    // Start is called before the first frame update
    void Start()
    {
        _back.onClick.AddListener(Back);
    }

    private void Back()
    {
        StartCoroutine(mainmenu());
    }

    IEnumerator mainmenu()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.Instance.LoadMainMenu();
    }

}
