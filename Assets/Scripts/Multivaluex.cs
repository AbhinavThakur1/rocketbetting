using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Multivaluex : MonoBehaviour
{
    [SerializeField] TMP_Text value;

    public void set(float multi)
    {
        value.text = Math.Round(multi,2).ToString() + "x"; 
    }
}
