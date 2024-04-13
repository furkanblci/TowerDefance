using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleEnemySpawner : MonoBehaviour
{
   //public EnemyController enemyToSpawn;
   public EnemyController[] enemiesToSpawn;
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

            Instantiate(enemiesToSpawn[Random.Range(0,enemiesToSpawn.Length)], spawnPoint.position, spawnPoint.rotation).Setup(theCastle,thePath);

            amountToSpawn--;
         }
      }
      
   }
}
