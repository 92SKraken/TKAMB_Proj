using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBush : MonoBehaviour
{
    [SerializeField] private Transform bush;
    bool player_detection = false;
    bool bushMoved = false;

    public GameObject dillSpeechReady;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
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
        if(context.performed && player_detection)
        {
            bush.Translate(Vector2.right * 1200 * Time.deltaTime);
            dillSpeechReady.SetActive(true);
        }
    }
}
