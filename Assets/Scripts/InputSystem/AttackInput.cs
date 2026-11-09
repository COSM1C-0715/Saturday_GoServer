using UnityEngine;

public class AttackInput : MonoBehaviour
{
    [SerializeField]
    Vector3 _OffSet = new Vector3(0.0f,0.0f,0.5f);

    Vector3 _AttackDir;

    Player _Player;

    [SerializeField]
    GameObject _BalletPrefab;

    void Awake()
    {
        _Player = GetComponent<Player>();
    }

    void Start()
    {
        _AttackDir = _Player.transform.forward;
    }
    public void Attack()
    {
        Vector3 spawnPos = _Player.transform.position;

        GameObject obj = Instantiate(_BalletPrefab, spawnPos, Quaternion.identity);

        Bullet bullet = obj.GetComponent<Bullet>();

        bullet.Attack(_AttackDir);
    }
}
