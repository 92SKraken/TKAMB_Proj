using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NextDialogue : MonoBehaviour
{
    int index = 1;
    int count = 0;
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
                count += 1;
                if (transform.childCount == index)
                {
                    index = 1;
                    PlayerMovement.dialogue = false;
                    for (int i = 1; i <= count; i++)
                    {
                        Destroy(transform.GetChild(i).gameObject);
                    }
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
