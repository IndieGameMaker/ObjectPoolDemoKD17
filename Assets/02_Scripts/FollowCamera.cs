using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float height = 3.0f;
    [SerializeField] private float damping = 1.0f;

    [Range(0.0f, 5.0f)]
    public float lookAtPoint = 0.0f;

    void LateUpdate()
    {
        Vector3 pos = target.position - (target.forward * distance) + (Vector3.up * height);

        transform.position = Vector3.Slerp(transform.position, pos, Time.deltaTime * damping);

        Vector3 _target = target.position + (Vector3.up * lookAtPoint);
        transform.LookAt(_target);
    }
}
