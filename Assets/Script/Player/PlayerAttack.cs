using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float cooldown = 0.1f;
    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;
        if (nearestEnemy != null)
        {
            // Obliczenie kierunku do przeciwnika
            Vector3 directionToEnemy = (nearestEnemy.transform.position - playerTransform.position).normalized;

            // Obliczenie pozycji pocisku w odległości 2 jednostek od gracza w kierunku przeciwnika
            Vector3 bulletSpawnPosition = playerTransform.position + directionToEnemy * 1;

            // Ustawienie rotacji pocisku na podstawie rotacji gracza
            Quaternion bulletRotation = playerTransform.rotation * Quaternion.Euler(0, 0, -90);

            // Instancjonowanie pocisku w odpowiednim miejscu
            var b = Instantiate(bullet, bulletSpawnPosition, bulletRotation);

            // Nadanie prędkości pociskowi w kierunku przeciwnika
            b.GetComponent<Rigidbody>().velocity = directionToEnemy * bulletSpeed;
        }
    }


    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy1");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        Vector3 playerPosition = playerTransform.position;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(playerPosition, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null)
        {
            Debug.DrawLine(playerPosition, nearestEnemy.transform.position, Color.red);
        }
        return nearestEnemy;
    }
}
