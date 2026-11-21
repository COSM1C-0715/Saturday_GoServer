using System.Collections.Generic;
using UnityEngine;
public static class PrefabName
{
    public const string BULLET = "Bullet";
    public const string ENEMY = "Enemy";
}

public class SpawnManagement : MonoBehaviour
{
    [SerializeField]
    private LayerMask _PlayerMask;

    private Bullet _BulletPrefab;

    private Enemy _EnemyPrefab;

    private GenericSpawnSystem<Bullet> _Bullets;

    private GenericSpawnSystem<Enemy> _Enemies;

    public GenericSpawnSystem<Bullet> Bullets => _Bullets;

    [SerializeField,Tooltip("ê∂ê¨Ç≥ÇπÇÈêî")]
    int _SpawnCount = 0;

    private int _ActiveEnemyNum = 0;

    [SerializeField]
    float _CheckRadius = 1.0f;

    private const int TRY_SPAWN_COUNT = 1000;
    void Awake()
    {
        _BulletPrefab = Resources.Load<Bullet>(PrefabName.BULLET);
        _EnemyPrefab = Resources.Load<Enemy>(PrefabName.ENEMY);
        _Bullets = new GenericSpawnSystem<Bullet> (_BulletPrefab,_SpawnCount);
        _Enemies = new GenericSpawnSystem<Enemy>(_EnemyPrefab, _SpawnCount);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AnyOneSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        AnyOneSpawn();
    }

    void AnyOneSpawn()
    {
        int subSpawnCount  = _Enemies.ObjNum - _ActiveEnemyNum;

        if (subSpawnCount <= 0) return;

        _ActiveEnemyNum = 0;

        for (int i = 0; i < subSpawnCount; i++)
        {
            int count = 0;

            Vector3 initPos = InitPos();

            while (count < TRY_SPAWN_COUNT && Physics.CheckSphere(initPos, _CheckRadius, _PlayerMask))
            {
                count++;
                
                initPos = InitPos();
            }

            if (Physics.CheckSphere(initPos, _CheckRadius, _PlayerMask)) continue;

            Enemy obj = _Enemies.Get();

            obj.transform.position = initPos;

            obj._Return = _Enemies.Return;

            _ActiveEnemyNum++;
        }
    }

    Vector3 InitPos()
    {
        float posX = Random.Range(-46, 46);

        float posZ = Random.Range(-46, 46);

        return new Vector3(posX, 1.0f, posZ);
    }
}
