
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using AYellowpaper.SerializedCollections;
using System.Diagnostics.Tracing;
using UnityEditor.Rendering;

[System.Serializable]
public class Days {
   
    [SerializedDictionary("Type", "Amount")] public AYellowpaper.SerializedCollections.SerializedDictionary<Types, List<DilogeFeald>> DoucementsBearDay; 
}

[System.Serializable]
public class Pearson 
{
    public PagerTemplate DoamintInfo;

    public Speatch Speatch;

    public int DayCorrectPapers = 0;

    public Pearson(PagerTemplate doamintInfo, Speatch speatch)
    {
        DoamintInfo = doamintInfo;
        Speatch = speatch;
    }
}

public class Asiner : MonoBehaviour, IDataPersistence
    {

    [SerializedDictionary("Type", "Stamp" )]
    public AYellowpaper.SerializedCollections.SerializedDictionary<Types, Sprite> Stmps;

    [HideInInspector] public static Pearson CurintClint;

   [SerializeField]
   public List<Days> Day;

    private int FalsMade = 0;

    public TMP_Text
            DateMain,
            DateSecnd,
            TypeMain,
            TypeSecand,
            KeyCode, //keycodes are set from 1 to 9, 1 to 4 import, 5 to 7 export , 8 and 9 transite
            TypeKode, //in doucementsData
            TypeType,
            OwnerName,
            OwnerNameSecand,
            SenderName,
            Whight,
            AllowedWhight,
            Amount,
            AmountSecand,
            AllowedAmount,
            price,
            FrromWhere,
            TOWhere,
            CostCul,
            CostFinal,
            Moany,
            Date;


        public SpriteRenderer 
        StampMain,
        StampLogo;


        public Sprite 
        Abrove, 
        Denay,
        empty;

    private int day = 0 , moany;
    [HideInInspector] public int curectPapers;

    [HideInInspector] public int SelectedItems;

    public Dictionary<Types, int> Bribes = new Dictionary<Types, int>();
    
    [SerializeField] 
    public List<Pearson> Templates = new List<Pearson>();

    private string[] names, countres;

    private int[] date;

    public static Asiner Instince;
   
    private void Start()
    {
        names = PlayerPrefs.GetInt("Lung", 1) == 1 ? DoucementsData.Names : DoucementsData.arabicNames;
        countres = PlayerPrefs.GetInt("Lung", 1) == 1 ? DoucementsData.countries : DoucementsData.arabiccountries;
        DataPersistenceManager.Instance.LoadGame();
        Moany.text = moany.ToString();
        
        if (Instince == null)
            Instince = this;
        if (Day.Count - 1 >= day)
        {
            foreach (var item1 in Day[day].DoucementsBearDay)
            {
                MakeData(item1.Value.Count, item1.Key, item1.Value);

            }

        }
        else
        {
            day = 0;
            foreach (var item1 in Day[day].DoucementsBearDay)
            {
                MakeData(item1.Value.Count, item1.Key, item1.Value);

            }

        }

        NextCharecter();

    }
    public void NextCharecter() 
    {
        var v = ChoseData(ref Templates);
        if (v != null)
        {
            AsineText(v);
            CustomersMovement.instance.phoneEnabled = true;
        }
        else
        {
            CustomersMovement.instance.phoneEnabled = false;
            EndGame();
        }
    }
    public void UpdateMony(int Add)
    {
        moany += Add;
        Moany.text = moany.ToString();
    }

    public void EndGame() 
    {
        StopAllCoroutines();
        DataHolder.Bribes = Bribes;
        DataPersistenceManager.Instance.SaveGame();
        loadscenes.instance.loadenextscene(PlayerPrefs.GetInt("Lung", 1) == 1 ? "DayResult": "ArDayResult");
        Debug.Log("Go to the result sean"); }


        private void MakeData(int NumToMake, Types type, List<DilogeFeald> diloges)
        {


           int MaxUncorrectFeilds = UnityEngine.Random.Range(7 - day > 0 ? (7 - day) : 1, 10 - day > 0 ? (10 - day) : 2) ;

           int FalssCount  = UnityEngine.Random.Range(1, NumToMake);
           int bridcount = FalssCount / UnityEngine.Random.Range(2, 3);
           

          for (int i = 0; i < NumToMake; i++)
          {
             PagerTemplate template = new PagerTemplate();
             DilogeFeald diloge = diloges[i];
            

            #region initiate data;

            template.isCoreact = true;
            string[] temp;
            Dictionary<Types, string[]> TypesData = DoucementsData.TypeData();
            
            Dictionary<Types, int> TypesCode = DoucementsData.TypeCode();

            

            TypesData.TryGetValue(type, out temp);
            int num = UnityEngine.Random.Range(0, temp.Length);

            template.Type = type.ToString();
            
            template.TypeScandery = type.ToString();

            TypesCode.TryGetValue(type, out template.TypeCode);

            template.OwnerName = names[UnityEngine.Random.Range(0, names.Length)];
            template.OwnerNameSecand = template.OwnerName;

            template.SenderName = names[UnityEngine.Random.Range(0, names.Length)];

            template.Date[0] = date[0];

            template.Date[1] = UnityEngine.Random.Range(1, date[1]);

            template.Date[2] = UnityEngine.Random.Range(1, date[2]);

            template.ExpDate[0] = UnityEngine.Random.Range(date[0] + 1, 2030);

            template.ExpDate[1] = UnityEngine.Random.Range(date[1] , 12);

            template.ExpDate[2] = UnityEngine.Random.Range(date[2] +1, 28);

            template.AboutMain = temp[num];


            #region Wight, Price and Amount
            if (type == Types.Raw_Materials)
            {
                template.Amount = UnityEngine.Random.Range(25, 50);
                template.Weight = UnityEngine.Random.Range(100, 200) * template.Amount;
                template.Price = UnityEngine.Random.Range(5, 15);

            }
            else if (type == Types.Materials)
            {
                template.Amount = UnityEngine.Random.Range(10, 50);
                template.Weight = UnityEngine.Random.Range(2, 8) * template.Amount;
                template.Price = UnityEngine.Random.Range(12, 20);

            }
            else if (type == Types.Vehicles)
            {
                template.Amount = UnityEngine.Random.Range(1, 10);
                template.Weight = UnityEngine.Random.Range(800, 1500) * template.Amount;
                template.Price = UnityEngine.Random.Range(20000, 50000);

            }
            else if (type == Types.Medicals)
            {
                template.Amount = UnityEngine.Random.Range(5, 20);
                template.Weight = UnityEngine.Random.Range(1, 5) * template.Amount;
                template.Price = UnityEngine.Random.Range(50, 150);

            }
            else if (type == Types.Organics)
            {
                template.Amount = UnityEngine.Random.Range(20, 100);
                template.Weight = UnityEngine.Random.Range(1, 5) * template.Amount;
                template.Price = UnityEngine.Random.Range(13, 31);

            }
            else if (type == Types.Electronics)
            {
                template.Amount = UnityEngine.Random.Range(1, 10);
                template.Weight = UnityEngine.Random.Range(0.2f, 4.0f) * template.Amount;
                template.Price = UnityEngine.Random.Range(100, 500);

            }

            template.Cost = template.Amount * template.Price;
            template.AlowedWhight = UnityEngine.Random.Range(template.Weight, template.Weight * 2);
            template.AlowedAmont = UnityEngine.Random.Range(template.Amount, template.Amount * 2);
            #endregion

            template.AboutSecndery = temp[num];
            int chance = UnityEngine.Random.Range(1, 3);
            if (chance == 1)
            {
                template.From = countres[UnityEngine.Random.Range(0, countres.Length)];
                template.To = PlayerPrefs.GetInt("Lung", 1) == 1 ? "Jordan" : "الأردن";
                template.keyCod = UnityEngine.Random.Range(1, 4);
            }
            else if (chance == 2)
            {
                template.From = PlayerPrefs.GetInt("Lung", 1) == 1 ? "Jordan" : "الأردن";
                template.To = countres[UnityEngine.Random.Range(0, countres.Length)];
                template.keyCod = UnityEngine.Random.Range(5, 7);
            }
            else
            {
                int safenet = 0;
                do
                {
                    safenet++;
                    template.From = countres[UnityEngine.Random.Range(0, countres.Length)];
                    template.To = countres[UnityEngine.Random.Range(0, countres.Length)];
                    template.keyCod = UnityEngine.Random.Range(8, 9);
                }
                while (template.From.Equals(template.To) && safenet<10);
            }



            Stmps.TryGetValue(type, out template.Stamp);

            #endregion

            PagerTemplate allareCoreacte;
            allareCoreacte = new PagerTemplate();
            allareCoreacte.CopyData(template);

           
            //make data Wrong
             if (i < FalssCount)
             {
                FalsMade++;
                int safenet = 0;
                template.isCoreact = false;

                System.Random random = new System.Random();
                do {
                    for (int z = 0; z < MaxUncorrectFeilds; z++)
                    {
                       
                        int RandomChance = UnityEngine.Random.Range(0, 14);
                        switch (RandomChance)
                        {

                            case 0:


                                do
                                {
                                    template.TypeScandery = ((Types)random.Next(Enum.GetValues(typeof(Types)).Length)).ToString();
                                } while (template.TypeScandery.Equals(allareCoreacte.Type) && safenet < 10);
                                break;

                            case 1:
                                
                                do  {
                                    
                                    safenet++;
                                    Types RandomType = ((Types)random.Next(Enum.GetValues(typeof(Types)).Length));
                                    Stmps.TryGetValue(RandomType, out template.SacnderStamp);
                                } while (template.SacnderStamp.Equals(allareCoreacte.Stamp) && safenet < 10);
                               
                                break;

                            case 2:
                                do
                                {
                                    safenet++;
                                    template.OwnerNameSecand = names[UnityEngine.Random.Range(0, names.Length)];
                                }
                                while (allareCoreacte.OwnerName.Equals(template.OwnerNameSecand) && safenet < 10);
                                break;

                            case 3:
                                template.Date[0] = UnityEngine.Random.Range(date[0] + 1,2015);
                                break;

                            case 4:
                                template.Date[1] = UnityEngine.Random.Range(date[1] , 12);
                                break;

                            case 5:
                                template.Date[2] = UnityEngine.Random.Range(date[2] + 1, 28);
                                break;

                            case 6:
                                template.ExpDate[0] = UnityEngine.Random.Range(date[0] - 10, date[0] - 1);
                                break;

                            case 7:
                                template.ExpDate[1] = UnityEngine.Random.Range(1, date[1] - 1);
                                break;

                            case 8:
                                template.ExpDate[2] = UnityEngine.Random.Range(1, date[2] - 1);
                                break;

                            case 9:
                                //do nothing
                                break;

                            case 10:
                                template.Weight = UnityEngine.Random.Range(template.Weight + 3, template.Weight * 2);
                               
                                break;

                            case 11:
                                template.Amount = UnityEngine.Random.Range(template.Amount + 1, template.Amount * 2);
                                break;

                            case 12:
                                //do nothing
                                break;
                            case 13:
                                chance = UnityEngine.Random.Range(1,3);
                                if (chance == 1)
                                {
                                    template.From = PlayerPrefs.GetInt("Lung", 1) == 1 ? "Jordan" : "الأردن";
                                    template.To = countres[UnityEngine.Random.Range(0, countres.Length)];
                                    template.keyCod = UnityEngine.Random.Range(1, 4);
                                }
                                else if (chance == 2)
                                {
                                    template.From = PlayerPrefs.GetInt("Lung", 1) == 1 ? "Jordan": "الأردن";
                                    template.To = countres[UnityEngine.Random.Range(0, countres.Length)];
                                    do {
                                        safenet++;
                                        template.keyCod = UnityEngine.Random.Range(1, 9);
                                       } 
                                    while (template.keyCod >4 && template.keyCod <8 && safenet < 10);
                                    
                                }
                                else
                                {
                                    do {
                                        safenet++;
                                        template.From = countres[UnityEngine.Random.Range(0, countres.Length)];
                                        template.To = countres[UnityEngine.Random.Range(0, countres.Length)];
                                        template.keyCod = UnityEngine.Random.Range(1, 7);
                                       }
                                    while (template.From.Equals(template.To) && safenet < 20);
                                    
                                }
                                break;
                            default:
                                //do nothing
                                break;
                        }

                    }
                   }
                while (ComperData(allareCoreacte,template) && safenet < 3 );
                
                if (safenet >= 10)
                    Debug.Log("Infint Loob Didected");
                
             }
            if (template.isCoreact == false && FalsMade > bridcount)
            {
                template.TackBribe = true;
            }
            else
            {
                template.TackBribe = false;
            }
           
            Pearson p = new Pearson(template, diloge.Person.GetValueOrDefault(template.isCoreact == false ? DilogeType.Brib : DilogeType.Normail));
            Templates.Add(p);
           }

        }


    private PagerTemplate ChoseData(ref List<Pearson> templates)
    {
        if (templates.Count > 0)
        {
            int Ran = UnityEngine.Random.Range(0, templates.Count);

            if (templates[Ran] != null)
            {
                PagerTemplate chosean = templates[Ran].DoamintInfo;
                CurintClint = templates[Ran];
                templates.Remove(templates[Ran]);

                return chosean;
            }
            else
                return null;
        }
        else
        {
            return null;
        }

    }
        private void AsineText(PagerTemplate template)
        {

        DateMain.text = template.Date[0] + " / " + template.Date[1] + " / " + template.Date[2] ;

        DateSecnd.text = template.ExpDate[0] + " / " + template.ExpDate[1] + " / " + template.ExpDate[2];

        TypeMain.text = template.Type;

        TypeSecand.text = template.TypeScandery;

        KeyCode.text = template.keyCod.ToString();

        TypeKode.text = template.TypeCode.ToString();

        TypeType.text = template.AboutMain;

        OwnerName.text = template.OwnerName;

        OwnerNameSecand.text = template.OwnerNameSecand;

        SenderName.text = template.SenderName;

        Whight.text = template.Weight + " Kg";

        AllowedWhight.text = template.AlowedWhight + " Kg";

        Amount.text = template.Amount.ToString();

        AmountSecand.text = template.Amount.ToString();

        AllowedAmount.text = template.AlowedAmont.ToString();

        price.text = template.Price.ToString();

        FrromWhere.text = template.From;

        TOWhere.text = template.To;

        CostCul.text = template.Price +" x " + template.Amount + "\n =";

        CostFinal.text = template.Cost + " JD";

        StampLogo.sprite = template.Stamp;



        Debug.Log("Iscprecte = " + template.isCoreact + " Tack Bribe = " + template.TackBribe);


    }
   

    private bool ComperData(PagerTemplate a, PagerTemplate b)
    {
        
        bool isSame = false;
        if ( a.ExpDate.Equals( b.ExpDate )&& a.Date.Equals(b.Date) && a.Amount.Equals(b.Amount) && a.Weight.Equals(b.Weight) && a.From.Equals(b.From) && a.To.Equals(b.To) && a.keyCod.Equals(b.keyCod) && a.OwnerName.Equals(b.OwnerNameSecand) && a.Stamp.Equals(b.SacnderStamp) && a.TypeScandery.Equals(b.TypeScandery) && a.TypeCode.Equals(b.TypeCode))
        {
             isSame = true;
        }
        Debug.Log("Is Same ="+ isSame);
        return isSame;
    }

    #region lood and save
    public void LoadData(GameData data)
        {

        SelectedItems = data.numOfSelected.Count;

            date = data.date;

            day = data.Day;

            moany = data.Money;
        Date.text = data.date[0] + " / " + data.date[1] + " / " + data.date[2];

    }

       public void SaveData(ref GameData data)
       {
        data.TockBribe = DilogeManger.isAcceptBribe;

        data.Money = moany; 
        
        data.Day++;

        data.WeeklyNotice += CustomersMovement.instance.dailyMistakesCount;

        data.CurrectPaperForTheDay = curectPapers;

        if (data.date[2]++ <= 28)
        {
            data.date[2]++;
        }
        else if (data.date[1]++ <= 12)
        {
            data.date[1]++;
        }
        else
        {
            data.date[0]++;
        }

       }
    #endregion

}
