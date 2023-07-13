using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Hole : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite warningHole;

    Emu emuMechanics;
    [SerializeField] GameObject emu;

    //private float duration = 2f;
    public bool warning = false;
    public bool flash = false;
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
            //Show(startPos, endPos
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
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
                    playwarningsound();
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
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }

        public void playwarningsound()
        {
            StartCoroutine(warningsound());
        }

         IEnumerator warningsound()
         {
            beep.Play();
            yield return new WaitForSeconds(beep.clip.length + 0.3f);
            gameObject.GetComponent<Collider2D>().enabled = false;
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
        /*Debug.Log(emuMechanics.appear);*/

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
