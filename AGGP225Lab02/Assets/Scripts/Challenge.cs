using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge : MonoBehaviour
{
    public RPSC Player;
    public RPSC Opponent;
    public GameObject playerchoice;
    public GameObject opponentchoice;
    public CardUI PlayerUI;
    public CardUI OpponentUI;
    public GameObject displayai;
    public CardUI OpponentUICheck;
    public RPSC fire;
    public RPSC Air;
    public RPSC Paper;
    public RPSC Rock;
    public RPSC Scissors;
    public RPSC Sponge;
    public RPSC Water;
    public int randomindex;
    public int PlayerScore = 0;
    public int OpponentScore = 0;
    public Text PlayerS;
    public Text OpS;

    public enum ChallengeResult
    {
        win,
        lose,
        draw
    }
    public void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            PerformChallenge(Player, Opponent);
        }


            randomindex = Random.Range(0, 6);


            if (randomindex == 0)
            {
                Opponent = fire;
            }
            if (randomindex == 1)
            {
                Opponent = Air;
            }
            if (randomindex == 2)
            {
                Opponent = Paper;
            }
            if (randomindex == 3)
            {
                Opponent = Rock;
            }
            if (randomindex == 4)
            {
                Opponent = Scissors;
            }
            if (randomindex == 5)
            {
                Opponent = Sponge;
            }
            if (randomindex == 6)
            {
                Opponent = Water;
            }

        PlayerS.text = PlayerScore.ToString();
        OpS.text = OpponentScore.ToString();
        
    }

    public void PlayerChoice(GameObject choice)
    {
        playerchoice = choice;
        PlayerUI = playerchoice.gameObject.GetComponent<CardUI>();
        Player = PlayerUI.cardDef;
    }
    
    

    public void DisplayAiCard(RPSC Opponentcard)
    {
       
        OpponentUICheck.cardDef = Opponent;
        OpponentUI.cardDef = OpponentUICheck.cardDef;
        OpponentUI.setupCard();
        displayai.SetActive(true);
    }

    public void Confirm()
    {
        DisplayAiCard(Opponent);
        PerformChallenge(Player, Opponent);

    }

    public ChallengeResult PerformChallenge(RPSC PlayerCard, RPSC OtherCard)
    {
        if (PlayerCard.loseto.Contains(OtherCard))
        {
            OpponentScore++;
            Debug.Log("you lose");
            return ChallengeResult.lose;
        }
        else if(PlayerCard.winto.Contains(OtherCard))
        {
            PlayerScore++;
            Debug.Log("you win");
            return ChallengeResult.win;
        }
        else 
        {
            Debug.Log("draw");
            return ChallengeResult.draw;
        }


        
    }
}
