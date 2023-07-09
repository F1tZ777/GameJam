using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button _play, _tutorial, _quit;
    public Animator transition;
    public float transitiontime;
    public AudioSource UIsfx, quitsfx;
    // Start is called before the first frame update
    void Start()
    {
        _play.onClick.AddListener(NewGame);
        _tutorial.onClick.AddListener(Tutorial);
        _quit.onClick.AddListener(Exit); 
    }

    private void NewGame()
    {
        StartCoroutine(game());
    }
    
    private void Tutorial()
    {
        StartCoroutine(tutorial());
    }

    private void Exit()
    {
        StartCoroutine(quit());
    }

    IEnumerator game()
    {
        UIsfx.Play();
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.Instance.LoadGame();
    }

    IEnumerator tutorial()
    {
        UIsfx.Play();
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.Instance.LoadTutorial();
    }

    IEnumerator quit()
    {
        quitsfx.Play();
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        Application.Quit();
    }
}
