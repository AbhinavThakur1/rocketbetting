using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class multivalue : MonoBehaviour
{
    [SerializeField] TMP_Text multi;
    public void set()
    {
        multi.text = Math.Round(FindAnyObjectByType<Brain>().mutliplyvalueobj,2).ToString() + "x-";
    }
}
