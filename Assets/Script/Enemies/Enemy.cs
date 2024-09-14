using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    //Enemy const stats
    public float maxHealth = 10;
    public float damage = 22;

    //Enemy variable stats
    public float currentHealth = 10;

    [SerializeField] private GameObject exp;
    GameManager manager;
    Player player;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }

    private void OnDestroy()
    {
        manager.enemies.RemoveAt(0);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(exp, transform.position, Quaternion.identity);
    }
}
