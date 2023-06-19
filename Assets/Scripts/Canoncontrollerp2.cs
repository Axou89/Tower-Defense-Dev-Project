using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canoncontrollerp2 : MonoBehaviour
{
    public GameObject cannonBallPrefab; // Prefab du boulet de canon
    public Transform spawnPoint; // Spawn boulet
    public float fireRate = 3f; // Attackspeed
    public float shotPower = 30f; // shotpower
    public float maxDetectionDistance = 30f; // Range

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        // Vérifie si le temps écoulé dépasse l'attackspeed
        if (timer >= fireRate)
        {
            // Vérifie si un ennemi est dans la zone du collider
            Collider[] colliders = Physics.OverlapBox(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.extents, Quaternion.identity);
            if (colliders.Length > 0)
            {
                // Spawn boulet
                GameObject cannonBallGO = Instantiate(cannonBallPrefab, spawnPoint.position, Quaternion.identity);
                CannonBall cannonBall = cannonBallGO.GetComponent<CannonBall>();

                // la puissance de tir
                cannonBall.SetShotPower(shotPower);

                // suis l'ennemi
                cannonBall.SetTarget(GetNearestEnemy());

                timer = 0f; // Remet à zero le compteur de tir
            }
        }
    }

    private Transform GetNearestEnemy()
    {
        // Récuperer le mob le plus proche
        // Return le transform de l'ennemi

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("MobP1");
        Transform nearestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // Check Range tower
            if (distance < closestDistance && distance <= maxDetectionDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }
}