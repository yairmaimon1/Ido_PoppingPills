using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSpikes : MonoBehaviour
{
    public static int spikesSpawned = 1;

    [SerializeField] private GameObject Couples;
    int m_AmountDone = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartSpawn", 0f, 2.5f);
    }

    // Update is called once per frame
    void StartSpawn()
    {
        if(m_AmountDone < 5)
        {
            GameObject temp = Instantiate(Couples, new Vector2(125f, 0f), Quaternion.identity);
            temp.transform.parent = gameObject.transform;
            m_AmountDone++;
        }
        else
        {
            CancelInvoke();
        }
    }
}
