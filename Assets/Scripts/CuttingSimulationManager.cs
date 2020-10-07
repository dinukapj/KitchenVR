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
    public AudioSource cuttingAudioSource;
    public GameObject slicedPoint;
    public GameObject unslicedPrefab;
    public GameObject startPoint;

    private GameObject movingSlice;
    private bool isMovingSlice = false;
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

        //movement of slices

        //if(isMovingSlice)
        //{
        //    float step = 2f * Time.deltaTime;
        //    movingSlice.transform.position = Vector3.MoveTowards(transform.position, movingSlice.transform.position, step);
        //}

        //if (Vector3.Distance(movingSlice.transform.position, slicedPoint.transform.position) <= 0)
        //{
        //    isMovingSlice = false;
        //}
    }

    void HideInstruction()
    {
        warningPanel.SetActive(false);
    }

    public void OnSuccessfulSlice(GameObject slice)
    {
        cuttingAudioSource.Play();
        movingSlice = slice;
        isMovingSlice = true;
        StartCoroutine(MoveSlice(slice, 2));
        StartCoroutine(SpawnSliceable(3));
    }

    IEnumerator MoveSlice(GameObject slice, float time)
    {
        yield return new WaitForSeconds(time);

        slice.transform.position = slicedPoint.transform.position;
    }

    IEnumerator SpawnSliceable(float time)
    {
        yield return new WaitForSeconds(time);

        Instantiate(unslicedPrefab, startPoint.transform.position, startPoint.transform.rotation);
    }


}
