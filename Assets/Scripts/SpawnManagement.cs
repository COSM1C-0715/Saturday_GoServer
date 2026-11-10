using UnityEngine;

public class SpawnManagement : MonoBehaviour
{
    [SerializeField]
    private Bullet _BulletPrefab;

    private GenericSpawnSystem<Bullet> _Bullets;

    void Awake()
    {
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
