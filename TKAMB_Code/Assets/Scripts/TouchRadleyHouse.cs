using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRadleyHouse : MonoBehaviour
{
    public Follow follow;
    public GameObject jem;

    public bool canTouch = false;

    // Update is called once per frame
    void Update()
    {
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
            canTouch = false;
            follow.canFollow = true;
        }
    }
}
