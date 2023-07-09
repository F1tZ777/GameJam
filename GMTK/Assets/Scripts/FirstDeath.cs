using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDeath : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.lives <= 2)
        {
            Destroy(gameObject);
        }
    }
}
