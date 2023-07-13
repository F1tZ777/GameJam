using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EmuMechanics : MonoBehaviour
{

    [Header("Graphics")]
    [SerializeField] private Sprite hole1;
    [SerializeField] private Sprite hole2;
    [SerializeField] private Sprite warningHole1;
    [SerializeField] private Sprite warningHole2;
    [SerializeField] private Sprite emu;
    [SerializeField] private Sprite emuHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Emu movement
    private Vector2 startPos = new Vector2(0f, -1.28f);
    private Vector2 endPos = Vector2.zero;

    private float showDuration = 0.5f;
    private float duration = 2f;

    
    private IEnumerator Show(Vector2 start, Vector2 end)
    {
        transform.localPosition = start;

        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;
        appear = true;
    }

    private IEnumerator Hide(Vector2 start, Vector2 end)
    {
        float elapsed = 0f;
        while(elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = start;
        appear = false;
    }

    // Emu Hit
    private SpriteRenderer spriteRenderer;
    private bool warning = false;
    private bool appear = false;
    private bool hit = false;
    private float warningRate = 1f;

    public enum HoleType { Normal, Warning };
    private HoleType holeType;
    public enum EmuType { Normal, Hit };
    private EmuType emuType;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
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
    }

    private IEnumerator Warning()
    {
        if (appear)
        {
            float random = Random.Range(0f, 20f);
            if (random <= warningRate)
            {
                warning = true;
                holeType = HoleType.Warning;

                yield return new WaitForSeconds(duration);
                if (warning)
                {
                    emuType = EmuType.Hit;
                    hit = true;
                    QuickHide();
                }
            }
        }
    }

    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.5f);
        if (hit)
        {
            transform.localPosition = startPos;
            hit = false;
            warning = false;
            appear = false;
            
        }
    }
     
}
