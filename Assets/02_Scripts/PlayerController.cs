using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private float moveSpeed = 8.0f;
    private float turnSpeed = 100.0f;

    private float v => Input.GetAxis("Vertical");
    private float h => Input.GetAxis("Horizontal");
    private float r => Input.GetAxis("Mouse X");
    private bool isFire => Input.GetMouseButtonDown(0);

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Locomotion();
    }

    private void Locomotion()
    {
        Vector3 moveDir = (transform.forward * v) + (transform.right * h);
        cc.Move(moveDir.normalized * Time.deltaTime * moveSpeed);

        transform.Rotate(Vector3.up * Time.deltaTime * r * turnSpeed);
    }
}
