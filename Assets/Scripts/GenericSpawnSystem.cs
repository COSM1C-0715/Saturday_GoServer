using System.Collections.Generic;
using UnityEngine;

public class GenericSpawnSystem<T> where T : MonoBehaviour
{
    T _Prefab;

    Queue<T> _SpawnObj = new Queue<T>();

    public GenericSpawnSystem(T prefab,int spawnNum)
    {
        _Prefab = prefab;

        for(int i = 0;i < spawnNum;i++)
        {
            T obj = Object.Instantiate(_Prefab);

            obj.gameObject.SetActive(false);

            _SpawnObj.Enqueue(obj);
        }
    }

    public T Get()
    {
        if(_SpawnObj.Count > 0)
        {
            _SpawnObj.Dequeue();
        }
        else
        {
            T obj = Object.Instantiate(_Prefab);

            obj.gameObject.SetActive(true);

            return obj;
        }

        return null;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);

        _SpawnObj.Enqueue(obj);
    }
}
