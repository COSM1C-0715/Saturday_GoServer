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
        StaticAttack<Bullet>.Attack(_Player,_SpawnIndex,ATTACK_ANGLE, _SpawnManagement.Bullets);
    }
}
