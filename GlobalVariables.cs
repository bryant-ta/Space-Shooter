using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Global variables, stays constant through level loads.
public static class GlobalVariables {

    public static int lives = 5;
    public static int score = 100000;

    //Allows time slow powerup
    public static float globalSpeed = 1;

    public static List<string> playerNameList = new List<string>() { "-----", "-----", "-----", "-----", "-----", "-----", "-----", "-----", "-----", "-----" };
    public static List<int> scoreList = new List<int>() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
}
