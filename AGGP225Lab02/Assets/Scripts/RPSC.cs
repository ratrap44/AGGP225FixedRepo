using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public enum ChallangeResult
{
    Win,
    Lose,
    Draw

}

[CreateAssetMenu(fileName = "RPS card", menuName = "card")]
public class RPSC : ScriptableObject
{
    
     public enum Type
     {
        Rock,
        Paper,
        Scissors,
        Water,
        Air,
        Sponge,
        fire

     }
    public Type cardtype;
    public List<Type> loseto;
    public List<Type> winto;

    public ChallangeResult PerformChallenge(RPSC card)
    {
        if (cardtype == card.cardtype)
        {
            return ChallangeResult.Draw;
        }
        if (cardtype == Type.Rock && card.cardtype == Type.Paper)
        {

        }
    }
  
 
}

