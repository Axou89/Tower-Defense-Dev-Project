using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Magic : MonoBehaviour
{
    public int NumberOfMagic;
    public Slider MagicSlider;
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
        NumberOfMagic += 5;
        MagicSlider.value = NumberOfMagic;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(enumerator());
    }
}
