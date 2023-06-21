using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CannonBall : MonoBehaviour
{
    private Transform target;
    private int shotPower;
    private bool hasHitTarget;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetShotPower(int power)
    {
        this.shotPower = power;
    }

    private void Update()
    {
        if (target == null || hasHitTarget)
        {
            Destroy(gameObject);
            return;
        }

        // Déplace le boulet de canon vers l'ennemi
        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);
        float movementDistance = Mathf.Min(shotPower * Time.deltaTime, distance);
        transform.Translate(direction * movementDistance, Space.World);

        // Vérifie si le boulet de canon a atteint l'ennemi
        if (distance <= 2f)
        {
            HitTarget();
        }
    }

    private void HitTarget()
    {
        // Mettre effet collision ici

        // A touché
        hasHitTarget = true;

        // Cache le rendu
        GetComponent<Renderer>().enabled = false;

        // Désactive le collider quand ça touche
        GetComponent<Collider>().enabled = false;

        // Détruit le boulet après le hit
        Destroy(gameObject, 1f);

        if (target.GetComponent<Mob>().Shield)
        {
            target.GetComponent<Mob>().Shield = false;
        } else
        {
            target.GetComponent<Mob>().PV -= shotPower / target.GetComponent<Mob>().Armor;
        }
    }

    private void OnDestroy()
    {
        // S'assurer que la cible n'est plus référencée lorsque le boulet de canon est détruit
        if (target != null)
        {
            target = null;
        }
    }
}