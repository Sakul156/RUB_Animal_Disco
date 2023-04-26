using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatCodes : MonoBehaviour
{
    private List<string> allCheatCodes = new List<string>();
    public bool isNinja = false;
    public bool isDoge = false;
    public bool isSquidgame = false;
    public bool isDrunk = false;
    private string currWord = "";
    private string searchedWord = "";
    private int currLetter = 0;

    private void Awake()
    {
        allCheatCodes.Add("ninja");
        allCheatCodes.Add("doge");
        allCheatCodes.Add("squidgame");
        allCheatCodes.Add("alcohol");

    }
    void Update()
    {
        getCurrWord();
        checkNinja();
        checkDoge();
        checkSquidgame();
        checkDrunk();
    }

    private void getCurrWord()
    {
        if(Input.anyKey && Input.inputString.Length > 0)
        {
            char keyPressed = Input.inputString[0];
            keyPressed = char.ToLower(keyPressed);

            if (currWord == "")
            {
                for (int i = 0; i < allCheatCodes.Count; i++)
                {
                     if(keyPressed == allCheatCodes[i][0])
                    {
                        searchedWord = allCheatCodes[i];
                        currLetter = 0;
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(searchedWord) && currLetter < searchedWord.Length && keyPressed == searchedWord[currLetter])
            {
                currWord += keyPressed;
                currLetter += 1;
            }
            else
            {
                currWord = "";
                searchedWord = "";
                currLetter = 0;
            }
        }
    }
    private void checkNinja()
    {
        if(currWord is "ninja" && !isNinja)
        {
            isNinja = true;
            Debug.Log("NINJAAAMODE");
            currWord = "";
            searchedWord = "";
            currLetter = 0;
        }

        else if (currWord is "ninja" && isNinja)
        {
            isNinja = false;
            currWord = "";
            searchedWord = "";
            currLetter = 0;
            Debug.Log("Ninja deactivated");
        }
    }

    private void checkDoge()
    {
        if (currWord is "doge" && !isDoge)
        {
            isDoge = true;
            Debug.Log("DOGEMODE");
            currWord = "";
            searchedWord = "";
            currLetter = 0;
        }

        else if (currWord is "doge" && isDoge)
        {
            isDoge = false;
            currWord = "";
            searchedWord = "";
            currLetter = 0;
            Debug.Log("Doge deactivated");

        }
    }

    private void checkSquidgame()
    {
        if (currWord is "squidgame" && !isSquidgame)
        {
            isSquidgame= true;
            Debug.Log("SQUIIIDGAMEEEE");
            currWord = "";
            searchedWord = "";
            currLetter = 0;
        }

        else if (currWord is "squidgame" && isSquidgame)
        {
            isSquidgame = false;
            currWord = "";
            searchedWord = "";
            currLetter = 0;
            Debug.Log("Squidgame deactivated");

        }
    }

    private void checkDrunk()
    {
        if (currWord is "alcohol" && !isDrunk)
        {
            isDrunk = true;
            Debug.Log("IM FUCKING DRUNK");
            currWord = "";
            searchedWord = "";
            currLetter = 0;
        }

        else if (currWord is "alcohol" && isDrunk)
        {
            isDrunk = false;
            currWord = "";
            searchedWord = "";
            currLetter = 0;
            Debug.Log("Sober again");

        }
    }
}
