using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI scoreText;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;

    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > score)
        {
            score = Mathf.RoundToInt(player.transform.position.x);
            scoreText.text = "Score: " + score;
        }
    }
}
