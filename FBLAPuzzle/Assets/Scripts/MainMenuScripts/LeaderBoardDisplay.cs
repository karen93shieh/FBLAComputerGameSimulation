﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardDisplay : MonoBehaviour
{
    AccountsManager accountsManager;
    public GameObject[] rankTexts;
    // Start is called before the first frame update
    void Start()
    {
        accountsManager = GameObject.Find("AccountsManager").GetComponent<AccountsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getAccountsTotalStars() {
        accountsManager = GameObject.Find("AccountsManager").GetComponent<AccountsManager>();
        //List<string> names=new List<string>();
        //List<int> stars = new List<int>();
        List<Account> highToLow = new List<Account>();
        for(int i = 0; i < accountsManager.accounts.Count; i++)
        {
            Account acc = accountsManager.accounts[i];
            if (i == 0)
            {
                highToLow.Add(acc);
            }
            else
            {
                highToLow.Add(acc);
                for(int j = i; j >= 1; j--)
                {
                    if (acc.getTotalStar() > highToLow[j - 1].getTotalStar())
                    {
                        Account tempAcc = highToLow[j - 1];
                        highToLow[j - 1] = acc;
                        highToLow[j] = tempAcc;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < highToLow.Count; i++) {
            string text;
            text = (i+1) + ". " + highToLow[i].userName;
            int tempTextLength = text.Length;
            
            //text = text + getTotalStar(highToLow[i]);
            rankTexts[i].GetComponent<TMPro.TextMeshProUGUI>().text= text;
            rankTexts[i].transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text= highToLow[i].getTotalStar().ToString();
        }
    }
}
