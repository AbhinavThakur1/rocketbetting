using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] TMP_Text chipamount;
    [SerializeField] Button manual;
    [SerializeField] Button auto;
    public static float amountonauto;

    private void Update()
    {
        if (Brain.auto)
        {
            auto.image.color = Color.Lerp(Color.yellow, Color.grey, 0.6f * Time.deltaTime);
            manual.image.color = Color.Lerp(Color.grey, Color.yellow, 0.6f * Time.deltaTime);
        }
        else
        {
            amountonauto = 0;
            auto.image.color = Color.Lerp(Color.gray, Color.yellow, 0.6f * Time.deltaTime);
            manual.image.color = Color.Lerp(Color.yellow, Color.grey, 0.6f * Time.deltaTime);
        }
    }

    public void ten()
    {
        chipamount.text = (int.Parse(chipamount.text.ToString()) + 10).ToString();
    }

    public void fifty()
    {
        chipamount.text = (int.Parse(chipamount.text.ToString()) + 50).ToString();
    }

    public void hundred()
    {
        chipamount.text = (int.Parse(chipamount.text.ToString()) + 100).ToString();
    }

    public void fivehundred()
    {
        chipamount.text = (int.Parse(chipamount.text.ToString()) + 500).ToString();
    }

    public void thousand()
    {
        chipamount.text = (int.Parse(chipamount.text.ToString()) + 1000).ToString();
    }

    public void fivethousand()
    {
        chipamount.text = (int.Parse(chipamount.text.ToString()) + 5000).ToString();
    }

    public void clear()
    {
        chipamount.text = 0.ToString();
    }

    public void Manual()
    {
        Brain.auto = false;
    }

    public void Auto()
    {
        amountonauto = Brain.amount;
        Brain.auto = true;
    }
}
