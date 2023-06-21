using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int ScoreP1 = 0;
    public int ScoreP2 = 0;

    public Text ScoreP1Text;
    public Text ScoreP2Text;

    void Update()
    {
        ScoreP1Text.text = ScoreP1.ToString();
        ScoreP2Text.text = ScoreP2.ToString();
    }
}
