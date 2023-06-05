using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
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
        if (Gold.NumberOfGold >=5)
        {
            Gold.NumberOfGold -= 5;
            // FAIRE INVOCATION UNITE
        }
    }
    public void Magician()
    {
        if (Gold.NumberOfGold >= 10)
        {
            Gold.NumberOfGold -= 10;
            // FAIRE INVOCATION UNITE
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
