using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPC_Interact : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canvas;
    bool player_detection = false;

    public int NumberOfLines;

    public string Line1;
    public string Line2;
    public string Line3;
    public string Line4;
    public string Line5;
    public string Line6;
    public string Line7;
    public string Line8;
    public string Line9;

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
        if(player_detection && context.performed && !PlayerMovement.dialogue)
        {
            canvas.SetActive(true);
            PlayerMovement.dialogue = true;
            if (NumberOfLines >= 1)
            {
                NewDialogue(Line1);
            }
            if (NumberOfLines >= 2)
            {
                NewDialogue(Line2);
            }
            if (NumberOfLines >= 3)
            {
                NewDialogue(Line3);
            }
            if (NumberOfLines >= 4)
            {
                NewDialogue(Line4);
            }
            if (NumberOfLines >= 5)
            {
                NewDialogue(Line5);
            }
            if (NumberOfLines >= 6)
            {
                NewDialogue(Line6);
            }
            if (NumberOfLines >= 7)
            {
                NewDialogue(Line7);
            }
            if (NumberOfLines >= 8)
            {
                NewDialogue(Line8);
            }
            if (NumberOfLines >= 9)
            {
                NewDialogue(Line9);
            }
            canvas.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canvas.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }
}
