using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Invocation : NetworkBehaviour
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
    public void SkeletonServer()
    {
        Debug.Log("Tentative d'invocation de squelette...");
        if (IsHost || IsServer)
        {
            Debug.Log("Admin");
            SkeletonServerRpc();

        }
        else
        {
            Debug.Log("client");
            NetworkObject networkObject = GetComponent<NetworkObject>();
            networkObject.Invoke("SkeletonServerRpc", 0f);
        }
    }

    [ServerRpc(RequireOwnership = false )]
    public void SkeletonServerRpc()
    {
        Debug.Log("Invocation");

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
                    NetworkObject InvocationMonsterObject = Monster.GetComponent<NetworkObject>();
                    Monster.GetComponent<NetworkObject>().Spawn(); ;   // Marche mais ça spawn que si serveur ou host
                    Monster.tag = "MobAlly";
                    SummonMidP1(Monster);
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(82, 2.14f, 49.62f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    SummonMidP2(Monster);
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
                    SummonTopP1(Monster);
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(82, 2.14f, 69.3f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    SummonTopP2(Monster);
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
                    SummonTop2P2(Monster);
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(83.3f, 2.14f, 75.4f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    SummonTop2P2(Monster);
                    Debug.Log("Squelette equipe2 invoqué");
                }
            }
        }


        else if (Lane.Bot == true)
        {
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Bot = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(15f, 2.14f, 31.3f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    SummonBotP1(Monster);
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(81.5f, 2.14f, 31.3f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    SummonBotP2(Monster);
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
                    SummonBot2P1(Monster);
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Squelette, new Vector3(81.5f, 2.14f, 26.1f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    SummonBot2P2(Monster);
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
        if (Lane.Middle == true)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Middle = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(15f, 2.14f, 49.62f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Magicien equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(82, 2.14f, 49.62f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Magicien equipe2 invoqué");
                }
            }
        }
        else if (Lane.Top == true)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Top = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(15f, 2.14f, 69.3f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Magicien equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(82, 2.14f, 69.3f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Magicien equipe2 invoqué");
                }
            }
        }
        else if (Lane.Top2 == true)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Top2 = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(15f, 2.14f, 75.4f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Magicien equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(83.3f, 2.14f, 75.4f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Magicien equipe2 invoqué");
                }
            }
        }


        else if (Lane.Bot == true)
        {
            if (Gold.NumberOfGold >= 10)
            {
                Gold.NumberOfGold -= 10;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Bot = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(15f, 2.14f, 31.3f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Squelette equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(81.5f, 2.14f, 31.3f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Magicien equipe2 invoqué");
                }
            }
        }
        else if (Lane.Bot2 == true)
        {
            if (Gold.NumberOfGold >= 10)
            {

                Gold.NumberOfGold -= 10;
                Debug.Log("Invocation du Player : " + Choix.Player);
                Lane.Bot2 = false;
                if (Choix.Player == 1)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(15f, 2.14f, 26.1f), Quaternion.identity);
                    Monster.tag = "MobAlly";
                    Debug.Log("Magicien equipe1 invoqué");
                }
                else if (Choix.Player == 2)
                {
                    GameObject Monster = Instantiate(Magicien, new Vector3(81.5f, 2.14f, 26.1f), Quaternion.identity);
                    Monster.tag = "MobEnemy";
                    Debug.Log("Magicien equipe2 invoqué");
                }

            }
        }
        else
        {
            Debug.Log("too late");
            // Faire Msg (" vous devez cliquer sur une lane d'abords ) 
        }

    }

    private void SummonMidP1(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("3rdLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = 1; i < points.Length; i++)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonMidP2(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("3rdLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = points.Length - 1; i >= 1; i--)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonTopP1(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("1stLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = 1; i < points.Length; i++)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonTopP2(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("1stLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = points.Length - 1; i >= 1; i--)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonTop2P1(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("2ndLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = 1; i < points.Length; i++)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonTop2P2(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("2ndLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = points.Length - 1; i >= 1; i--)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonBotP1(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("4thLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = 1; i < points.Length; i++)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonBotP2(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("4thLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = points.Length - 1; i >= 1; i--)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonBot2P1(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("5thLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = 1; i < points.Length; i++)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
        }
    }

    private void SummonBot2P2(GameObject Monster)
    {
        int count = 0;
        GameObject lane = GameObject.Find("5thLane");
        Transform[] points = lane.GetComponentsInChildren<Transform>();
        for (int i = points.Length - 1; i >= 1; i--)
        {
            Monster.GetComponent<Mob>().Points[count] = points[i];
            count++;
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
