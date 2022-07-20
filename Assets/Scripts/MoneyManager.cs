using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class MoneyManager : MonoBehaviour
{   
    public static MoneyManager instance;
    [SerializeField] private TMP_Text moneyUI;
    public BigInteger Money {get; private set;}
    void Start()
    {   
        instance = this;
        Money=0;
        UpdateMoneyUI();
    }

    
    void Update()
    {
        
    }

    private void UpdateMoneyUI(){

        moneyUI.text = string.Format("{0}", MoneyFormatter.FormatMoney(Money));
    }

    public bool Buy(BigInteger cost){

        bool isBuyOPSuccessful = false;

        if(cost <= Money){
            Money -= cost;
            isBuyOPSuccessful = true;
        }

        UpdateMoneyUI();
        return isBuyOPSuccessful;
    }

    public void AddMoney(BigInteger profit){

        if(profit > 0){

            Money += profit;
            UpdateMoneyUI();
        }
    }
}
