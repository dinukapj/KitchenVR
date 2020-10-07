using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableTrigger : MonoBehaviour
{
    public string simulationName;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Player walked in");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player walked in");
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().StartSimulation(simulationName);
        }
    }
}
