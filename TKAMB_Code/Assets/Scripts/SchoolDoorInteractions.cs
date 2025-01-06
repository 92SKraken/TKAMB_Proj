using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SchoolDoorInteractions : MonoBehaviour
{
    bool canEnter = false;
    public bool slept = false;
    public bool inSchool = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            canEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canEnter = false;
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (canEnter && context.performed && slept && !inSchool)
        {
            SceneManager.LoadScene(sceneName: "School");
        }
        else if (canEnter && context.performed && inSchool)
        {
            slept = false;
            SceneManager.LoadScene(sceneName: "CunninghamAtHome");
        }
    }
}
