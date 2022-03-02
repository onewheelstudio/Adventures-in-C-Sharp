using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OWS.ObjectPooling;

/// <summary>
/// this class was used to generate the demo at the start of the video
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject capsulePrefab;
    [Range(1f, 15f)]
    public float range = 5f;
    private static ObjectPool<PoolObject> cubePool;
    private static ObjectPool<PoolObject> spherePool;
    private static ObjectPool<PoolObject> capsulePool;
    public bool canSpawn = true;

    private void OnEnable()
    {
        cubePool = new ObjectPool<PoolObject>(cubePrefab);
        spherePool = new ObjectPool<PoolObject>(spherePrefab);
        capsulePool = new ObjectPool<PoolObject>(capsulePrefab);

        StartCoroutine(SpawnOverTime());
    }

    IEnumerator SpawnOverTime()
    {
        while(canSpawn)
        {
            Spawn();
            yield return null;
        }
    }

    public void Spawn()
    {
        int random = Random.Range(0, 3);
        Vector3 position = Random.insideUnitSphere * range + this.transform.position;
        GameObject prefab;

        switch (random)
        {
            case 0:
                prefab = cubePool.PullGameObject(position, Random.rotation);
                break;
            case 1:
                prefab = spherePool.PullGameObject(position, Random.rotation);
                break;
            case 2:
                prefab = capsulePool.PullGameObject(position, Random.rotation);
                break;
            default:
                prefab = cubePool.PullGameObject(position, Random.rotation);
                break;
        }

        //this could/should be done in the initialization function
        //I was lazy...
        prefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
