using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite warningHole;

    Emu emuMechanics;
    [SerializeField] GameObject emu;

    //private float duration = 2f;
    public bool warning = false;
    private float warningRate = 1f;
    private float random = 0f;

    public enum HoleType { Normal, Warning };
    private HoleType holeType;
    public AudioSource beep;

    private void OnMouseDown()
    {
        if (!emuMechanics.appear)
        {
            emuMechanics.appear = true;
            //Show(startPos, endPos);
        }
        else
        {
            emuMechanics.appear = false;
            //Hide(startPos, endPos);
        }
    }

    public void Warning()
    {
        if (emuMechanics.appear)
        {
            if (!warning)
            {
                if (random <= warningRate)
                {
                    warning = true;
                    StartCoroutine(emuMechanics.Death());
                }
            }
            /*else if (warning)
            {
                holeType = HoleType.Warning;

                yield return new WaitForSeconds(duration);
                emuMechanics.hit = true;
                emuMechanics.Death();
            }*/
        }

        if (!emuMechanics.appear)
        {
            warning = false;
            StopCoroutine(emuMechanics.Death());
        }
    }
    void Awake()
    {
        emuMechanics = emu.GetComponent<Emu>();
    }

    // Update is called once per frame
    void Update()
    {
        Warning();
        random = Random.Range(0f, 1000f);
        //Debug.Log(random);
        //Debug.Log(warning);
        Debug.Log(emuMechanics.appear);

        if (warning)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = warningHole;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hole;
        }
    }
}
