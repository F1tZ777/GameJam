using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static EmuMechanics;

public class Emu : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite emu;
    [SerializeField] private Sprite emuHit;

    Hole holeMechanics;
    [SerializeField] GameObject hole;

    public bool appear = false;
    public bool hit = false;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        holeMechanics = hole.GetComponent<Hole>();
    }

    // Emu movement
    private Vector2 startPos = new Vector2(-0.49f, -0.52f);
    private Vector2 endPos = new Vector2(-0.49f, 0.17f);

    private float showDuration = 0.5f;
    private float duration = 1.5f;

    private void ShowHide()
    {
        if (appear) 
        {
            transform.localPosition = endPos;
        }

        else if (!appear)
        {
            transform.localPosition = startPos;
        }
    }
    /*private void Show()
    {
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        transform.localPosition = endPos;
        appear = true;
    }

    private void Hide()
    {
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPos;
        appear = false;
    }*/

    /*private void OnMouseDown()
    {
        if (!appear)
        {
            appear = true;
            if (warning)
            {
                warning = false;
                holeType = HoleType.Normal;
            }
            Show(startPos, endPos);
        }
        else
        {
            appear = false;
            Hide(startPos, endPos);
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        ShowHide();
        //Debug.Log(appear);
    }
}
