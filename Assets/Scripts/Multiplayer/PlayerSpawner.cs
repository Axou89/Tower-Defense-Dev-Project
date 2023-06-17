using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (IsClient)
        {
            GameObject player = Instantiate(playerPrefab);
            string playerID = System.Guid.NewGuid().ToString();
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.SetPlayerID(playerID);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
