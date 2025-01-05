using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EnterSchool : MonoBehaviour
{
    bool canEnter = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            canEnter = true;
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (canEnter && context.performed)
        {
            SceneManager.LoadScene(sceneName: "School");
        }
    }
}
