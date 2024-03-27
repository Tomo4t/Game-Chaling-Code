using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemestypes
{ 
    furniture,electronics,dicorations,lihgting,office

}

[CreateAssetMenu(fileName = "shop item")]


public class ShopItemSO : ScriptableObject

{
    public Itemestypes type;

    public string title;
    public int price;
    public int ID;
   [HideInInspector] public ShopTemplate template;
    
}

