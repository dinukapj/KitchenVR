using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Animator controller;
    public Camera camera;

    private Vector3 mOffset;
    private float mZCoord;
    private AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            controller.SetBool("lift", true);
        }
    }

    public void OnCut()
    {
        controller.SetBool("lift", false);

        source.Play();

        Invoke("Reset", 4f);
    }

    //temp
    void Reset()
    {
        controller.SetBool("lift", false);
    }

    void OnMouseDown()
    {
        mZCoord = camera.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return camera.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
