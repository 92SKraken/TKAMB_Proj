using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpeech : MonoBehaviour
{
    public GameObject speechReady;
    public string characterName;
    int count = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == characterName && count == 0)
        {
            speechReady.SetActive(true);
            count++;
        }
    }
}
