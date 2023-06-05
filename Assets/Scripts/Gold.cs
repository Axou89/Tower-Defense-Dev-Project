using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gold : MonoBehaviour
{
    public Text GoldText;
    public int NumberOfGold;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enumerator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator enumerator()
    {
        NumberOfGold += 1;
        GoldText.text = "Gold : " + NumberOfGold;
        yield return new WaitForSeconds(1);
        StartCoroutine(enumerator());
    }
}
