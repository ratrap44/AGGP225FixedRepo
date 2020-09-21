using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "RPS card", menuName = "card")]
public class RPSC : ScriptableObject
{
    public Sprite cardpic;

    public string cardName;


    
    public List<RPSC> loseto;
    public List<RPSC> winto;

  


}

