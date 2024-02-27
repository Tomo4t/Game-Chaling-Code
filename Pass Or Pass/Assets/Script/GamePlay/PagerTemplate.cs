using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PagerTemplate
{
    public  Sprite Stamp;
    public int[] Date = new int[3], ExpDate = new int[3];

    public string 
        Type,
        TypeScandery,
        OwnerName,
        SenderName,
        AboutMain,
        AboutSecndery,
        From,
        To
        ;
    
    public float 
        Weight, 
        AlowedWhight, 
        Price, 
        Cost
        ;

    public bool isCoreact;

    public int 
        keyCod, 
        Amount,
        AlowedAmont
        ;
    public void CopyData(PagerTemplate other)
    {
        // Copy all fields from 'other' to 'this'
        this.Stamp = other.Stamp;

       
        Array.Copy(other.Date, this.Date, other.Date.Length);
        Array.Copy(other.ExpDate, this.ExpDate, other.ExpDate.Length);

        this.Type = other.Type;
        this.TypeScandery = other.TypeScandery;
        this.OwnerName = other.OwnerName;
        this.SenderName = other.SenderName;
        this.AboutMain = other.AboutMain;
        this.AboutSecndery = other.AboutSecndery;
        this.From = other.From;
        this.To = other.To;

        this.Weight = other.Weight;
        this.AlowedWhight = other.AlowedWhight;
        this.Price = other.Price;
        this.Cost = other.Cost;

        this.isCoreact = other.isCoreact;

        this.keyCod = other.keyCod;
        this.Amount = other.Amount;
        this.AlowedAmont = other.AlowedAmont;
    }
}
