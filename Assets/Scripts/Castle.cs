using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
   public float maxHealth=100f;
   public float currentHealth;
   [SerializeField]private Slider healthSlider;
   public Transform[] attackPoints;
   
   
   private void Start()
   {
      currentHealth = maxHealth;
      healthSlider = GetComponentInChildren<Slider>();

      healthSlider.maxValue = maxHealth;
      healthSlider.value = currentHealth;

   }


   public void TakeDamage(float damageToTake)
   {
      currentHealth -= damageToTake;

      if (currentHealth <= 0 )
      {
         currentHealth = 0;
         gameObject.SetActive(false);
      }

      healthSlider.value = currentHealth;
   }
   
}
