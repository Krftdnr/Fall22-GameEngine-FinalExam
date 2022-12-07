using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public int size;
    public GameObject prefab;

    Queue<GameObject> pool;
    
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = pool.Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    public void ReturnToPool(GameObject entity)
    {
        pool.Enqueue(entity);
    }
}
