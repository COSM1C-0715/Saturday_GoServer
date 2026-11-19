using UnityEngine;

public static class PrefabName
{
    public const string BULLET = "Bullet";
    public const string ENEMY = "Enemy";
}

public class SpawnManagement : MonoBehaviour
{
    private Bullet _BulletPrefab;

    private Enemy _EnemyPrefab;

    private GenericSpawnSystem<Bullet> _Bullets;

    private GenericSpawnSystem<Enemy> _Enemies;

    public GenericSpawnSystem<Bullet> Bullets => _Bullets;

    [SerializeField]
    int _SpawnCount = 0;

    void Awake()
    {
        _BulletPrefab = Resources.Load<Bullet>(PrefabName.BULLET);
        _EnemyPrefab = Resources.Load<Enemy>(PrefabName.ENEMY);
        _Bullets = new GenericSpawnSystem<Bullet> (_BulletPrefab,_SpawnCount);
        _Enemies = new GenericSpawnSystem<Enemy> (_EnemyPrefab,_SpawnCount);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _SpawnCount; i++)
        {
            int count = 0;

            float posX = Random.Range(-50, 50);

            float posZ = Random.Range(-50, 50);

            Vector3 initPos = new Vector3(posX, 0.0f, posZ);

            while (count < 100 || Physics.CheckSphere(initPos, 5.0f,3))
            {
                count++;
                posX = Random.Range(-50, 50);
                posX = Random.Range(-50, 50);

                initPos = new Vector3(posX, 0.0f, posZ);
            }

            Enemy obj = _Enemies.Get();

            obj.transform.position = initPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
