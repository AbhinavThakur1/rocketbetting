using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketmove : MonoBehaviour
{
    public Vector3 startposition = new Vector3(-0.9f, -0.18f, 0f);
    bool up;

    void Update()
    {
        if (transform.position.x <= 1.1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(1.2f, 0.6f, 0f), 0.2f * Time.deltaTime);
        }
        else if (transform.position.x >= 1.1)
        {
            if (transform.position.y >=  0.6f)
            {
                up = false;
            }
            else if (transform.position.y <= 0.3f)
            {
                up = true;
            }
            if (up)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(1.2f, 0.7f, 0f), 0.3f * Time.deltaTime);
            }
            else if (!up)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(1.2f, 0.2f, 0f), 0.3f * Time.deltaTime);
            }
        }
    }
}
