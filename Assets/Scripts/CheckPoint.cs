using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public int score;
    public int combo;
    public bool comboDrain;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI comboDrainText;
    public bool isReady = false; // isTrigger Collider
    public float comboTimer;

    private void Start()
    {
        score = 0;
        combo = 1;
        comboDrain = false;
        comboTimer = 10;
        scoreText.text = score.ToString();
        comboText.text = score.ToString();
    }

    private void Update()
    {
        ScoreCombo();
    }

    private void ScoreCombo()
    {
        if (isReady == true && Input.GetKeyDown(KeyCode.Space))
        {
            combo += 1;
            score += 1 * combo;
            Debug.Log("Score: " + score);
            isReady = false;

            scoreText.text = score.ToString();
            comboText.text = combo.ToString();
        }
        else if (isReady == false && Input.GetKeyDown(KeyCode.Space))
        {
            score -= 1;
            combo = 1;
            Debug.Log("Score: " + score);
            isReady = false;

            scoreText.text = score.ToString();
            comboText.text = combo.ToString();
        }

        if (comboDrain)
        {
            comboDrain = false;
            combo = 1;
            comboText.text = combo.ToString();
        }
    }

    private void ComboDrain()
    {
        
    }

    //private IEnumerator ComboDrain()
    //{
    //    for (int i = 0; i <= 10; i++)
    //    {
    //        comboDrainText.text = i.ToString();
    //        yield return new WaitForSeconds(1);
    //    }

    //    comboDrain = true;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isReady = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isReady = false;
        }
    }
}
