using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public int AD;
    public int AP;
    public int Armor;
    public int RM;
    public int PV;
    public bool Shield;
    public float Speed;
    public float AttackSpeed;
    public float Range;
    public float GoldPrice;
    public Transform SpawnPoint;
    public Transform EndPoint;

    private bool isMoving = true;

    void Start()
    {
        this.transform.position = SpawnPoint.position;
    }

    void Update()
    {
        if (PV <= 0)
        {
            Destroy(gameObject);
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.position, Speed * Time.deltaTime);

            if (transform.position == EndPoint.position)
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType().ToString().Equals("UnityEngine.BoxCollider") && !this.CompareTag(other.gameObject.tag))
        {
            isMoving = false;
            // Start animation attack
            bool EnemyShield = other.gameObject.GetComponent<Mob>().Shield;
            if (EnemyShield)
            {
                EnemyShield = false;
            } else
            {
                other.gameObject.GetComponent<Mob>().PV -= AD / Armor + AP / RM;
            }
        }
    }
}
