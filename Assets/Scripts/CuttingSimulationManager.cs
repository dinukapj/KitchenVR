using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingSimulationManager : MonoBehaviour
{
    public GameObject warningPanel;
    // store how much the mouse has moved since the last frame
    public Vector3 mouseDelta = Vector3.zero;
    public float movementThreshold;
    public AudioSource pingAudioSource;

    private Vector3 lastMousePosition = Vector3.zero;

    void Update()
    {
        mouseDelta = Input.mousePosition - lastMousePosition;

        lastMousePosition = Input.mousePosition;

        if (mouseDelta.x > movementThreshold)
        {
            if (!pingAudioSource.isPlaying)
            {
                pingAudioSource.Play();
            }
            CancelInvoke();
            warningPanel.SetActive(true);
        }
        else
        {
            Invoke("HideInstruction", 3f);
        }
    }

    void HideInstruction()
    {
        warningPanel.SetActive(false);
    }
}
