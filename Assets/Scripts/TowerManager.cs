using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    public Tower activeTower;
    public Transform indicator;
    public bool isplacing;

    public LayerMask whatIsPlacement,whatIsObstacle;

    public float topSafePercent = 15f;

    [HideInInspector]
    public Tower selectedTower;

    public GameObject selectedTowerEffect;
    
    void Start()
    {
        instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isplacing)
        {
            indicator.position = GetGridposition();

            RaycastHit hit;
            if (Input.mousePosition.y > Screen.height * (1f-(topSafePercent/100f))) //bu olay çok saçma safepercent muabbetini değiştirmeliyim
            {
                indicator.gameObject.SetActive(false);
            }
            else if (Physics.Raycast(indicator.position+new Vector3(0,-2f,0f),Vector3.up,out hit,10f,whatIsObstacle))
            {
                indicator.gameObject.SetActive(false);
            }
            else
            {
                indicator.gameObject.SetActive(true);
                UIController.instance.notEnaughtMoneyWarning.SetActive(MoneyManager.instance.currentMoney < activeTower.cost);



                if (Input.GetMouseButtonDown(0))
                {
                    if (MoneyManager.instance.Spendmoney(activeTower.cost))
                    {
                        isplacing = false;

                        Instantiate(activeTower, indicator.position, activeTower.transform.rotation);
                        indicator.gameObject.SetActive(false);
                        
                        UIController.instance.notEnaughtMoneyWarning.SetActive(false);
                    }
                }
            }
        }
    }

    public void StartTowerPlacement(Tower towerToPlace)
    {
        activeTower = towerToPlace;
        isplacing = true;
        
        Destroy(indicator.gameObject);
        Tower placeTower = Instantiate(activeTower);
        placeTower.enabled = false;
        placeTower.GetComponent<Collider>().enabled = false;
        indicator = placeTower.transform;
        
        placeTower.rangeModel.SetActive(true);
        placeTower.rangeModel.transform.localScale = new Vector3(placeTower.range, 1f, placeTower.range);


    }

    public Vector3 GetGridposition()
    {
        Vector3 location = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*200f,Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,200f,whatIsPlacement))
        {
            location = hit.point;
        }
        //location.y = 0.51f;
        return location;
        
    }

    public void MoveTowerSelectionEffect()
    {
        if (selectedTower != null)
        {
            selectedTowerEffect.transform.position = selectedTower.transform.position;
            selectedTowerEffect.SetActive(true);
        }
    }
}
