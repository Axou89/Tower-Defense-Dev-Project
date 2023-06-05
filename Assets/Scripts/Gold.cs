using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gold : MonoBehaviour
{
    public Text GoldText;
    public int NumberOfGold;
    public float i = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enumerator(i));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator enumerator(float i)
    {
        NumberOfGold += 1;
        GoldText.text = "Gold : " + NumberOfGold;
        yield return new WaitForSeconds(i);
        StartCoroutine(enumerator(i));
    }
}
