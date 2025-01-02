using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPC_Interact : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canvas;
    public GameObject speechReady;

    bool player_detection = false;

    public int NumberOfLines;
    public int NumberOfLines1;

    public string Line1;
    public string Line2;
    public string Line3;
    public string Line4;
    public string Line5;
    public string Line6;
    public string Line7;
    public string Line8;
    public string Line9;

    public string Line11;
    public string Line21;
    public string Line31;
    public string Line41;
    public string Line51;
    public string Line61;
    public string Line71;
    public string Line81;
    public string Line91;

    public string speaker1;
    public string speaker2;

    public int speakerSwitch = 100;

    int count = 1;

    public PlayerMovement PlayerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player_detection = false;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if(player_detection && context.performed && !PlayerMovement.dialogue && speechReady.activeInHierarchy && count == 1)
        {
            speechReady.SetActive(false);
            canvas.SetActive(true);
            PlayerMovement.dialogue = true;
            if (NumberOfLines >= 1)
            {
                NewDialogue(Line1, speaker1);
            }
            if (NumberOfLines >= 2)
            {
                if (speakerSwitch <= 2)
                {
                    NewDialogue(Line2, speaker2);
                }
                else
                {
                    NewDialogue(Line2, speaker1);
                }
            }
            if (NumberOfLines >= 3)
            {
                if (speakerSwitch <= 3)
                {
                    NewDialogue(Line3, speaker2);
                }
                else
                {
                    NewDialogue(Line3, speaker1);
                }
            }
            if (NumberOfLines >= 4)
            {
                if (speakerSwitch <= 4)
                {
                    NewDialogue(Line4, speaker2);
                }
                else
                {
                    NewDialogue(Line4, speaker1);
                }
            }
            if (NumberOfLines >= 5)
            {
                if (speakerSwitch <= 5)
                {
                    NewDialogue(Line5, speaker2);
                }
                else
                {
                    NewDialogue(Line5, speaker1);
                }
            }
            if (NumberOfLines >= 6)
            {
                if (speakerSwitch <= 6)
                {
                    NewDialogue(Line6, speaker2);
                }
                else
                {
                    NewDialogue(Line6, speaker1);
                }
            }
            if (NumberOfLines >= 7)
            {
                if (speakerSwitch <= 7)
                {
                    NewDialogue(Line7, speaker2);
                }
                else
                {
                    NewDialogue(Line7, speaker1);
                }
            }
            if (NumberOfLines >= 8)
            {
                if (speakerSwitch <= 8)
                {
                    NewDialogue(Line8, speaker2);
                }
                else
                {
                    NewDialogue(Line8, speaker1);
                }
            }
            if (NumberOfLines >= 9)
            {
                if (speakerSwitch <= 9)
                {
                    NewDialogue(Line9, speaker2);
                }
                else
                {
                    NewDialogue(Line9, speaker1);
                }
            }
            count++;
            canvas.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (player_detection && context.performed && !PlayerMovement.dialogue && speechReady.activeInHierarchy && count == 2)
        {
            speechReady.SetActive(false);
            canvas.SetActive(true);
            PlayerMovement.dialogue = true;
            if (NumberOfLines1 >= 1)
            {
                NewDialogue(Line11, speaker1);
            }
            if (NumberOfLines1 >= 2)
            {
                if (speakerSwitch <= 2)
                {
                    NewDialogue(Line21, speaker2);
                }
                else
                {
                    NewDialogue(Line21, speaker1);
                }
            }
            if (NumberOfLines1 >= 3)
            {
                if (speakerSwitch <= 3)
                {
                    NewDialogue(Line31, speaker2);
                }
                else
                {
                    NewDialogue(Line31, speaker1);
                }
            }
            if (NumberOfLines1 >= 4)
            {
                if (speakerSwitch <= 4)
                {
                    NewDialogue(Line41, speaker2);
                }
                else
                {
                    NewDialogue(Line41, speaker1);
                }
            }
            if (NumberOfLines1 >= 5)
            {
                if (speakerSwitch <= 5)
                {
                    NewDialogue(Line51, speaker2);
                }
                else
                {
                    NewDialogue(Line51, speaker1);
                }
            }
            if (NumberOfLines1 >= 6)
            {
                if (speakerSwitch <= 6)
                {
                    NewDialogue(Line61, speaker2);
                }
                else
                {
                    NewDialogue(Line61, speaker1);
                }
            }
            if (NumberOfLines1 >= 7)
            {
                if (speakerSwitch <= 7)
                {
                    NewDialogue(Line71, speaker2);
                }
                else
                {
                    NewDialogue(Line71, speaker1);
                }
            }
            if (NumberOfLines1 >= 8)
            {
                if (speakerSwitch <= 8)
                {
                    NewDialogue(Line81, speaker2);
                }
                else
                {
                    NewDialogue(Line81, speaker1);
                }
            }
            if (NumberOfLines1 >= 9)
            {
                if (speakerSwitch <= 9)
                {
                    NewDialogue(Line91, speaker2);
                }
                else
                {
                    NewDialogue(Line91, speaker1);
                }
            }
            count++;
            canvas.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void NewDialogue(string text, string speaker)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canvas.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        template_clone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = speaker;
    }
}
