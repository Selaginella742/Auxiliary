using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    LoopSpawner spawner;
    void Start()
    {
        spawner = GetComponent<LoopSpawner>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                spawner.SpawnLoot();
                Destroy(this.gameObject);
            }
        }
    }
}
