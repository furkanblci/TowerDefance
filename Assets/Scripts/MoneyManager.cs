using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int currentMoney;
    void Start()
    {
        instance = this;
        
    }
    
    void Update()
    {
        
    }

    public void GiveMoney(int amountToGive)
    {
        currentMoney += amountToGive;
    }

    public bool Spendmoney(int amountToSpend)
    {
        bool canSpend = false;

        if (amountToSpend <= currentMoney)
        { 
            canSpend = true;
            Debug.Log("Spent "+amountToSpend);
            currentMoney -= amountToSpend;
        }

        return canSpend;
    }
    
    
}
