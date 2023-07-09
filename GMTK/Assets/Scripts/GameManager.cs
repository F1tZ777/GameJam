using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Emu> emus;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private float startingTime = 60f;

    private float timeRemaining;
    public int lives = 3;
    public float score = 0;
    private bool playing = false;

    public void Gaming()
    {
        timeRemaining = startingTime;
        score = 0f;
        scoreText.text = "0";
    }

    public void GameOver()
    {
        foreach (Emu emus in emus)
        {
            emus.StopGame();
        }
        playing = false;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        timeRemaining = startingTime;
        score = 0f;
        yield return new WaitForSeconds(1f);
        playing = true;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0 )
        {
            timeRemaining = 0;
            GameOver();
        }
        if (lives <= 0)
        {
            timeRemaining = 0;
            GameOver();
        }
        timeText.text = $"{(int)timeRemaining}";
        scoreText.text = $"{(int)score}";
    }
}
