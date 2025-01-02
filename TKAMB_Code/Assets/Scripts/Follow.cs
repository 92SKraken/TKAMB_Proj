using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    float dis;

    public bool canFollow = false;

    // Update is called once per frame
    void Update()
    {
        dis = Vector2.Distance(transform.position, target.transform.position);

        if (dis >= 2 && canFollow)
        { 
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 5 * Time.deltaTime);
        }
    }
}
