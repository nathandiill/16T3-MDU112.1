using UnityEngine;
using System;
using System.Collections;

public class AlgorithFunctions : MonoBehaviour
{
    int playerLevel = 1;
    float xpRequired = 1;

    // Part 1: XP Algorithm
    // Takes input from the players level and uses the value to return the xp required
    public float levelToXp(int playerLevel, float xpRequired)
    {
        float xpRequiredCalc = ((Mathf.Pow(playerLevel + 1, 3.25f)) - (Mathf.Pow(playerLevel, 3.25f)));
        Console.WriteLine(xpRequiredCalc + "to level" + (playerLevel + 1));

        xpRequiredCalc = xpRequired;
        return xpRequired;
    }

    // Part 2: Level Up Bonus
    // By assuming a level range of 1-40 a stat is assigned by level and preference (high levels have a low chance for the best stat)
    // An IF statment for each level bracket with the 4 possible stats inside each IF statement for the level bracket.

    // Int 1 = No Stat, Int 2 = Agility Stat, Int 3 = Recovery Stat, Int 4 = Armour Stat.
    // Re usable function to handle the choice of stat
    public int chooseWhichStat(int Min, int Max)
    {
        int floatingValue = UnityEngine.Random.Range(Min, Max);
        int selectedStatBonus = 1;

        if (floatingValue <= 25)
        {
            selectedStatBonus = 1;
            Console.WriteLine("Receive No Stat Bonus");
        }
        else if (floatingValue <= 50)
        {
            selectedStatBonus = 2;
            Console.WriteLine("Receive Agility Stat Bonus");
        }
        else if (floatingValue <= 75)
        {
            selectedStatBonus = 3;
            Console.WriteLine("Receive Recovery Stat Bonus:");
        }
        else if (floatingValue <= 100)
        {
            selectedStatBonus = 4;
            Console.WriteLine("Receive Armour Stat Bonus");
        }

        return selectedStatBonus;
    }

    // Function input with each level bracket's particular stat chances
    public int selectBonus(int playerLevel)
    {
        int selectedStatBonus = 1;

        if (playerLevel <= 10)
        {
            selectedStatBonus = chooseWhichStat(21, 101);
        }
        else if (playerLevel <= 20)
        {
            selectedStatBonus = chooseWhichStat(16, 96);
        }
        else if (playerLevel <= 30)
        {
            selectedStatBonus = chooseWhichStat(11, 91);
        }
        else if (playerLevel <= 35)
        {
            selectedStatBonus = chooseWhichStat(6, 86);
        }
        else if (playerLevel <= 40)
        {
            selectedStatBonus = chooseWhichStat(1, 81);
        }

        return selectedStatBonus;
    }
}

