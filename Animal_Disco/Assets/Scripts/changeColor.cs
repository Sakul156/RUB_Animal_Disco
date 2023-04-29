using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    private cheatCodes cc;
    private SpriteRenderer sr;
    private GameObject discoLights;
    private List<SpriteRenderer> allSr = new List<SpriteRenderer>();
    public bool isRed = false;

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
        while (true)
        {
            if (cc.isSquidgame)
            {
                // Switch between red and green
                foreach (SpriteRenderer s in allSr)
                {
                    s.color = Color.red;
                    isRed = true;
                }
                yield return new WaitForSeconds(2); 
                foreach (SpriteRenderer s in allSr)
                {
                    s.color = Color.green;
                    isRed = false;
                }
                yield return new WaitForSeconds(3); 
            }
            else
            {
                // Change colors randomly
                foreach (SpriteRenderer s in allSr)
                {
                    s.color = Random.ColorHSV();
                }
                yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            }
        }
    }
}