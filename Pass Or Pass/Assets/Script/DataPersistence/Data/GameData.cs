using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public string Name;
    public int Money;
    public bool isMale;
    public int Day;
    public int[] date, usedFile;
    public int WeeklyNotice;
    public char Rank;
    public int Age;
    public int seed;
    public GameData()
    {
        Name = "Steve";

        Money = 200;

        isMale = true;

        Day = 0;

        Age = 30;

        date = new int[3] { 2010, 8, 1 };

        WeeklyNotice = 0;

        Rank = 'C';
        seed = 1231231234;


    }
}
