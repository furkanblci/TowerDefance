using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth;
    public Slider healthBar;
    public int moneyOndeath = 50;
    void Start()
    {
        healthBar.maxValue = totalHealth;
        healthBar.value = totalHealth;
        
        LevelManager.instance.activeEnemies.Add(this);
    }

   
    void Update()
    {
        healthBar.transform.rotation = Camera.main.transform.rotation;
    }

    public void TakeDamage(float damageAmount)
    {
        totalHealth -= damageAmount;
        if (totalHealth <= 0)
        {
            totalHealth = 0;
            Destroy(gameObject);
            MoneyManager.instance.GiveMoney(moneyOndeath);

            LevelManager.instance.activeEnemies.Remove(this);


        }

        healthBar.value = totalHealth;
        UIController.instance.goldText.text =MoneyManager.instance.currentMoney.ToString();

        healthBar.gameObject.SetActive(true);

    }
}
