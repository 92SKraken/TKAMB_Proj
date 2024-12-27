using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPC_Interact : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canvas;
    bool player_dectection = false;

    public string Line1;
    public string Line2;
    public string Line3;

    public PlayerMovement PlayerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            player_dectection = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player_dectection = false;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if(player_dectection && context.performed && !PlayerMovement.dialogue)
        {
            canvas.SetActive(true);
            PlayerMovement.dialogue = true;
            NewDialogue(Line1);
            NewDialogue(Line2);
            NewDialogue(Line3);
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
