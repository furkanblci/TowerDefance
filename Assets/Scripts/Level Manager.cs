using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool levelActive;
    private bool levelVictory;

    private Castle theCastle;

    public List<EnemyHealthController> activeEnemies = new List<EnemyHealthController>();

    private SimpleEnemySpawner enemySpawner;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        theCastle = FindObjectOfType<Castle>();
        enemySpawner = FindObjectOfType<SimpleEnemySpawner>();
        levelActive = true;
    }

    void Update()
    {
        if (levelActive)
        {
            if (theCastle.currentHealth <= 0)
            {
                levelActive = false;
                levelVictory = false;
                
                UIController.instance.levelFailPanel.SetActive(true);
                UIController.instance.towerButtons.SetActive(false);
            }

            if (activeEnemies.Count == 0 && enemySpawner.amountToSpawn == 0)
            {
                levelActive = false;
                levelVictory = true;
                
                UIController.instance.levelComplatePanel.SetActive(true);
                UIController.instance.towerButtons.SetActive(false);


            }
        }
    }
}
