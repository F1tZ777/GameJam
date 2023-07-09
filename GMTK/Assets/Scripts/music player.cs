using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicClass : MonoBehaviour
{
    public AudioSource music;
    
    void Start()
    {
        music.Play();
    }

    private void Update()
    {
        string nextscene = UnityEngine.SceneManagement.SceneManager.GetSceneByName("GameScreen").ToString();
        string sceneName = nextscene;

        if(nextscene == "GameScreen")
        {
            music.Stop();
        }

    }
}
