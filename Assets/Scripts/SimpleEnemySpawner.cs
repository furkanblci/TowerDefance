using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
   public EnemyController enemyToSpawn;
   [SerializeField] private Transform spawnPoint;
   [SerializeField] private float timeBetweenSpawns;
    public int amountToSpawn;

   [SerializeField]private Castle theCastle;
   [SerializeField]private Path thePath;

   private float spawnCounter;
   

   private void Start()
   {
      spawnCounter = timeBetweenSpawns;
   }

   private void Update()
   {
      if (amountToSpawn > 0 && LevelManager.instance.levelActive)
      {
         spawnCounter -= Time.deltaTime;
         if (spawnCounter <= 0)
         {
            spawnCounter = timeBetweenSpawns;

            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(theCastle,thePath);

            amountToSpawn--;
         }
      }
      
   }
}
