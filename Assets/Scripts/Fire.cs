using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fire : MonoBehaviour
{
    public GameObject severityText;
    public float severity = 100f;

    public GameObject fireCanvas;
    public GameObject fireCompleteCanvas;

    void Start()
    {
        fireCanvas.SetActive(true);
        fireCompleteCanvas.SetActive(false);
    }

    void Update()
    {

    }

    public void ReduceFire()
    {
        if (severity > 0)
        {
            severity -= 1f;
            severityText.GetComponent<TextMeshProUGUI>().text = severity + "%";
        }
        else
        {
            fireCanvas.SetActive(false);
            fireCompleteCanvas.SetActive(true);
        }
    }
}