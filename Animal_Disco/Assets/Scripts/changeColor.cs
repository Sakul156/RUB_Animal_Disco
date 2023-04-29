using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    private cheatCodes cc;
    private SpriteRenderer sr;
    private GameObject discoLights;
    private List<SpriteRenderer> allSr = new List<SpriteRenderer>();
    private bool isRed = false;

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
        bool isChangingColor = false; // flag to keep track of whether a color change is currently happening

        while (true)
        {
            if (cc.isSquidgame)
            {
                if (!isChangingColor)
                {
                    isChangingColor = true;

                    if (isRed)
                    {
                        // switch to green
                        foreach (SpriteRenderer s in allSr)
                        {
                            s.color = Color.green;
                        }
                        isRed = false;
                    }
                    else
                    {
                        // switch to red
                        foreach (SpriteRenderer s in allSr)
                        {
                            s.color = Color.red;
                        }
                        isRed = true;

                        // destroy NPCs that start a new dance while red
                        //foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
                        //{
                          //  dance npcDance = npc.GetComponent<dance>();
                   //         if (npcDance != null && npcDance.isStartingDance)
                     //       {
                       //         StartCoroutine(DestroyAfterDelay(npc));
                         //   }
               //         }
                    }

                    yield return new WaitForSeconds(4f); // wait for color to stay for 1 second
                    isChangingColor = false; // allow color to change again
                }
            }
            else
            {
                sr.color = Random.ColorHSV();
                yield return new WaitForSeconds(Random.Range(2f, 4f));
            }
        }
    }
}