using UnityEngine;

public class AttackInput : MonoBehaviour
{
    const float ATTACK_ANGLE = 45;

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
        BulletShot(_Player, _SpawnIndex,ATTACK_ANGLE);
    }

    void BulletShot(Player player, int index,float attackAngle)
    {
        for (int i = 0; i < index; i++)
        {
            float angle = attackAngle * (i + 1);

            Vector3 localPos = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0.0f, Mathf.Sin(angle * Mathf.Deg2Rad));

            Vector3 rotatedPos =player.transform.rotation * localPos;

            Vector3 spawnPos = rotatedPos + player.transform.forward + player.transform.position;

            GameObject obj = Instantiate(_BalletPrefab, spawnPos, Quaternion.identity);

            Bullet bullet = obj.GetComponent<Bullet>();

            bullet.Attack(rotatedPos);
        }
    }
}
