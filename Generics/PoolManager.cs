using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PoolManager : MonoBehaviour
{
    public GameObject cubePrefab;

    private void OnEnable()
    {
        Pool<Cube>.AssignPrefab(cubePrefab);
    }

    //example of getting object out of the pool
    private GameObject CreateCube()
    {
        return Pool<Cube>.GetObjectFromPool().gameObject;
    }

    private void IUseMultipleGenericArugments<T, U, V>()
    {

    }
}

public static class Pool<T> where T : MonoBehaviour
{
    private static Queue<T> objectQueue = new Queue<T>();
    private static GameObject prefab;

    public static void AssignPrefab(GameObject prefab)
    {
        Pool<T>.prefab = prefab;
    }

    public static void ReturnObjectToPool(T _object)
    {
        objectQueue.Enqueue(_object);
        _object.gameObject.SetActive(false);
    }

    public static T GetObjectFromPool()
    {
        if (objectQueue.Count > 0)
            return objectQueue.Dequeue();
        return GameObject.Instantiate(prefab).GetComponent<T>();
    }


}