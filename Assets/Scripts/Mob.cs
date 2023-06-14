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
    public Transform[] Points;

    private bool isMoving = true;
    private int currentPosition = 1;
    private int lenPosition;
    private bool isInvincible = false;

    void Start()
    {
        this.transform.position = Points[0].position;
        lenPosition = Points.Length;
    }

    void Update()
    {
        if (PV <= 0)
        {
            Destroy(gameObject);
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[currentPosition].position, Speed * Time.deltaTime);
            if (transform.position == Points[currentPosition].position)
            {
                currentPosition++;
                if (currentPosition >= lenPosition)
                {
                    isMoving = false;
                }
            }
        }
    }

    IEnumerator GetHit(Collider other)
    {
        while (!isInvincible)
        {
            isMoving = false;
            // Start animation attack
            if (other.gameObject.GetComponent<Mob>().Shield)
            {
                other.gameObject.GetComponent<Mob>().Shield = false;
            }
            else
            {
                other.gameObject.GetComponent<Mob>().PV -= AD / Armor + AP / RM;
            }

            isInvincible = true;
            yield return new WaitForSeconds(0.5f);
        }
        
        isInvincible = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetType().ToString().Equals("UnityEngine.BoxCollider") && !this.CompareTag(other.gameObject.tag) && !isInvincible)
        {
            StartCoroutine(GetHit(other));
        }
    }
}
