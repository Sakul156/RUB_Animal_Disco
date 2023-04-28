using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_lights : MonoBehaviour
{
    [SerializeField] GameObject lightsParent;
    [SerializeField] GameObject discoLight;
    private Vector3 camPos;
    private float camHeight;
    private float camWidth;

    private void Awake()
    {
        camHeight = 2 * Camera.main.orthographicSize;
        camWidth = 2 * Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        getCameraposition();
        spawnNewLight();
    }

    private void getCameraposition()
    {
        camPos.x = transform.position.x - camWidth/2;
        camPos.y = transform.position.y - camHeight/2;
    }

    private void spawnNewLight()
    {
        float randomX = Random.Range(0.05f, 0.95f);
        float randomY = Random.Range(0.05f, 0.95f);
       
        Vector3 spawnPoint = new Vector3(camPos.x + camWidth * randomX, camPos.y + camHeight * randomY, 0);

        if(Input.GetKeyDown(KeyCode.F))
        {
            GameObject newObject = Instantiate(discoLight, spawnPoint, Quaternion.identity);
            newObject.transform.SetParent(lightsParent.transform);
        }
    }
}
