using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliceable : MonoBehaviour
{
    public GameObject slicedPrefab;

    GameObject unslicedModel;
    bool isSliced;
    bool isInTrigger;

    void Start()
    {
        unslicedModel = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInTrigger && Input.GetKey("f"))
        {
            GameObject slice = Instantiate(slicedPrefab, unslicedModel.transform.position, unslicedModel.transform.rotation);
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<CuttingSimulationManager>().OnSuccessfulSlice(slice);
            unslicedModel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Knife")
        {
            isInTrigger = true;
        }
    }
}
