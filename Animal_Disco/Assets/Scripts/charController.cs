using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    private cheatCodes cc;
    private SpriteRenderer sr;
    private int playerSpeed = 6;
    private bool isDancing = false;
    private float waveSpeed = 2f; // Speed of the wave movement
    private float waveHeight = 0.2f; // Height of the wave movement
    private float waveOffset = 0f; // Offset of the wave movement

    private void Awake()
    {
        cc = GetComponent<cheatCodes>();
        sr = GetComponent<SpriteRenderer>();
    }
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
        if(cc.isNinja)
        {
            Color color = sr.color;
            playerSpeed = 3;
            color.a = 0.5f;
            sr.color = color;
        }

        else
        {
            Color color = sr.color;
            playerSpeed = 3;
            color.a = 1f;
            sr.color = color;
            playerSpeed = 6;
            
        }

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

        while(cc.isDrunk)
        {
            // Calculate the vertical wave movement
            float verticalOffset = Mathf.Sin(Time.time * waveSpeed + waveOffset) * waveHeight;

            // Update the player's position with the wavy movement
            transform.position = new Vector3(transform.position.x, transform.position.y + verticalOffset, transform.position.z);
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

            isDancing = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isDancing = true;

            // Save original color and disable disco lights
            Color originalColor = Camera.main.backgroundColor;
         

            // Set background color to black
            Camera.main.backgroundColor = Color.black;

            // Rotate player 360 degrees over 3 seconds
            float duration = 3f;
            float timeElapsed = 0f;
            Quaternion startRotation = transform.rotation;
            while (timeElapsed < duration)
            {
                float angle = Mathf.Lerp(0, 360, timeElapsed / duration);
                transform.rotation = startRotation * Quaternion.AngleAxis(angle, Vector3.forward);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Scale player up to 2x size over 2 seconds
            duration = 2f;
            timeElapsed = 0f;
            Vector3 originalScale = transform.localScale;
            Vector3 targetScale = originalScale * 2f;
            while (timeElapsed < duration)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScale, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Rotate player 720 degrees over 4 seconds
            duration = 4f;
            timeElapsed = 0f;
            startRotation = transform.rotation;
            while (timeElapsed < duration)
            {
                float angle = Mathf.Lerp(0, 720, timeElapsed / duration);
                transform.rotation = startRotation * Quaternion.AngleAxis(angle, Vector3.forward);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Scale player back down to original size over 2 seconds
            duration = 2f;
            timeElapsed = 0f;
            while (timeElapsed < duration)
            {
                transform.localScale = Vector3.Lerp(targetScale, originalScale, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Reset background color and disco lights
            Camera.main.backgroundColor = originalColor;
           

            // Set isDancing flag to false
            isDancing = false;
        }
    }
}
