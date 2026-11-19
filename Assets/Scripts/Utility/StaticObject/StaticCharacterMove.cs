using UnityEngine;
using static TimeUtility;

public static class StaticCharacterMove
{
    public static Character SerchTarget<T>(Vector3 pos, float radius)where T : Character
    {
        Collider[] colliders = Physics.OverlapSphere(pos, radius);

        Character chara = null;

        float minDistance = 100;

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.TryGetComponent<T>(out var any))
            {
                float sqrDis = (any.transform.position - pos).sqrMagnitude;

                if (sqrDis < minDistance)
                {
                    minDistance = sqrDis;

                    chara = any;
                }
            }
        }
        return chara;
    }

    public static Vector3 AttackDir(Vector3 targetPos, Transform fromTransform,int speed)
    {
        Vector3 targetDir = (targetPos - fromTransform.position).normalized;

        float dot = Vector3.Dot(targetDir, fromTransform.forward);

        Vector3 move = Vector3.zero;

        if (dot < 0.9f)
        {
            Vector3 cross = Vector3.Cross(fromTransform.forward, targetDir);

            float aCos = Mathf.Min(Mathf.Acos(dot), 50.0f * Mathf.Deg2Rad);

            aCos *= (cross.y / Mathf.Abs(cross.y));

            Vector3 angle = fromTransform.eulerAngles;

            angle.y += aCos * Mathf.Rad2Deg;

            fromTransform.eulerAngles = angle;

        }

        move = fromTransform.forward * speed * GameTime.FixedDeltaTime;

        return move;
    }
}
