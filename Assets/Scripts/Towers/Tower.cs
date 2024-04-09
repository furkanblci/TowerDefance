using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
   public float range = 3f;
   public LayerMask whatIsEnemy;
   public Collider[] colliderInRange;
   public List<EnemyController> enemiesInRange = new List<EnemyController>();

   private float checkCounter;
   public float checkTime = .2f;


   private void Start()
   {
      checkCounter = checkTime;
   }

   private void Update()
   {
      checkCounter -= Time.deltaTime;
      if (checkCounter <= 0)
      {
         checkCounter = checkTime;
         
         colliderInRange = Physics.OverlapSphere(transform.position, range,whatIsEnemy);
      
         enemiesInRange.Clear();
         foreach (Collider col in colliderInRange)
         {
            enemiesInRange.Add(col.GetComponent<EnemyController>());
         }  
      }
   }
}
