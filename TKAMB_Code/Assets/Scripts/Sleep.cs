using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sleep : MonoBehaviour
{
    public GameObject mainCamera;
    bool canEnter = false;
    public bool canSleep = false;
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
        if (canEnter && context.performed && canSleep)
        {
            mainCamera.GetComponent<CameraFade>().readyToFade = true;
            GameObject.Find("School").transform.GetChild(0).GetComponent<SchoolDoorInteractions>().slept = true;
            GameObject.Find("Jem").transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
