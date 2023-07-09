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
        Scene nextscene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        string sceneName = nextscene.name;

        if (nextscene.name == "GameScreen")
        {
            music.Stop();
        }
    }
}
