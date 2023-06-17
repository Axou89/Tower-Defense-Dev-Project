using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoosePlayer : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas1;
    [SerializeField]
    private Canvas canvas2;

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
        
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
        ChoixPlayer.SetActive(false);
        Player = 1;
    }
    public void J2()
    {
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
        ChoixPlayer.SetActive(false);
        Player = 2;

    }
}
