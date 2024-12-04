using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private float moveSpeed = 8.0f;
    private float turnSpeed = 300.0f;

    private float v => Input.GetAxis("Vertical");
    private float h => Input.GetAxis("Horizontal");
    private float r => Input.GetAxis("Mouse X");
    private bool isFire => Input.GetMouseButton(0);

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePos;
    [SerializeField] private Transform targetIK;
    [SerializeField] private float fireRate = 0.1f;

    private float nextFireTime = 0.0f;

    void Start()
    {
        cc = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.green);

        if (Physics.Raycast(ray, out var hit))
        {
            targetIK.position = hit.point;
        }
        else
        {
            targetIK.position = Camera.main.transform.position + (ray.direction * 30.0f);
        }

        Locomotion();
        Fire();
    }

    private void Fire()
    {
        if (isFire && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            //GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            //bullet.GetComponent<Bullet>().Shoot();

            // 풀에서 bullet 요청
            Bullet bullet = PoolManager.Instance.bulletPool.Get();
            // 위치와 각도 설정
            bullet.transform.SetPositionAndRotation(firePos.position, firePos.rotation);
            // 발사
            bullet.Shoot();
        }
    }

    private void Locomotion()
    {
        Vector3 moveDir = (transform.forward * v) + (transform.right * h);
        cc.Move(moveDir.normalized * Time.deltaTime * moveSpeed);

        transform.Rotate(Vector3.up * Time.deltaTime * r * turnSpeed);
    }
}
