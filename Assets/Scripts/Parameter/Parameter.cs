using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Parameter : MonoBehaviour
{
    [SerializeField]
    private GameObject ParameterScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {

        ParameterScreen.SetActive(true);
            
    }
    public void Close()
    {
        ParameterScreen.SetActive(false);
    }
}
