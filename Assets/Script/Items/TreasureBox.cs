using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public TreasureSpawner weaponDropList;
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
                Destroy(this.gameObject);
            }
        }
    }
}

[System.Serializable]
public class TreasureSpawner
{
    [System.Serializable]
    public class LootItem
    {
        public GameObject item;

        [Range(0, 10)]
        public float weight;

    }

    public LootItem[] lootItems;
    float[] weightSheet;

    public void InitilizeSpawner()
    {
        weightSheet = new float[lootItems.Length];
        weightSheet[0] = lootItems[0].weight;

        for (int i = 1; i < weightSheet.Length; i++)// initialize the weight sheet of each weapons for random drops
        {
            weightSheet[i] = weightSheet[i - 1] + lootItems[i].weight;
        }
    }

    public void SpawnLoot(Vector3 position, Quaternion rotation)
    {

        if (weightSheet == null)
            InitilizeSpawner();

        float random = Random.Range(0, weightSheet[weightSheet.Length - 1]);

        for (int i = 0; i < lootItems.Length; i++)
        {
            if (random <= weightSheet[i])
            {
                Object.Instantiate(lootItems[i].item, position, rotation);
                break;
            }
        }
        
    }
}
