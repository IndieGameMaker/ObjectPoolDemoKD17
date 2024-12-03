using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    public IObjectPool<Bullet> bulletPool;

    [SerializeField] private GameObject bulletPrefab;


}
