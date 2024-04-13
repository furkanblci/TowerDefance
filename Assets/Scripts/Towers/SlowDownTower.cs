using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTower : MonoBehaviour
{
    private Tower theTower;

    public Transform effectRing;
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    
    void Update()
    {
        foreach (EnemyController enemy in theTower.enemiesInRange)
        {
            enemy.speedMod = theTower.fireRate;
        }

        effectRing.localScale = new Vector3(theTower.range, 1f, theTower.range);
    }
}
