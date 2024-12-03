using System;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    public IObjectPool<Bullet> bulletPool;

    [SerializeField] private GameObject bulletPrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        // ObjectPool 초기화
        bulletPool = new ObjectPool<Bullet>(
            createFunc: CreateItem,
            actionOnGet: OnTakeItem,
            actionOnRelease: OnReturnItem,
            actionOnDestroy: OnDestroyItem,
            defaultCapacity: 5,
            maxSize: 10
        );
    }

    private Bullet CreateItem()
    {
        return Instantiate(bulletPrefab).GetComponent<Bullet>();
    }

    private void OnTakeItem(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReturnItem(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyItem(Bullet bullet)
    {
        Debug.Log("삭제됨");
        Destroy(bullet.gameObject);
    }
}
