using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NextDialogue : MonoBehaviour
{
    int index = 2;
    public PlayerMovement PlayerMovement;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Advance(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (PlayerMovement.dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if (transform.childCount == index)
                {
                    index = 2;
                    PlayerMovement.dialogue = false;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
