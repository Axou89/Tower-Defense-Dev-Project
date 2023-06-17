using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public ChoseLane Lane;
    public Gold Gold;

    [SerializeField]
    private ChoosePlayer Choix;

    [SerializeField]
    private GameObject Squelette;
    [SerializeField]
    private GameObject Magicien;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Skeleton()
    {
        if (Lane.Middle == true)
        {
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Middle = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(15f, 2.14f, 49.62f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(82, 2.14f, 49.62f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Squelette equipe2 invoqué");
                }
            }
        }
        else if (Lane.Top == true)
        {
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Top = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(15f, 2.14f, 69.3f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(82, 2.14f, 69.3f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Squelette equipe2 invoqué");
                }
            }
        }
        else if (Lane.Top2 == true)
        {
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Top2 = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(15f, 2.14f, 75.4f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(83.3f, 2.14f, 75.4f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Squelette equipe2 invoqué");
                }
            }
        }


        else if (Lane.Bot == true)
        {
            Debug.Log("tt");
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Bot = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(15f, 2.14f, 31.3f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(81.5f, 2.14f, 31.3f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Squelette equipe2 invoqué");
                }
            }
        }
        else if (Lane.Bot2 == true)
        {
            if (Gold.NumberOfGold >= 5)
            {

                Gold.NumberOfGold -= 5;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Bot2 = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(15f, 2.14f, 26.1f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(81.5f, 2.14f, 26.1f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Squelette equipe2 invoqué");
                }

            }
        }
        else
        {
            Debug.Log("too late");
            // Faire Msg (" vous devez cliquer sur une lane d'abords ) 
        }
        }
    
    public void Magician()
    {
        if (Lane.Top2)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                // FAIRE INVOCATION UNITE
            }
        }
        else if (Lane.Top)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                // FAIRE INVOCATION UNITE
            }
        }

        else if (Lane.Middle)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                // FAIRE INVOCATION UNITE
            }
        }

        else if (Lane.Bot)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                // FAIRE INVOCATION UNITE
            }
        }

        else if (Lane.Bot2)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                // FAIRE INVOCATION UNITE
            }
        }
        else
        {
            // Faire Msg (" vous devez cliquer sur une lane d'abords ) 
        }

    }
    public void Upgrade1()
    {
        if (Gold.NumberOfGold >= 200)
        {
            Gold.i = Gold.i - ((10 * Gold.i)/100);
            Gold.NumberOfGold -= 200;
        }
    }
}
