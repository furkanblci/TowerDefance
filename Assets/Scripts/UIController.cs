using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public TMP_Text goldText;
    public GameObject notEnaughtMoneyWarning;
    public GameObject levelComplatePanel, levelFailPanel;
    public GameObject towerButtons;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
