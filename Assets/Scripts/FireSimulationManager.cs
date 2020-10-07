using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSimulationManager : MonoBehaviour
{
    public GameObject fireExtinguisher;
    public GameObject nPC;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSimulationStart()
    {
        fireExtinguisher.SetActive(true);
        nPC.SetActive(false);
    }
}
