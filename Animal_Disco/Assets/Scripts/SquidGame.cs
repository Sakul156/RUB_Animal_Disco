using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidGame : MonoBehaviour
{
    private bool greenActive = false;
    private List<SpriteRenderer> allsr = new List<SpriteRenderer>();
    private cheatCodes cc;
    private changeColor[] ch;

    private void Awake()
    {
        cc = GameObject.Find("player").GetComponent<cheatCodes>();
        ch = GetComponentsInChildren<changeColor>();
        allsr.AddRange(GetComponentsInChildren<SpriteRenderer>());
        Debug.Log("Number of SpriteRenderers found: " + allsr.Count);
        Debug.Log("Number of changeColor components found: " + ch.Length);
        StartCoroutine(squidGame());

    }

    private IEnumerator squidGame()
    {
        while (cc.isSquidgame)
        {
            foreach (SpriteRenderer sr in allsr)
            {
                sr.color = Color.green;


                if (greenActive == false)
                {
                    sr.color = Color.green;
                    greenActive = true;

                }
                else
                {
                    sr.color = Color.red;
                    greenActive = false;

                }
            }
            yield return new WaitForSeconds(3);
        }

        foreach(changeColor ka in ch)
        {
            StartCoroutine(ka.colorChange());
        }
        

    }
}
