using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject Duck;
    public GameObject[] Hat;
    public GameObject[] Hat2;
    public Color[] Couleur;

    [SerializeField]
    private GameObject ActualColor;

    private int HatCount;
    private int ColorCount;

    public GameObject HatOnduck;
    public Color ColorOnDuck;


    public MeshFilter[] MeshsDuck;
    public MeshFilter MeshDuck;
    // Start is called before the first frame update
    void Start()
    {
        HatCount = 0;
        ColorCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeHat()
    {

        if (HatCount == 8)
        {
            Hat[8].SetActive(false);
            Hat2[8].SetActive(false);
        }
        HatCount += 1;
        if (HatCount >= Hat.Length-1)
        {
            HatCount = 0;
        }
        Hat[HatCount].SetActive(true);
        Hat2[HatCount].SetActive(true);
        if (HatCount != -1 && HatCount != 0)
        {
            
            Hat[HatCount-1].SetActive(false);
            Hat2[HatCount-1].SetActive(false);

        }
    }
    public void ChangeColor()
    {

        if (ColorCount>Couleur.Length-1)
        {
            ColorCount = 0;
        }
        ColorCount += 1;
        ActualColor.GetComponent<RawImage>().color = Couleur[ColorCount];
        MeshDuck.mesh = MeshsDuck[ColorCount].mesh;

    }
}
