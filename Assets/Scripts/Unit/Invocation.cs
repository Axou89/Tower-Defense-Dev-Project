using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public ChoseLane Lane;
    public Gold Gold;
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
            if (Gold.NumberOfGold >=5)
            {
                Gold.NumberOfGold -= 5;
                // FAIRE INVOCATION UNITE Au mid
            }
        }
        else if (Lane.Top == true)
        {
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                // FAIRE INVOCATION UNITE Au mid
            }
        }
        else if (Lane.Top2 == true)
        {
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                // FAIRE INVOCATION UNITE Au mid
            }
        }
        else if (Lane.Bot == true)
        {
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                // FAIRE INVOCATION UNITE Au mid
            }
        }
        else if (Lane.Bot2 == true)
        {
            if (Gold.NumberOfGold >= 5)
            {
                Gold.NumberOfGold -= 5;
                // FAIRE INVOCATION UNITE Au mid*
                
            }
        }
        else
        {
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
