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
        TowerManager.instance.StartTowerPlacement(towerToPlace);
    }
}
