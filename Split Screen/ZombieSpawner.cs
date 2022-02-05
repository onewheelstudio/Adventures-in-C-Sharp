using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private float range = 100;
    [SerializeField]
    private int number = 150;
    [SerializeField]
    private GameObject zombiePrefab;
    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += DoSpawn;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= DoSpawn;
    }

    void DoSpawn(PlayerInput player)
    {
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 location = Random.insideUnitCircle * range;
            Vector3 position = new Vector3(location.x, 0, location.y) + this.transform.position;

            GameObject.Instantiate(zombiePrefab, position, Quaternion.identity);
            yield return null;
        }
    }
}
