
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;

[System.Serializable]
public class Days { [SerializedDictionary("Type", "Amount")] public AYellowpaper.SerializedCollections.SerializedDictionary<Types, int> DoucementsBearDay; }



public class Asiner : MonoBehaviour, IDataPersistence
    {

    [SerializedDictionary("Type", "Stamp" )]
    public AYellowpaper.SerializedCollections.SerializedDictionary<Types, Sprite> Stmps;

    

   [SerializeField]
   public List<Days> Day;

    public TMP_Text
            DateMain,
            DateSecnd,
            Type,
            KeyCode, //keycodes are set from 1 to 9, 1 to 4 import, 5 to 7 export , 8 and 9 transite
            AboutMain,
            AboutSecnd,
            OwnerName,
            SenderName,
            WhightMain,
            WhightSecnd;

        public SpriteRenderer 
        StampMain,
        StampSend;


        public Sprite 
        Abrove, 
        Denay;

    private int day = 0;

    
    private List<PagerTemplate> Templates = new List<PagerTemplate>();

    private int[] date;

   

    private void Awake()
    {
        DataPersistenceManager.Instance.LoadGame();

       
            foreach (var item1 in Day[day].DoucementsBearDay)
            {
                MakeData(item1.Value,item1.Key, 5 - day);
            }
        
        
    }

        private void MakeData(int NumToMake, Types type, int ChanceForUncorrectFealid)
        {
           


          for (int i = 0; i < NumToMake; i++)
          {
             PagerTemplate template = new PagerTemplate();

            #region initiate data;


            string[] temp;
            Dictionary<Types, string[]> TypesData = DoucementsData.TypeData();
            TypesData.TryGetValue(type, out temp);
            int num = UnityEngine.Random.Range(0, temp.Length);

            template.Type = type.ToString();
            template.TypeScandery = type.ToString();

            template.OwnerName = DoucementsData.Names[UnityEngine.Random.Range(0, DoucementsData.Names.Length)];

            template.SenderName = DoucementsData.Names[UnityEngine.Random.Range(0, DoucementsData.Names.Length)];

            template.Date[0] = UnityEngine.Random.Range(2011, date[0]);

            template.Date[1] = UnityEngine.Random.Range(1, date[1]);

            template.Date[2] = UnityEngine.Random.Range(1, date[2]);

            template.Date[0] = UnityEngine.Random.Range(date[0], 2030);

            template.ExpDate[1] = UnityEngine.Random.Range(date[1], 12);

            template.Date[2] = UnityEngine.Random.Range(date[2], 28);

            template.AboutMain = temp[num];


            #region Wight, Price and Amount
            if (type == Types.Raw_materials)
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
                template.From = DoucementsData.countries[UnityEngine.Random.Range(0, DoucementsData.countries.Length)];
                template.To = "Jordan";
                template.keyCod = UnityEngine.Random.Range(1, 4);
            }
            else if (chance == 2)
            {
                template.From = "Jordan";
                template.To = DoucementsData.countries[UnityEngine.Random.Range(0, DoucementsData.countries.Length)];
                template.keyCod = UnityEngine.Random.Range(5, 7);
            }
            else
            {
                int safenet = 0;
                do
                {
                    safenet++;
                    template.From = DoucementsData.countries[UnityEngine.Random.Range(0, DoucementsData.countries.Length)];
                    template.To = DoucementsData.countries[UnityEngine.Random.Range(0, DoucementsData.countries.Length)];
                    template.keyCod = UnityEngine.Random.Range(8, 9);
                }
                while (template.From.Equals(template.To) && safenet<10);
            }



            Stmps.TryGetValue(type, out template.Stamp);

            #endregion

            PagerTemplate allareCoreacte;
            allareCoreacte = new PagerTemplate();
            allareCoreacte.CopyData(template);

            template.isCoreact = UnityEngine.Random.Range(0, 10) < 3;

             if (template.isCoreact == false)
             {
                int safenet = 0;
               
                System.Random random = new System.Random();
                do {
                    for (int z = 0; z < ChanceForUncorrectFealid; z++)
                    {
                       
                        int RandomChance = UnityEngine.Random.Range(0, 14);
                        switch (RandomChance)
                        {

                            case 0:

                                
                               
                                template.TypeScandery = ((Types)random.Next(Enum.GetValues(typeof(Types)).Length)).ToString();

                                break;

                            case 1:
                                
                                do  {
                                    
                                    safenet++;
                                    Types RandomType = ((Types)random.Next(Enum.GetValues(typeof(Types)).Length));
                                    Stmps.TryGetValue(RandomType, out template.Stamp);
                                } while (template.Stamp.Equals(allareCoreacte.Stamp) && safenet < 10);
                               
                                break;

                            case 2:
                                do
                                {
                                    safenet++;
                                    template.OwnerName = DoucementsData.Names[UnityEngine.Random.Range(0, DoucementsData.Names.Length)];
                                }
                                while (allareCoreacte.OwnerName.Equals(template.OwnerName) && safenet < 10);
                                break;

                            case 3:
                                template.Date[0] = UnityEngine.Random.Range(2011, date[0] + 1);
                                break;

                            case 4:
                                template.Date[1] = UnityEngine.Random.Range(1, date[1] + 1);
                                break;

                            case 5:
                                template.Date[2] = UnityEngine.Random.Range(1, date[2] + 1);
                                break;

                            case 6:
                                template.ExpDate[0] = UnityEngine.Random.Range(date[0] + 1, 2030);
                                break;

                            case 7:
                                template.ExpDate[1] = UnityEngine.Random.Range(date[1] + 1, 12);
                                break;

                            case 8:
                                template.ExpDate[2] = UnityEngine.Random.Range(date[2] + 1, 28);
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
                                    template.From = "Jordan";
                                    template.To = DoucementsData.countries[UnityEngine.Random.Range(0, DoucementsData.countries.Length)];
                                    template.keyCod = UnityEngine.Random.Range(1, 4);
                                }
                                else if (chance == 2)
                                {
                                    template.From = "Jordan";
                                    template.To = DoucementsData.countries[UnityEngine.Random.Range(0, DoucementsData.countries.Length)];
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
                                        template.From = DoucementsData.countries[UnityEngine.Random.Range(0, DoucementsData.countries.Length)];
                                        template.To = DoucementsData.countries[UnityEngine.Random.Range(0, DoucementsData.countries.Length)];
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
            
            Templates.Add(template);
           }

        }
    
        private PagerTemplate ChoseData(ref List<PagerTemplate> templates)
        {
        int Ran = UnityEngine.Random.Range(0,templates.Count);

        PagerTemplate chosean = templates[Ran];

        templates.Remove(chosean);


        return chosean; 
        }

        private void AsineData(PagerTemplate template)
        {
        // add the logic to asin the data for the shosin template
         
        }
   
    private bool ComperData(PagerTemplate a, PagerTemplate b)
    {
        
        bool isSame = false;
        if (a.ExpDate.Equals( b.ExpDate )&& a.Date.Equals(b.Date) && a.Amount.Equals(b.Amount) && a.Weight.Equals(b.Weight) && a.From.Equals(b.From) && a.To.Equals(b.To) && a.keyCod.Equals(b.keyCod) && a.OwnerName.Equals(b.OwnerName) && a.Stamp.Equals(b.Stamp) && a.TypeScandery.Equals(b.TypeScandery))
        {
             isSame = true;
        }
        Debug.Log("Is Same ="+ isSame);
        return isSame;
    }

    #region lood and save
    public void LoadData(GameData data)
        {
            date = data.date;
            day = data.Day;
        }

        public void SaveData(ref GameData data)
        {

        }
    #endregion

}
