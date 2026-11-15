using System;
using System.Collections;
using UnityEngine;

public static class StaticAttack<T> where T : Bullet
{
    public static void Attack(Player player,int index,float attackAngle, GenericSpawnSystem<T> spawmObj) 
    {
        for(int i = 0;i < index;i++)
        {
            SpawnBullet(player,i,attackAngle,spawmObj);
        }
    }

    public static IEnumerator AttackCoroutine(Player player, int index, float attackAngle, GenericSpawnSystem<T> spawmObj)
    {
        for (int i = 0; i < index; i++)
        {
            SpawnBullet(player, i, attackAngle, spawmObj);

            yield return new WaitForSeconds(0.5f);
        }
    }

    static void SpawnBullet(Player player, int index, float attackAngle,GenericSpawnSystem<T> spawmObj)
    {
        float angle = attackAngle * (index + 1);

        Vector3 localPos = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0.0f, Mathf.Sin(angle * Mathf.Deg2Rad));

        Vector3 rotatedPos = player.transform.rotation * localPos;

        Vector3 spawnPos = rotatedPos + player.transform.forward + player.transform.position;

        T bullet = spawmObj.Get();

        bullet.transform.position = spawnPos;

        bullet.Attack(rotatedPos);
    }
}
