using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int score;

    public bool isReady = false;


    private void Update()
    {
        if(isReady == true && Input.GetKeyDown(KeyCode.Space))
        {
            score += 1;
            Debug.Log("Score = " + score);

            isReady = false;
        }
    }

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
