using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    private SpriteRenderer sr;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(colorChange());
    }

    private IEnumerator colorChange()
    {
        while (true)
        {
            sr.color = Random.ColorHSV();
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }

}
