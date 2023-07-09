using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    public enum Scene
    {
        MainMenu,
        Tutorial,
        GameScreen,
        Victory,
        GameOver
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.GameScreen.ToString());    
    }

    public void LoadTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.Tutorial.ToString());
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadVictory()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.Victory.ToString());
    }
    public void LoadGameOver()
     {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.GameOver.ToString());
    }
}
