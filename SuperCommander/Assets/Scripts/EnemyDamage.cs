using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Tutorial followed: https://unity3d.com/learn/tutorials/projects/survival-shooter/player-health?playlist=17144
https://www.youtube.com/watch?time_continue=1&v=a916_lhps04
 */
public class EnemyDamage : MonoBehaviour
{
    public int damageToDo = 10;
    GameObject player; // Reference to the player GameObject.
    PlayerHealth playerHealth; // Reference to the player's health, script.

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //improves the performance instead of always looking for the player
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            GameObject.Destroy(player);
        }
    }

    //This below does not work
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    print("hello");
    //    if (collision.gameObject == player)
    //    {
    //        print("attack pls");
    //    }
    //}

    //This below works, but is "broken", in broken I mean one collision counts as multiple
    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("hey");
        if (collision.gameObject == player)
        {
            DoAttack();
        }
    }

    void DoAttack()
    {
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.DoDamageOnPlayer(damageToDo);
        }
    }
}
