using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dancing : MonoBehaviour
{
    private cheatCodes cc;
    private SpriteRenderer sr;
    private changeColor ch;
    private Sprite normalSprite;
    [SerializeField] Sprite dogeSprite;
    private int danceMove;
    private int timeRandomizer;
    private int moveRandomizer;
    public bool isDancing = false;
    private bool startedDancing = false;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        ch = GameObject.Find("light").GetComponent<changeColor>();
        cc = GameObject.Find("player").GetComponent<cheatCodes>();
        normalSprite = sr.sprite;
    }

    void Update()
    {
        Color c = sr.color;
        if (!cc.isSquidgame)
        {
            c.a = 1f;
            sr.color = c;
        }

        if (cc.isDoge)
        {
            sr.sprite = dogeSprite;
        }

        else
        {
            sr.sprite = normalSprite;
        }

        if(isDancing == false)
        {
            StartCoroutine(Randomizer());
        }

        if(ch.isRed && startedDancing)
        {
            c.a = 0f;
            sr.color = c;
        }
    }

    IEnumerator Randomizer()
    {
        isDancing = true;
        timeRandomizer = Random.Range(2, 5);
        moveRandomizer = Random.Range(1, 100);
        if (moveRandomizer <= 50)
        {
            danceMove = 1;
        }
        else
        {
            danceMove = 2;
        }

        yield return new WaitForSeconds(timeRandomizer);
        StartCoroutine(startDancing(danceMove));
    }
  
    IEnumerator startDancing(int danceMove)
    {
        startedDancing = true;
        if (danceMove == 1)
        {
            transform.Rotate(Vector3.forward * 90);
            yield return new WaitForSeconds(0.5f);
            
            transform.Rotate(Vector3.forward * 90);
            yield return new WaitForSeconds(0.5f);
            
            transform.Rotate(Vector3.forward * 90);
            yield return new WaitForSeconds(0.5f);
        
            transform.Rotate(Vector3.forward * 90);
        }
        else if(danceMove == 2)
        {
            // Scale up to double size
            Vector3 originalScale = transform.localScale;
            Vector3 targetScale = originalScale * 2f;
            float duration = 0.5f;
            float timeElapsed = 0f;
            while (timeElapsed < duration)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScale, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Scale back to original size
            timeElapsed = 0f;
            while (timeElapsed < duration)
            {
                transform.localScale = Vector3.Lerp(targetScale, originalScale, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }

        isDancing = false;
        startedDancing = false;
    }
}
