using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureTrap : MonoBehaviour
{
    [SerializeField] TreasureSpawner weaponDropList;
    [SerializeField] EnemiesSpawner enemiesSpawnList;

    void Start()
    {
        weaponDropList.InitilizeSpawner();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                weaponDropList.SpawnLoot(transform.position, transform.rotation);
                enemiesSpawnList.SpawnEnemies(transform.position, transform.rotation, 0f);
                Destroy(this.gameObject);
            }
        }
    }
}

[System.Serializable]
public class EnemiesSpawner
{
    [System.Serializable]
    public class SpawnElement 
    {
        public GameObject enemy;
        [Tooltip("This variable controls how many enemies will be spawned")]
        [Range(0, 10)]
        public int quantity;
    }

    public SpawnElement[] spawnList;

    public void SpawnEnemies(Vector3 pos, Quaternion rotate, float range) 
    {
        for (int i = 0; i < spawnList.Length; i++)
        {
            for (int j = 0; j < spawnList[i].quantity; j++)
            {
                GameObject.Instantiate(spawnList[i].enemy, new Vector3(pos.x + Random.Range(-range, range), pos.y, pos.z + Random.Range(-range, range)), rotate);
            }
        }
    }
}
