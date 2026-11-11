using UnityEngine;

public static class PrefabName
{
    public const string BULLET = "Bullet";
}

public class SpawnManagement : MonoBehaviour
{
    private Bullet _BulletPrefab;

    private GenericSpawnSystem<Bullet> _Bullets;

    public GenericSpawnSystem<Bullet> Bullets => _Bullets;

    void Awake()
    {
        _BulletPrefab = Resources.Load<Bullet>(PrefabName.BULLET);
        _Bullets = new GenericSpawnSystem<Bullet> (_BulletPrefab,5);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
