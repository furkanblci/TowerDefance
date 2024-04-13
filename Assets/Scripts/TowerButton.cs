using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public Tower towerToPlace;
    void Start()
    {
        
    }

    public void SelectTower()
    {
        if (LevelManager.instance.levelActive)
        {
            TowerManager.instance.StartTowerPlacement(towerToPlace);
        }
    }
}
