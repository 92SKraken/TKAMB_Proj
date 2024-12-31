using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpeech : MonoBehaviour
{
    public GameObject speechReady;
    public string characterName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == characterName)
        {
            speechReady.SetActive(true);
        }
    }
}
