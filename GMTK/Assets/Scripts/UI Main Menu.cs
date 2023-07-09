using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button _play, _tutorial, _quit;
    // Start is called before the first frame update
    void Start()
    {
        _play.onClick.AddListener(NewGame);
        _tutorial.onClick.AddListener(Tutorial);
        _quit.onClick.AddListener(Exit); 
    }

    private void NewGame()
    {
        SceneManager.Instance.LoadGame();
    }
    
    private void Tutorial()
    {
        SceneManager.Instance.LoadTutorial();
    }

    private void Exit()
    {
        Application.Quit();
    }
}
