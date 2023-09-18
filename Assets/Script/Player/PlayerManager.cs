using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

[System.Serializable]
public class Player 
{
    public int health;
    public int attack;
    public int defense;
    public float speed;
    public float dashCooldown;

    //player's current weapons
    public GameObject leftHandWeapon;
    public GameObject rightHandWeapon;

    // player's current passive item
    public Item[] items;
}
