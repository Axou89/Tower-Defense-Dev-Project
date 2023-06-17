using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerCanvasController : NetworkBehaviour
{
    [SerializeField] private Canvas playerCanvas;
    private NetworkVariable<int> playerID = new NetworkVariable<int>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerID.Value);
        if (playerID.Value==1)
        {
            Debug.Log("Player1 online");
            playerCanvas.enabled = true;
        }
        else if (playerID.Value ==2)
        {
            Debug.Log("Player2 online");
            playerCanvas.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
