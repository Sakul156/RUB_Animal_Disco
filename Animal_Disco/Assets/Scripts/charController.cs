using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    private cheatCodes cc;
    private int playerSpeed = 6;
    private bool isDancing = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDancing)
        {
            StartCoroutine(danceMoves());
            playerMovement();
        }
    }

    private void playerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1) * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0) * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1) * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0) * playerSpeed * Time.deltaTime;
        }
    }

    IEnumerator danceMoves()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            isDancing = true;

            transform.Rotate(Vector3.forward * 90);
            yield return new WaitForSeconds(0.5f);
            transform.Rotate(Vector3.forward * 90);

            yield return new WaitForSeconds(0.5f);
            transform.Rotate(Vector3.forward * 90);

            yield return new WaitForSeconds(0.5f);
            transform.Rotate(Vector3.forward * 90);

            isDancing = false;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            isDancing = true;


            //Dein wunderschöner sexy DanceMove

            isDancing = false;
        }
    }
}
