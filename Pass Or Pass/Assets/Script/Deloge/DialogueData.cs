using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum DilogeType 
    {
      Brib,
      Normail,
    }

    [System.Serializable]
    public class Speatch 
    { 
         [SerializedDictionary("BobNum", "Line")] public AYellowpaper.SerializedCollections.SerializedDictionary<int, string> Diloge;

         [HideInInspector] public bool GiveBrib = false;
         [HideInInspector] public bool LastLine = false;
}
    
    [System.Serializable]
    public class DilogeFeald
    {
        [SerializedDictionary("Parsen Tyep", "Spetsh")] public AYellowpaper.SerializedCollections.SerializedDictionary<DilogeType, Speatch> Person;

        
        DilogeType currentStat;
    }


