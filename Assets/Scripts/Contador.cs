using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public static Contador instance;

    public TMP_Text starText;
    public int currentStars = 0;
    
    void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        starText.text = "Estrellas:" + currentStars.ToString();
    }

    // Update is called once per frame
    public void IncreaseStars(int v)
    {
        currentStars += v;
        starText.text = "Estrellas:" + currentStars.ToString();
    }
}
