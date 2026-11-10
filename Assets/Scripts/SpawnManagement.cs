using UnityEngine;

public static class PrefabName
{
    public const string BULLET = "Bullet";
}

public class SpawnManagement : MonoBehaviour
{
    private Bullet _BulletPrefab;

    private GenericSpawnSystem<Bullet> _Bullets;

    void Awake()
    {
        _BulletPrefab = Resources.Load<Bullet>(PrefabName.BULLET);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Bullets = new GenericSpawnSystem<Bullet> (_BulletPrefab,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
