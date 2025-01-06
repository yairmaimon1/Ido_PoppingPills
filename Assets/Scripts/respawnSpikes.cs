using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnSpikes : MonoBehaviour
{
    public static float SpikesSpeed = 3.0f;
    [SerializeField] GameObject Spike;
    GameObject Player;
    GameObject FirstSpike;
    GameObject SecondSpike;
    Camera cam;

    float spawnY;
    float spawnX;

    bool DidntPass = true;

    private void Start()
    {
        cam = Camera.main.GetComponent<Camera>();

        Player = GameObject.Find("Player");

        //Set this shit up - randomized y location for the spikes with apropriating distances
        spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, -100)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, 100)).y);
        spawnX = transform.position.x;
        FirstSpike = Instantiate(Spike, new Vector2(spawnX, spawnY), Quaternion.identity);
        FirstSpike.transform.parent = gameObject.transform;
        SecondSpike = Instantiate(Spike, new Vector2(FirstSpike.transform.position.x, FirstSpike.transform.position.y + 100), Quaternion.Euler(180f, 0f, 0f));
        SecondSpike.transform.parent = gameObject.transform;
    }
    void Update()
    {
        if(transform.position.x < Player.transform.position.x && DidntPass)
        {
            Score.score++;
            DidntPass = false;
        }
        transform.position -= transform.right * SpikesSpeed * Time.deltaTime; //+ new Vector3(spawnSpikes.spikesSpawned, 0f, 0f);
        if (cam.WorldToScreenPoint(transform.position).x < -5)
        {
            //reached the left edge of the screen
            StartCoroutine("Respawn", spawnSpikes.spikesSpawned);
        }
    }

    IEnumerator Respawn(int alreadySpawned)
    {
        yield return new WaitForSeconds(2.5f);
        transform.position = new Vector2(125f, transform.position.y);
        FirstSpike.transform.position = new Vector2(transform.position.x, Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, -50-(50/ Mathf.Pow(alreadySpawned, 0.1f)))).y, Camera.main.ScreenToWorldPoint(new Vector2(0, 100)).y));
        SecondSpike.transform.position = new Vector2(FirstSpike.transform.position.x, FirstSpike.transform.position.y + 75 + (25 / Mathf.Pow(alreadySpawned, 0.1f)));
        Debug.Log(75 + (25 / Mathf.Pow(alreadySpawned, 0.1f)));
        spawnSpikes.spikesSpawned++;
        DidntPass = true;
    }
}
