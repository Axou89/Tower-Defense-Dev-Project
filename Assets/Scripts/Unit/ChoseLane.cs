using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseLane : MonoBehaviour
{
    public bool Middle;
    public bool Top;
    public bool Top2;
    public bool Bot;
    public bool Bot2;

    // Start is called before the first frame update
    void Start()
    {
        Middle = false;
        Top = false;
        Top2 = false;
        Bot = false;
        Bot2 = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MiddleLane()
    {
        if (Middle == false && Top == false && Top2 == false && Bot == false && Bot2 == false)
        {
            Debug.Log("Middle lane clicked ! ");
            Middle = true;
        }
    }
    public void TopLane()
    {
        Debug.Log("Top lane clicked ! ");
    }
    public void TopLane2()
    {
        Debug.Log("Top lane 2 clicked ! ");
    }
    public void BotLane()
    {
        Debug.Log("Bot lane clicked ! ");
    }
    public void BotLane2()
    {
        Debug.Log("Bot lane 2 clicked ! ");
    }
}
