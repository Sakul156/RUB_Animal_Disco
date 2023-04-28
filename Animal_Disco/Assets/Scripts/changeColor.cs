using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    private cheatCodes cc;
    private SpriteRenderer sr;
    private GameObject discoLights;
    private List<SpriteRenderer> allSr = new List<SpriteRenderer>();
    private bool greenActive = false;

    void Awake()
    {
        cc = GameObject.Find("player").GetComponent<cheatCodes>();
        discoLights = GameObject.Find("DiscoLights");
        sr = GetComponent<SpriteRenderer>();
        allSr.AddRange(discoLights.GetComponentsInChildren<SpriteRenderer>());
        StartCoroutine(colorChange());
    }

    public IEnumerator colorChange()
    {
        while (!cc.isSquidgame)
        {
            sr.color = Random.ColorHSV();
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }

    
}
