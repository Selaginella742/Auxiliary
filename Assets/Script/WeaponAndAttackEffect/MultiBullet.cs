using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBullet : MonoBehaviour
{
    public int bulletCount;
    Transform muzzle;
    public GameObject bulletPrefab;

    void Awake()
    {
        muzzle = transform.parent;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            StartCoroutine(waiter(0.2f));
        }
    }

    void LateUpdate() 
    {
        Destroy(this);
    }

    IEnumerator waiter(float time)
    {
        yield return new WaitForSecondsRealtime(time);
    }
}
