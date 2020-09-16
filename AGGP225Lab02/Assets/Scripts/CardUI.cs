using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    RPSC cardDef;
    Image Art;
    

    public void Start()
    {
        if(cardDef)
        {
            SetupCard();
        }
    }

    public void SetupCard()
    {
        
    }
}
