using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoosePlayer : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas1;

    [SerializeField]
    private GameObject ChoixPlayer;

    public int Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void J1()
    {
        
        ChoixPlayer.SetActive(false);
        Player = 1;
    }
    public void J2()
    {

        ChoixPlayer.SetActive(false);
        Player = 2;

    }
}
