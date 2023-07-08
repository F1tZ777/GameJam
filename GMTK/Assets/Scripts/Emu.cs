using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emu : MonoBehaviour
{
    /* This was used during the demo for normal Whack-A-Mole
    private Vector2 startPos = new Vector2(0f, -1.28f);
    private Vector2 endPos = Vector2.zero;

    private float showDuration = 0.5f;
    private float duration = 1.5f;

    
    private IEnumerator ShowHide(Vector2 start, Vector2 end)
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

        yield return new WaitForSeconds(duration);

        elapsed = 0f;
        while(elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = start;
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
