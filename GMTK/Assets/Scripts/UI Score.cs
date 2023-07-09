using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = CentralScoreScript.finalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
