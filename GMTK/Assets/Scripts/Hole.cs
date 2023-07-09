using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite hole1;
    [SerializeField] private Sprite hole2;
    [SerializeField] private Sprite warningHole1;
    [SerializeField] private Sprite warningHole2;

    Emu emuMechanics;
    [SerializeField] GameObject emu;

    private float duration = 1.5f;
    private bool warning = false;
    private float warningRate = 1f;

    public enum HoleType { Normal, Warning };
    private HoleType holeType;

    private void OnMouseDown()
    {
        if (!emuMechanics.appear)
        {
            emuMechanics.appear = true;
            if (warning)
            {
                warning = false;
                holeType = HoleType.Normal;
            }
            //Show(startPos, endPos);
        }
        else
        {
            emuMechanics.appear = false;
            //Hide(startPos, endPos);
        }
    }
    void Awake()
    {
        emuMechanics = emu.GetComponent<Emu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
