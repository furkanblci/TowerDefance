using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerUpgradePanel : MonoBehaviour
{
 public GameObject rangeButton, fireRateButton;
 public TMP_Text rangeText, fireRateText;

 public void SetupPanel()
 {
  if (TowerManager.instance.selectedTower.upgrader.hasRangeUpgrade)
  {

   TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
   rangeText.text = "Upgrade\n Range\n (" + upgrader.rangeUpgrades[upgrader.currentRangeUpgrade].cost+"G)";
   
   rangeButton.SetActive(true);
  }
  else
  {
   rangeButton.SetActive(false);
  }

  if (TowerManager.instance.selectedTower.upgrader.hasFireRateUpgrade)
  {
   TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
   fireRateText.text = upgrader.fireRateText + "\n(" + upgrader.fireRateUpgrades[upgrader.currentFireRateUpgrade].cost +
                       "G)";
   
   
   fireRateButton.SetActive(true);
  }
  else
  {
   fireRateButton.SetActive(false);
  }
  
 }
 
 public void RemoveTower()
 {
  MoneyManager.instance.Spendmoney(-50);
  Destroy(TowerManager.instance.selectedTower.gameObject);
  UIController.instance.CloseTowerUpgradePanel();
 }

 public void UpgradeRange()
 {
  TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
  
  if (upgrader.hasRangeUpgrade)
  {
   if (MoneyManager.instance.Spendmoney(upgrader.rangeUpgrades[upgrader.currentRangeUpgrade].cost))
   {
    upgrader.UpgradeRange();
    SetupPanel();
    
    UIController.instance.notEnaughtMoneyWarning.SetActive(false);
   }
   else
   {
    UIController.instance.notEnaughtMoneyWarning.SetActive(true);
   }
  }
 }

 public void UpgradeFireRate()
 {
  TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
  if (upgrader.hasFireRateUpgrade)
  {
   if (MoneyManager.instance.Spendmoney(upgrader.fireRateUpgrades[upgrader.currentFireRateUpgrade].cost))
   {
    upgrader.UpgradeFireRate();
    
    SetupPanel();
    
    UIController.instance.notEnaughtMoneyWarning.SetActive(false);
   }
   else
   {
    UIController.instance.notEnaughtMoneyWarning.SetActive(true);
   }
   
   
  }
  
  
 }
 
 
}
