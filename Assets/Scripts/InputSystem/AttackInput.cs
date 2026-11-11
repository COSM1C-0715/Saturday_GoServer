using UnityEngine;

public class AttackInput : MonoBehaviour
{
    const float ATTACK_ANGLE = 45;

    int _SpawnIndex = 3;

    Player _Player;

    SpawnManagement _SpawnManagement;
    void Awake()
    {
        _Player = GetComponent<Player>();
    }

    void Start()
    {
        _SpawnManagement = GameObject.Find("SpawnGameObject").GetComponent<SpawnManagement>();
    }
    public void Attack()
    {

    }

    void BulletShot(Player player, int index,float attackAngle,SpawnManagement spawmObj)
    {
        for (int i = 0; i < index; i++)
        {
            float angle = attackAngle * (i + 1);

            Vector3 localPos = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0.0f, Mathf.Sin(angle * Mathf.Deg2Rad));

            Vector3 rotatedPos =player.transform.rotation * localPos;

            Vector3 spawnPos = rotatedPos + player.transform.forward + player.transform.position;

            Bullet bullet = spawmObj.Bullets.Get();

            bullet.transform.position = spawnPos;

            bullet.Attack(rotatedPos);
        }
    }
}
