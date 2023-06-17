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
        Debug.Log("Middle Click");
            Middle = true;
        }
    }
    public void TopLane()
    {
        if (Middle == false && Top == false && Top2 == false && Bot == false && Bot2 == false)
        {
        Debug.Log("Top lane clicked ! ");
            Top = true;
        }
    }
    public void TopLane2()
    {
        if (Middle == false && Top == false && Top2 == false && Bot == false && Bot2 == false)
        {
        Debug.Log("Top lane 2 clicked ! ");
            Top2 = true;
        }
    }
    public void BotLane()
    {
        if (Middle == false && Top == false && Top2 == false && Bot == false && Bot2 == false)
        {
        Debug.Log("Bot lane clicked ! ");
            Bot  = true;
        }
    }
    public void BotLane2()
    {
        if (Middle == false && Top == false && Top2 == false && Bot == false && Bot2 == false)
        {
        Debug.Log("Bot lane 2 clicked ! ");
            Bot2 = true;
        }
    }
}
