using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public Text scoreTxt;
    private int score;
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        scoreTxt.text = score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("coin"))
        {

            score += 1;
        }
    }
}
