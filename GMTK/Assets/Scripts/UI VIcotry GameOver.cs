using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIVIcotryGameOver : MonoBehaviour
{
    [SerializeField] Button _return;
    public Animator transition;
    public float transitiontime;
    public AudioSource UIsfx;

    // Start is called before the first frame update
    void Start()
    {
        _return.onClick.AddListener(mainmenu);
    }

    private void mainmenu()
    {
        StartCoroutine(backmainmenu());
    }
    IEnumerator backmainmenu()
    {
        UIsfx.Play();
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        DontDestroyMusic.instance.GetComponent<AudioSource>().Play();
        SceneManager.Instance.LoadMainMenu();
    }

}
