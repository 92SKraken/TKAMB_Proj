using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRadleyHouse : MonoBehaviour
{
    public Follow follow;
    public GameObject jem;
    public GameObject canvas;

    private GameObject child = null;

    public bool canTouch = false;
    public bool onDialogue = false;

    // Update is called once per frame
    void Update()
    {
        if (canvas.transform.childCount == 9)
        {
            child = canvas.transform.GetChild(6).gameObject;
            if (child.activeInHierarchy && onDialogue)
            {
                canTouch = true;
                onDialogue = false;
            }
        }
        if (canTouch)
        {
            follow.canFollow = false;
            jem.transform.position = Vector2.MoveTowards(jem.transform.position, transform.position, 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Jem")
        {
            child = null;
            canTouch = false;
            follow.canFollow = true;
        }
    }
}
