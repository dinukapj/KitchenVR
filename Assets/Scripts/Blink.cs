using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public float interval = 2f;

    void Start()
    {
        InvokeRepeating("DoBlink", 0, interval);
    }

    public void DoBlink()
    {
        if (this.gameObject.activeSelf)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);
    }
}
