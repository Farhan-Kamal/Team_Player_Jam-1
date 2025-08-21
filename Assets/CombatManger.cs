using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CombatManger : MonoBehaviour
{
    public GameManger GameManger;
    public int Player1Level = 1;
    public int Player2Level = 1;
    public int Cash = 3;
    public int RatD = 1;
    public int P1Health = 5;
    public int P1Shield = 3;
    public int P2Health = 5;
    public int P2Shield = 3;
    public int DL = 1;
    public int Et = 1;
    public Slider PHealth;
    public Slider PShield;
    public TextMeshProUGUI PHName;
    public int EHeal = 5;
    public int EShiel = 3;
    public TextMeshProUGUI EName;
    public Slider EHealth;
    public Slider EShield;

    private int Choice;
    public string SampleScene;
    // Start is called before the first frame update
    void Start()
    {
        // Et = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        PHName.text = "Ricky";
        PHealth.value = P1Health;
        PShield.value = P1Shield;
        EName.text = "MONSTER";
        EHealth.value = EHeal;
        EShield.value = EShiel;

        if (EHeal <= 0)
        {
            Debug.Log("GAME OVER PLAYER WINS");
            GetComponent<Tele>().Teleport(SampleScene, Vector3.zero, GameObject.Find("Player 1"));
        }
        else if (P1Health <= 0)
        {
            Debug.Log("PLAYER LOST");
            GetComponent<Tele>().Teleport(SampleScene, Vector3.zero, GameObject.Find("Player 1"));
        }
    }

    public void EnemyAttacked()
    {
        if (EShiel > 0) {
            EShiel -= RatD;
        } else
        {
            EHeal -= RatD;
        }
        EnemyTurn();
    }
    public void DefendSelf()
    {
        P1Shield += DL;
        EnemyTurn();
    }

    public void RunS()
    {
        GetComponent<Tele>().Teleport(SampleScene, Vector3.zero, GameObject.Find("Player 1"));
    }

    public void EnemyTurn()
    {
        Choice = Random.Range(0, 3);
        Debug.Log("Enemy is");
        Debug.Log(Choice);
        if (Choice == 1)
        {
            EShiel += 1;
        }
        else if (Choice == 2)
        {
            EHeal += 1;
        }
        else if (Choice == 3)
        {
            if (P1Shield > 0)
            {
                P1Shield -= RatD;
            }
            else
            {
                P1Health -= RatD;
            }
        }
    }

}
