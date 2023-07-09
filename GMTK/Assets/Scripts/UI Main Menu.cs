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
    // Start is called before the first frame update
    void Start()
    {
        _play.onClick.AddListener(NewGame);
        _tutorial.onClick.AddListener(Tutorial);
        _quit.onClick.AddListener(Exit); 
    }

    private void NewGame()
    {
        StartCoroutine(Loadgame());
    }
    
    private void Tutorial()
    {
        SceneManager.Instance.LoadTutorial();
    }

    private void Exit()
    {
        Application.Quit();
    }

    IEnumerator Loadgame()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.Instance.LoadGame();
    }
}
