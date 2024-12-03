using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force = 1500.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        rb.AddRelativeForce(Vector3.forward * force);
    }
}
