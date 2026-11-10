using UnityEngine;

public class AttackInput : MonoBehaviour
{
    [SerializeField]
    Vector3 _OffSet;

    float _AttackAngle = 45;

    int _SpawnIndex = 3;

    Player _Player;

    [SerializeField]
    GameObject _BalletPrefab;

    void Awake()
    {
        _Player = GetComponent<Player>();
    }

    void Start()
    {
        
    }
    public void Attack()
    {
        for(int i = 0;i < _SpawnIndex;i++)
        {
            float angle = _AttackAngle * (i + 1);

            Vector3 localpos = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0.0f, Mathf.Sin(angle * Mathf.Deg2Rad));

            Debug.Log(localpos);

            Vector3 rotatedpos = _Player.transform.rotation * localpos;

            Vector3 spawnpos = rotatedpos + _OffSet + _Player.transform.position;

            Vector3 dir = Quaternion.Euler(0.0f,angle,0.0f) * _Player.transform.forward;

            GameObject obj = Instantiate(_BalletPrefab,spawnpos,Quaternion.identity);

            Bullet bullet = obj.GetComponent<Bullet>();

            bullet.Attack(dir);
        }
    }
}
