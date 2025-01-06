using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;

    [SerializeField] private GameObject ScoreEndScreen;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
        ScoreEndScreen.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString() + " Vitamin Coins earned!";
    }
}
