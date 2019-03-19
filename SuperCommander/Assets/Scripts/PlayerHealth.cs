using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;
    //bool _isDead;
    //bool _isDamaged;

    //CharacterBehaviour characterMovement;

    //To display health on screen
    public Text health;

    // Start is called before the first frame update
    void Awake()
    {
        //sets the currentHealth to be startHealth, which is 100
        currentHealth = startHealth;
        
        DisplayText();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //public because it is needed in enemydamage
    public void DoDamageOnPlayer(int damageAmount)
    {
        //_isDamaged = true;
        currentHealth -= damageAmount;
        DisplayText();
        //health.text = "Health: " + currentHealth;
        //if(currentHealth <= 0 /*&& !_isDead*/)
        //{
        //    Death();
        //}
    }

    public void AddHealthToPlayer(int healthAmount)
    {
        currentHealth += healthAmount;
        DisplayText();
    }

    /*void Death()
    {
        //_isDead, so this method won't be called again
        //_isDead = true;
        characterMovement.enabled = false;
    }*/

    void DisplayText()
    {
        if(currentHealth <= 0)
        {
            health.text = "GAME OVER!";
        }
        health.text = "Current health:" + currentHealth;
    }
}
