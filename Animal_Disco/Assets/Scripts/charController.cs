using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public GameObject player;
    private int playerSpeed = 6;
    private bool isDancing = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDancing)
        {
            danceMoves();
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

    private void danceMoves()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }
        
    }
}
