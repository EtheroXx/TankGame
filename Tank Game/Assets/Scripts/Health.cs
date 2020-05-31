using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    bool isPlayer;

    public int startingHealth = 100;

    private float currentHealth;
    private bool isDead;

    void OnEnable()
    {
        currentHealth = startingHealth;
        isDead = false;
        isPlayer = gameObject.tag == "Player";
    }

    public void TakeDamage (float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        isDead = true;
        FindObjectOfType<GameManager>().Destroyed(isPlayer);
        gameObject.SetActive(false);
    }
}
