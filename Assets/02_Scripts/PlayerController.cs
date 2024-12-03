using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private float moveSpeed = 8.0f;
    private float turnSpeed = 100.0f;

    private float v => Input.GetAxis("Vertical");
    private float h => Input.GetAxis("Horizontal");
    private bool isFire => Input.GetMouseButtonDown(0);

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {

    }
}
