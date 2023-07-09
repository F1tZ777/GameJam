using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static EmuMechanics;

public class Emu : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite emu;
    [SerializeField] private Sprite emuHit;

    Hole holeMechanics;
    [SerializeField] GameObject hole;

    [SerializeField] private GameManager gameManager;

    public bool appear = false;
    public bool hit = false;
    public bool soundown = false;
    public bool soundup = false;
    public bool points = false;
    public bool pointincrease = false;
    private float scoreBuffer = 1f;
    private SpriteRenderer spriteRenderer;
    private float animationTimeUp = 0.3f;
    private float animationTimeDown = 0.1f;
    public GameObject FloatingTextPrefab;
    public AudioSource gothit, gainpoints, moveup, movedown;
  
    void Awake()
    {
        holeMechanics = hole.GetComponent<Hole>();
    }

    // Emu movement
    private Vector2 startPos = new Vector2(-0.49f, -0.64f);
    private Vector2 endPos = new Vector2(-0.49f, 0.17f);

    private float showDuration = 0.5f;
    private float duration = 0.5f;

    private void ShowHide()
    {
        if (appear) 
        {
            LeanTween.moveLocalY(gameObject, 0.17f, animationTimeUp);
            StartCoroutine(AddScore());
            if (!soundup )
            {
                moveup.Play();
                soundup = true;
                soundown = false;
            }
        }

        else if (!appear)
        {
            StopCoroutine(AddScore());
            LeanTween.moveLocalY(gameObject, -0.52f, animationTimeDown);
            if (!soundown)
            {
                movedown.Play();
                soundown = true;
                soundup = false;
            }
            
        }

    }

    public IEnumerator Death()
    {
        if (holeMechanics.warning)
        {
            StopCoroutine(AddScore());
            //Debug.Log("Death is running");
            yield return new WaitForSeconds(duration);
            if (appear)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = emuHit;
                yield return new WaitForSeconds(0.1f);
                gothit.Play();
                transform.localPosition = startPos;
                hit = false;
                appear = false;
                gameManager.lives -= 1;
                gameManager.score -= 30f;
                yield return new WaitForSeconds(0.4f);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = emu;
            }
        }
    }

    public IEnumerator AddScore()
    {
        yield return new WaitForSeconds(scoreBuffer);
        gainpoints.Play();
        gameManager.score += 1f * Time.fixedDeltaTime;
    }

    public void StopGame()
    {
        StopAllCoroutines();
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

        holeMechanics.Warning();
    }
}
