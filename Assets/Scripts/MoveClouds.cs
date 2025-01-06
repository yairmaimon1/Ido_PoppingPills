using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    [SerializeField] private float CloudsSpeed = 2.0f;
    Camera cam;

    private void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }
    void Update()
    {

        transform.position -= transform.right * CloudsSpeed * Time.deltaTime;
        if(cam.WorldToScreenPoint(transform.position).x < -10f)
        {
            //reached the left edge of the screen
            float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, Random.Range(0.2f, 0.8f), Random.Range(-10.0f, -1.0f)));
        }
    }
}
