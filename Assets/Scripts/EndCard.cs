using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCard : MonoBehaviour
{
    public Text deadEnemies;
    public Text Score;
    public Text hBonus;
    public Text Rank;
    public Text Counter;
    public static int OverallDead;

    int dead;
    int Scored;
    int Bonus;
    int count;

    GameObject enemyTotal;



    // Start is called before the first frame update
    void Start()
    {
        count = ComboCounter.HighestCount;
        Bonus = CharacterStats.FinalHealth;
        dead = OverallDead;

        End();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void End()
    {
        //findinf the final rank
        deadEnemies.text = dead.ToString("0");
        hBonus.text = Bonus.ToString("0");
        Counter.text = count.ToString("0");

        Scored = dead + Bonus + count;


        Score.text = Scored.ToString("0");

        getRank(Scored);
    }

    void getRank(int Points)
    {
        if (Points >= 547)
        {
            Rank.text = "S";

        }
        else if (Points < 547 && Points > 470)
        {
            Rank.text = "A";
        }
        else if (Points < 470 && Points > 400)
        {
            Rank.text = "B";

        } else if (Points < 400 && Points > 300) {

            Rank.text = "C";
        }



    }



}
