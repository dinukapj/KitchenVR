using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Simulations")]
    public GameObject FireSimulation;
    public GameObject CuttingSimulation;
    public GameObject MainMenu;

    [Header("Player Controls")]
    public GameObject player;
    public GameObject fireExtinguisher;

    void Start()
    {

    }

    void Update()
    {

    }

    internal void StartSimulation(string simulationName)
    {
        switch (simulationName)
        {
            case "FIRE":
                player.SetActive(true);
                MainMenu.SetActive(false);
                FireSimulation.SetActive(true);
                fireExtinguisher.SetActive(true);
                CuttingSimulation.SetActive(false);

                GetComponent<FireSimulationManager>().OnSimulationStart();
                break;
            case "CUTTING":
                player.SetActive(false);
                MainMenu.SetActive(false);
                FireSimulation.SetActive(false);
                fireExtinguisher.SetActive(false);
                CuttingSimulation.SetActive(true);
                break;
        }
    }

    public void OnStartTraining()
    {
        StartSimulation("FIRE");
    }
}
