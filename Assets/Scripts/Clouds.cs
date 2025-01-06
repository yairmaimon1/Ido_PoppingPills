using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;

    // Start is called before the first frame update
    void Start()
    {
        float spawnY;
        float spawnX;
        foreach (GameObject cloud in clouds)
        {
            for(int i = 0; i < 4; i++)
            {
                spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                GameObject newCloud = (GameObject)Instantiate(cloud, new Vector3(spawnX, spawnY, Random.Range(-1.0f, -5.0f)), Quaternion.identity);
                newCloud.transform.parent = gameObject.transform;
                newCloud.AddComponent<MoveClouds>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
