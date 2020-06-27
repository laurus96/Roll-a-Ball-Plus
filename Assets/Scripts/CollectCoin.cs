using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{
    public static int score { get; set; }
    public static int bestScore { get; set; }
    public Text scoreText;


    private string previousText = "";


    private float seconds = 0f;

    private void Start()
    {
        score = 10;
        bestScore = score;
        previousText = scoreText.text;
    }

    private void LateUpdate()
    {
        seconds += 1;
        StartCoroutine(ScoreDecrease(seconds));

        scoreText.text = previousText + " " + score;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 10;
            if(bestScore < score)
            {
                bestScore = score;
            }
            Destroy(other.gameObject);
        }
    }

    IEnumerator ScoreDecrease(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        score -= 1;
    }
}
