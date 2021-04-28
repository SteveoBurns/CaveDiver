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
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {   
        //Updates score based on players x position
        score = Mathf.RoundToInt(player.transform.position.x);
        scoreText.text = "Score: " + score;
    }
}
