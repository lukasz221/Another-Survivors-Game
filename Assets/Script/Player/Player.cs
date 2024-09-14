using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player stats
    public float speed;
    public float maxHealth = 100;
    public float dmg = 2f;
    // Player exp
    public float lvlUpExpRequired = 10;
    public float exp = 0;
    public float level = 1;

    public float currentHealth;
    // Player other
    [SerializeField] private PlayerMovment playerMovment;

    private HealthBar healthBar;
    private ExpBar expBar;

    void Start()
    {
        healthBar = FindAnyObjectByType<HealthBar>();
        expBar = FindAnyObjectByType<ExpBar>();

        currentHealth = maxHealth;
        playerMovment.speed = speed;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
    }

    public void AddExp(float expAmount)
    {
        exp += expAmount;
        while (exp >= lvlUpExpRequired)
        {
            level++;
            exp = 0;
        }
    }

    public void Test()
    {
        Debug.Log("test");
    }
}
