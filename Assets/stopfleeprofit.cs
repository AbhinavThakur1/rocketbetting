using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class stopfleeprofit : MonoBehaviour
{

    [SerializeField] TMP_Text multiatbuttons;
    [SerializeField] TMP_Text multicashout;
    [SerializeField] TMP_Text profit;
    [SerializeField] TMP_Text Sprofit;
    [SerializeField] Slider profitSlider;

    [SerializeField] TMP_Text loss;
    [SerializeField] TMP_Text Sloss;
    [SerializeField] Slider lossSlider;

    [SerializeField] GameObject profitonoff;
    [SerializeField] GameObject lossonoff;
    [SerializeField] GameObject buttonsonoff;

    public static int lossvaluelimit;
    public static int profitvaluelimit;

    public void pbuttons()
    {
        profitonoff.SetActive(false);
    }

    private void Update()
    {
        Sprofit.text = profitSlider.value.ToString() + "%";
        Sloss.text = lossSlider.value.ToString() + "%";
        if (profitvaluelimit > 0)
        {
            if (ButtonHandler.amountonauto + ((ButtonHandler.amountonauto * profitvaluelimit) / 100) <= Brain.amount)
            {
                Brain.auto = false;
            }
        }
        if(lossvaluelimit > 0)
        {
            if(ButtonHandler.amountonauto - ((ButtonHandler.amountonauto * lossvaluelimit) / 100) >= Brain.amount)
            {
                Brain.auto = false;
            }
        }        
    }

    public void lbuttons()
    {
        lossonoff.SetActive(false);
    }

    public void xbuttons()
    {
        buttonsonoff.SetActive(false);
        if (multiatbuttons.text[0] == '.')
        {
            multiatbuttons.text = "0" + multiatbuttons.text;
            multicashout.text = "0" + multicashout.text;
        }
        if(multiatbuttons.text[multiatbuttons.text.Length-1] == '.')
        {
            multiatbuttons.text = multiatbuttons.text + "0";
            multicashout.text = multicashout.text + "0";
        }
        if (!multiatbuttons.text.Contains("."))
        {
            multiatbuttons.text = multiatbuttons.text + ".00";
            multicashout.text = multicashout.text + ".00";
        }
    }

    public void profitclicked()
    {

        profitonoff.SetActive(true);
        lossonoff.SetActive(false);
    }

    public void lossclicked()
    {
        lossonoff.SetActive(true);
        profitonoff.SetActive(false);
    }

    public void buttonsOn()
    {
        buttonsonoff.SetActive(true);
    }

    public void profitsure()
    {
        profit.text = profitSlider.value.ToString() + "%";
        profitvaluelimit = (int)profitSlider.value;
        profitonoff.SetActive(false);
    }

    public void losssure()
    {
        loss.text = lossSlider.value.ToString() + "%";
        lossvaluelimit = (int)lossSlider.value;
        lossonoff.SetActive(false);
    }

}
