using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] private GameObject[] grounds;
    GameObject Ground1;
    GameObject Ground2;
    public static float GroundSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        Ground1 = Instantiate(grounds[0], new Vector2(transform.position.x, 36.7f), Quaternion.identity);
        Ground1.transform.parent = gameObject.transform;
        Ground2 = Instantiate(grounds[0], new Vector2(227f, 36.7f), Quaternion.identity);
        Ground2.transform.parent = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {

        Ground1.transform.position += new Vector3(-GroundSpeed, 0f, 0f) * Time.deltaTime;
        Ground2.transform.position += new Vector3(-GroundSpeed, 0f, 0f) * Time.deltaTime;

        if (Ground1.transform.position.x <= -227f)
        {
            Ground1.transform.position = new Vector2(227f, 36.7f);
        }

        if (Ground2.transform.position.x <= -227f)
        {
            Ground2.transform.position = new Vector2(227f, 36.7f);
        }
    }
}
