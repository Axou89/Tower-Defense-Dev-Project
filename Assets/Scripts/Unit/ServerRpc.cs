using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerRpc : MonoBehaviour
{
    public Invocation invocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SqueletteServerCommand()
    {
        Debug.Log("Tentative 1..");
        invocation.SkeletonServerRpc();
    }
}
