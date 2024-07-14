using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for speed purposes i added this quick pool system, it's not scalable but i can addapt it to accept any pool type, like a pool of an script
public class PoolManager : Singleton<PoolManager>
{
    public Bullet objectPrefab;
    public int poolSize = 10;
    public int maxPoolSize = 50;
    private List<Bullet> pool;

    void Start()
    {
        pool = new List<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            Bullet obj = Instantiate(objectPrefab);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }

    public Bullet GetBullet()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].gameObject.SetActive(true);
                return pool[i];
            }
        }

        if (pool.Count < maxPoolSize)
        {
            Bullet obj = Instantiate(objectPrefab);
            obj.gameObject.SetActive(true);
            pool.Add(obj);
            return obj;
        }
        else
        {
            Debug.LogWarning("Pool limit reached, unable to get new object.");
            return null;
        }
    }

    public void ReturnBullet(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }
}
