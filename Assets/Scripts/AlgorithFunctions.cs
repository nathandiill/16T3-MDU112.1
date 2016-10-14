using UnityEngine;
using System;
using System.Collections;

public class AlgorithFunctions : MonoBehaviour
{
    // Part 1: Experience for Next Level
    // Takes input from the players level and uses the value to return the xp required
    public float levelToXp(int playerLevel, float xpRequired)
    {
        float xpRequiredCalc = ((Mathf.Pow(playerLevel + 1, 3.25f)) - (Mathf.Pow(playerLevel, 3.25f)));
        Debug.Log(xpRequiredCalc + "XP required to level " + (playerLevel + 1));

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
            Debug.Log("Receive No Stat Bonus");
        }
        else if (floatingValue <= 50)
        {
            selectedStatBonus = 2;
            Debug.Log("Receive Agility Stat Bonus");
        }
        else if (floatingValue <= 75)
        {
            selectedStatBonus = 3;
            Debug.Log("Receive Recovery Stat Bonus:");
        }
        else if (floatingValue <= 100)
        {
            selectedStatBonus = 4;
            Debug.Log("Receive Armour Stat Bonus");
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

    // Part 3: Leveling Up
    // Current experience points are added with the gained experience points. If this value is greated than the
    // xp value required to reach the next level, the player is notified they leveled up with their new xp value
    public float experienceGain(int playerLevel, float currentExperiencePoints, float gainedExperiencePoints)
    {
        float xpToNextLevel = (Mathf.Pow(playerLevel + 1, 3.25f));

        float newExperiencePoints = (currentExperiencePoints + gainedExperiencePoints);
        if (newExperiencePoints > xpToNextLevel)
        {
            Debug.Log("Player has leveled up to " + (playerLevel + 1) + ", your current XP is now " + newExperiencePoints);
            playerLevel = (playerLevel + 1);
        }
        else
        {
            Debug.Log("Your current XP is now " + newExperiencePoints);
        }

        return newExperiencePoints;
    }

    // Part 4: Current Player Speed
    // Player agility stat is based between the stat values 1-5. Speed boost is 10% with a maximum speed of 9ms.
    // An if statement is implemented so any value above 5 is reduced to the top speed.
    public float playerCurrentSpeed(float playerAgility, bool speedBoostActive, float playerMaximumSpeed)
    {
        float playerCurrentSpeed = UnityEngine.Random.Range(1, 6);

        if (speedBoostActive == true)
        {
            playerCurrentSpeed = (playerAgility / 2) * 3 * 1.1f;
        }
        else
        {
            playerCurrentSpeed = (playerAgility / 2) * 3;
        }

        if (playerCurrentSpeed > 9)
        {
            playerCurrentSpeed = 9;
        }

        Debug.Log("Your current speed is " + playerCurrentSpeed);

        return playerCurrentSpeed;
    }
    
    // Run
    public void Start()
    {
        levelToXp(20, 1000);
        selectBonus(20);
        experienceGain(20, 30000, 50000);
        playerCurrentSpeed(5, true, 9);
    }
}

