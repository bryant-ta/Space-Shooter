using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Retrieve list of highscores and names and display.
public class LeaderboardController : MonoBehaviour {

    public Text leaderboardText;

	void Start () {

        for (int i = GlobalVariables.playerNameList.Count-1; i >= 0; i--)
        {
            leaderboardText.text += GlobalVariables.playerNameList[i] + "\t\t\t\t\t\t\t\t" + GlobalVariables.scoreList[i] + "\n";
        }
    }
}
