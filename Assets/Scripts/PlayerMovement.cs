
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5F;
    public float gravity = 20.0F;

    public GameObject waterSpray;
    public GameObject fire;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey("f"))
        {
            StartWaterSpray();
        }
        else
        {
            StopWaterSpray();
        }
    }

    void StartWaterSpray()
    {
        waterSpray.SetActive(true);
    }

    void StopWaterSpray()
    {
        waterSpray.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            fire.GetComponent<Fire>().ReduceFire();
        }
    }
}