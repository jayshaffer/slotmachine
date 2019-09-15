using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public float cash;
    public Text cashText;

    void Start()
    {
        
    }

    void Update()
    {
       cashText.text = cash.ToString(); 
    }

    public void AdjustCash(float amount){
       cash += amount; 
    }
}
