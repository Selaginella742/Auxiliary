using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletType : MonoBehaviour
{
    public Text bulletType;

    private void Start()
    {
        bulletType = GetComponent<Text>();
    }

    public void DetectBulletType()
    {
        var data = GameObject.Find("Player").GetComponent<CharacterStats>().attackData.bulletStack;
        if (data.Count == 0)
        {
            bulletType.text = "BULLET : REGULAR";
        }

        else
        {
            if (data[0].name == "ShotgunBullet")
                bulletType.text = "BULLET : BACKSTAB";
            if (data[0].name == "BounceBullet")
                bulletType.text = "BULLET : BOUNCE";
            if (data[0].name == "SniperBullet")
                bulletType.text = "BULLET : PENETRATE";
        }
    }
}
