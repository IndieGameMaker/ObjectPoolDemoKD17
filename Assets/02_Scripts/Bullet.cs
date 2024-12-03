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
        rb.rotation = Quaternion.LookRotation(transform.forward);
        rb.AddRelativeForce(Vector3.forward * force);

        Invoke(nameof(ReturnPool), 3.0f);
    }

    void ReturnPool()
    {
        InitItem();
        PoolManager.Instance.bulletPool.Release(this);
    }

    void InitItem()
    {
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;

        rb.linearVelocity = rb.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Invoke 메소드 취소
        CancelInvoke(nameof(ReturnPool));

        InitItem();
        PoolManager.Instance.bulletPool.Release(this);
    }
}
