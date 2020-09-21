using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    public RPSC cardDef;
    public Image artWork;
    public Text CardNameField;
    

    public void Start()
    {
        if (cardDef)
        {
            setupCard();
        }
    }
    public void setupCard()
    {
        artWork.sprite = cardDef.cardpic;
        //artWork.sprite = Sprite
        // CastingCostField.text = cardDef.ArtistName;
        CardNameField.text = cardDef.cardName;

    }
}
