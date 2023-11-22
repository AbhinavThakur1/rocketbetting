using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartUpDown : MonoBehaviour
{
    [SerializeField] Transform rocket;
    [SerializeField] TMP_Text amount;

    void Update()
    {
        amount.text = Brain.amount.ToString();
        if (rocket.gameObject.activeSelf)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, rocket.position.y, transform.position.z), 0.2f * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -0.23f, transform.position.z);
        }
    }
}
