using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Brain : MonoBehaviour
{
    [SerializeField] TMP_Text Moneygot; 
    [SerializeField] GameObject Autobetin;
    [SerializeField] TMP_Text autobetorbetting;
    [SerializeField] TMP_Text autobetstartstop;
    [SerializeField] GameObject mutliplaybarobject;
    [SerializeField] GameObject secondbarobject;
    [SerializeField] GameObject multivalueobject;
    [SerializeField] Transform mutliplaybarlocation;
    [SerializeField] Transform secondbarlocation;
    [SerializeField] Transform multilocationx;
    public static float amount = 10000;
    public int seconds = 5;
    public float mutliplyvalueobj = 1.80f;
    [SerializeField] TMP_Text MultitextPlane;
    [SerializeField] TMP_Text betamount;
    [SerializeField] GameObject BetIn;
    [SerializeField] GameObject cashOut;
    [SerializeField] TMP_Text cashoutat;
    [SerializeField] TMP_Text cashoutatnumbertyped;
    [SerializeField] GameObject profit;
    [SerializeField] GameObject loss;
    float timegoesby;
    public float mutliplyvalue;
    bool next = true;
    float betamountgiven;
    float multitime = 0f;
    float multiply;
    float value;
    bool start;
    bool betin;
    bool done = false;
    int clicked;
    public static bool auto;
    bool cashon;
    bool countin;
    int j;
    float k = 1.00f;
    float secondcount;
    int thesecondcount;
    bool m = true;
    int a = 0;
    [SerializeField] GameObject rocket;

    private void Start()
    {
        cashoutatnumbertyped.text = "1.00";
        cashoutat.text = "1.00";
    }
    void Update()
    {
        if (auto)
        {
            profit.SetActive(true);
            loss.SetActive(true);
        }else{
            profit.SetActive(false);
            loss.SetActive(false);
        }
        cashoutat.text = cashoutatnumbertyped.text;
        if (m)
        {
            for (int i = 0; i <= 10; i++)
            {
                GameObject l = Instantiate(multivalueobject, multilocationx);
                float rdn = UnityEngine.Random.Range(5f, 25f);
                l.GetComponent<Multivaluex>().set(rdn);
            }
            m = false;
        }
        if(int.Parse(betamount.text) > amount)
        {
            betamount.text = amount.ToString();
        }
        if(multiply >= k)
        {
            k += 0.20f;
            mutliplyvalueobj = float.Parse(Math.Round(mutliplyvalueobj + float.Parse("0.20"), 2).ToString());
            GameObject i = Instantiate(mutliplaybarobject, mutliplaybarlocation);
            i.GetComponent<multivalue>().set();
        }
        secondcount += Time.deltaTime; 
        timegoesby -= Time.deltaTime;
        if (countin)
        {
            int time = Mathf.FloorToInt(timegoesby % 60);
            MultitextPlane.text = "Starting";
            if (time >= 0 && time < 10)
            {
                MultitextPlane.text = "Starting in " + time.ToString();
            }
            else if (time > 10)
            {
                MultitextPlane.text = "Crashed";
            }
            if(time <= 0)
            {
                next = true;
                countin = false;
                secondcount = 0;
                multiply = 0;
            }
        }
        if (next)
        {
            a = 0;
            if(start)
            {
                cashOut.SetActive(true);
            }
            foreach (GameObject i in GameObject.FindGameObjectsWithTag("Multi"))
            {
                Destroy(i);
            }
            foreach (GameObject i in GameObject.FindGameObjectsWithTag("Seconds"))
            {
                Destroy(i);
            }
            betin = true;
            rocket.transform.position = rocket.GetComponent<rocketmove>().startposition;
            rocket.SetActive(true);
            System.Random va = new System.Random();
            int num = va.Next(0, 3);
            if (num == 0)
            {
                value = UnityEngine.Random.Range(10f, 20f);
                multitime = 0.02f;
            }
            if (num == 1)
            {
                value = UnityEngine.Random.Range(5f, 15f);
                multitime = 0.04f;
            }
            if (num == 2)
            {
                value = UnityEngine.Random.Range(0f, 10f);
                multitime = 0.04f;
            }
            if (num == 3)
            {
                value = UnityEngine.Random.Range(0f, 1f);
                multitime = 0.7f;
            }
            next = false;
        }
        else if (!next && multiply <=value)
        {
            if (auto)
            {

                if (float.Parse(cashoutat.text) <= float.Parse(Math.Round(multiply, 2).ToString()) && start && cashOut.activeSelf)
                {
                    Cashout();
                }
            }
            thesecondcount = Mathf.FloorToInt(secondcount % 60);
            if (thesecondcount == j)
            {
                j++;
                seconds += 1;
                GameObject i = Instantiate(secondbarobject, secondbarlocation);
                i.GetComponent<Seconds>().set();
            }
            if (cashon)
            {
                cashOut.SetActive(true);
            }
            done = false;
            multiply += Mathf.Lerp(0f, value, multitime * Time.deltaTime);
            MultitextPlane.text = Math.Round(multiply, 2).ToString() + "x";
        }
        if (multiply >= value)
        {
            if (auto && !start && a == 0)
            {
                Betin();
                a = 1;
            }
            rocket.transform.position = rocket.GetComponent<rocketmove>().startposition;
            rocket.SetActive(false);
            betin = false;
            if (!done)
            {
                GameObject l = Instantiate(multivalueobject, multilocationx);
                l.GetComponent<Multivaluex>().set(multiply);
                countin = true;
                if (clicked == 0)
                {
                    Loose();
                    done = true;
                    cashon = false;
                }
                else
                {
                    cashon = true;
                    clicked = 0;
                    done = true;
                }
                timegoesby = 15;
            }
        }
        if (!auto)
        {
            BetIn.SetActive(true);
            Autobetin.SetActive(false);
        }
        else
        {
            BetIn.SetActive(false);
            Autobetin.SetActive(true);
        }
        if (start)
        {
            BetIn.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            cashOut.SetActive(false);
            BetIn.GetComponent<Image>().color = Color.yellow;
        }
    }

    public void Moneygotempty()
    {
        Moneygot.text = "";
    }

    public void Betin()
    {
        if (!start && betamount.text.Length > 1)
        {
            start = true;
            amount -= int.Parse(betamount.text);
            betamountgiven = int.Parse(betamount.text);
            if (betin)
            {
                cashOut.SetActive(false);
                clicked = 1;
            }
            else
            {
                clicked = 0;
            }
            autobetorbetting.text = "Auto Betting";
            autobetstartstop.text = "Click to Stop";
        }
    }

    public void cancel()
    {
        if (start)
        {
            start = false;
            amount += betamountgiven;
            cashon = false;
            autobetorbetting.text = "Auto Bet";
            autobetstartstop.text = "Click to Start";
        }
    }

    public void Loose()
    {
        start = false;
        cashOut.SetActive(false);
        autobetorbetting.text = "Auto Bet";
        autobetstartstop.text = "Click to Start";
    }

    public void Cashout()
    {
        start = false;
        amount += float.Parse(Math.Round(betamountgiven * multiply, 2).ToString());
        cashOut.SetActive(false);
        autobetorbetting.text = "Auto Bet";
        autobetstartstop.text = "Click to Start";
        Moneygot.text = float.Parse(Math.Round(betamountgiven * multiply, 2).ToString()).ToString();
        Invoke("Moneygotempty", 4f);
        cashon = false;
    }

    public void autoonoffbet()
    {
        if (start)
        {
            cancel();
        }
        else
        {
            Betin();
        }
    }

    //value+//
    public void one()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "1"), 2).ToString();
    }

    public void two()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "2"), 2).ToString();
    }

    public void three()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "3"), 2).ToString();
    }

    public void four()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "4"), 2).ToString();
    }

    public void five()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "5"), 2).ToString();
    }

    public void six()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "6"), 2).ToString();
    }

    public void seven()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "7"), 2).ToString();
    }
    public void eight()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "8"), 2).ToString();
    }

    public void nine()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "9"), 2).ToString();
    }

    public void zero()
    {
        cashoutatnumbertyped.text = Math.Round(float.Parse(cashoutatnumbertyped.text + "0"), 2).ToString();
    }
    public void dot()
    {
        if (!cashoutatnumbertyped.text.Contains("."))
        {
            cashoutatnumbertyped.text = cashoutatnumbertyped.text.Insert(cashoutatnumbertyped.text.Length, ".");
        }
    }
    public void back()
    {
        cashoutatnumbertyped.text = cashoutatnumbertyped.text.Substring(0, cashoutatnumbertyped.text.Length - 1);
    }
}
