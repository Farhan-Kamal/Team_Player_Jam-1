using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CombatManger : MonoBehaviour
{

    public int Player1Level = 1;
    public int Player2Level = 1;
    public int Cash = 3;
    public int RatD = 1;
    public int P1Health = 5;
    public int P1Shield = 3;
    public int P2Health = 5;
    public int P2Shield = 3;
    public int Et = 1;
    public Slider PHealth;
    public Slider PShield;
    public int EHeal = 5;
    public int EShiel = 5;
    public Slider EHealth;
    public Slider EShield;
    // Start is called before the first frame update
    void Start()
    {
        // Et = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        PHealth.value = P1Health;
        PShield.value = P1Shield;
        EHealth.value = EHeal;
        EShield.value = EShiel;
    }
}
