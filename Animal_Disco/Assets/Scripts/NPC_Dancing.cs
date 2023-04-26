using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dancing : MonoBehaviour
{
    private cheatCodes cc;
    private int danceMove;
    private int timeRandomizer;
    private int moveRandomizer;
    private bool isDancing = false;
    void Update()
    {
        if(isDancing == false)
        {
            StartCoroutine(Randomizer());
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

        isDancing = false;
    }
}
