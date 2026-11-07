using UnityEngine;

public class AttackInput : MonoBehaviour
{
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
        GameObject obj = Instantiate(_BalletPrefab, _AttackDir, Quaternion.identity);

        Bullet bullet = obj.GetComponent<Bullet>();

        bullet.Attack(_AttackDir);
    }
}
