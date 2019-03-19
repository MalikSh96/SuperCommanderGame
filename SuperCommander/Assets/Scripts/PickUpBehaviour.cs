using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    public int healthToAdd = 10;
    GameObject player; // Reference to the player GameObject.
    PlayerHealth playerHealth; // Reference to the player's health, script.

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //improves the performance instead of always looking for the player
        playerHealth = player.GetComponent<PlayerHealth>(); //<-- acquires script
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerHealth.currentHealth > 0)
        //{
            
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("hey");
        if (collision.gameObject == player)
        {
            AddHealth();
            Destroy(GameObject.FindGameObjectWithTag("Health"));
        }
    }

    void AddHealth()
    {
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.AddHealthToPlayer(healthToAdd);
        }
    }

}
