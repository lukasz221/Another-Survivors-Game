using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletDmg;
    private Player player;
    private void Start()
    {
        StartCoroutine(SelfDestruct());
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        bulletDmg = player.dmg;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDmg);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
