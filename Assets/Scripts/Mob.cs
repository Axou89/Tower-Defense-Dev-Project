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
    public string Player;

    private bool isMoving = true;
    private int currentPosition = 1;
    private int lenPosition;
    private bool isInvincible = false;
    private Vector3 movementDirection;

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

            Quaternion targetRotation = Quaternion.LookRotation(transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);

            if (transform.position == Points[currentPosition].position)
            {
                currentPosition++;
                if (currentPosition >= lenPosition)
                {
                    isMoving = false;
                }
            }
        }

        RayHit();

        /*
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var objectHit = hit.transform.gameObject;
            if (objectHit != null)
            {
                if (Player == "P1" && objectHit.CompareTag("TowerP2"))
                {
                    Debug.Log("test");
                    Destroy(objectHit);
                } else if (Player == "P2" && objectHit.CompareTag("TowerP1"))
                {
                    Destroy(objectHit);
                }
            }
        }
        */

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

    private void RayHit()
    {
        /*
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            GameObject objectHit = hit.transform.gameObject;
            if (Player == "P1" && objectHit.CompareTag("TowerP2"))
            {
                Debug.Log("Test");
                Destroy(objectHit);
            } else if (Player == "P2" && objectHit.CompareTag("TowerP1"))
            {
                Destroy(objectHit);
            }
        }
        */

        float raycastDistance = 5f;

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit[] hits = Physics.RaycastAll(ray, raycastDistance);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            GameObject hitObject = hit.collider.gameObject;

            if (Player == "P1" && hitObject.CompareTag("TowerP2"))
            {
                Destroy(hitObject);
            } else if (Player == "P2" && hitObject.CompareTag("TowerP1"))
            {
                Destroy(hitObject);
            }
        }
    }
}
