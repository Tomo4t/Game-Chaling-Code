using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class phoneScript : MonoBehaviour,IDataPersistence
{
    List<string> relatives = new List<string> { "Sister", "Brother", "Mom", "Dad", "Grandfather", "Grandmother", "Aunt", "Uncle", "Son", "Daughter" };
    List<string> dailyCosts = new List<string> { "Grocery", "Medicines", "School fees", "Utilities", "Transportation", "Entertainment", "Clothing", "Eating out", "Pet care", "Insurance" };
    List<string> monthlyCosts = new List<string> { "Internet", "Phone bills", "Rent" };
    List<string> eventsMedicens = new List<string> { "Hospitalization due to adverse effects", "Medical complications", "Health deterioration", "Side effects requiring treatment", "Increased medical expenses", "Lost wages due to illness" };
    List<string> eventsFood = new List<string> { "Food poisoning", "Stomachache", "Diarrhea", "Vomiting", "Nausea", "Gastrointestinal discomfort" };
    List<string> eventsRawMaterial = new List<string> { "Industrial accidents", "Toxic exposure", "Chemical burns", "Allergic reactions", "Respiratory issues", "Skin irritations" };
    List<string> eventsDamagedCars = new List<string> { "Car accident due to faulty brakes", "Road collision caused by malfunctioning steering", "Injury from defective airbags", "Fire outbreak due to faulty wiring", "Tire blowout leading to an accident", "Crash caused by engine failure" };
    List<string> eventsDamegedElectronics = new List<string> { "Electrical fires due to faulty wiring", "Short circuits causing damage to property", "Explosions from defective batteries", "Health hazards from exposure to toxic materials", "Electronic devices malfunctioning, leading to accidents", "Damage to infrastructure due to electrical failures", "Environmental pollution from improper disposal of electronic waste", "Increased risk of electromagnetic interference with critical systems", "Loss of productivity due to equipment breakdowns", "Health risks from radiation emitted by faulty electronics" };
    public TMP_Text massege;
    public TMP_Text massege2;
    public TMP_Text consequanceText;
    public TMP_Text Moany;

    public GameObject ExteButten;
    public GameObject massegePanel1;
    public GameObject massegePanel2;
    public GameObject consequancePanel;
    public AudioSource soundEffect;

    private int totaldailyCost ,earnings, Coins;
    private bool isAcceptBribe;
    // Start is called before the first frame update
    void Start()
    {
        DataPersistenceManager.Instance.LoadGame();
        ExteButten.SetActive(false);
        
        Moany.text = "Cash: " + Coins;

        massegePanel1.SetActive(false);
        massegePanel2.SetActive(false);
        consequancePanel.SetActive(false);
        StartCoroutine(ShowMessages());
    }

    IEnumerator ShowMessages()
    {
        yield return new WaitForSeconds(3f);
        PlaySoundEffect();
        yield return new WaitForSeconds(.5f);
        phoneMassegeDaily();
        yield return new WaitForSeconds(3f);
        PlaySoundEffect();
        yield return new WaitForSeconds(.5f);
        phoneMassegeDaily2();
        yield return new WaitForSeconds(3f);
        PlaySoundEffect();
        yield return new WaitForSeconds(.5f);
        secondMessageDaily();
        yield return new WaitForSeconds(3f);
        AlowToExt();
    }

    void AlowToExt() 
    {DataPersistenceManager.Instance.SaveGame();
        ExteButten.SetActive(true); }
    void PlaySoundEffect()
    {
        soundEffect.Play();
    }

    void secondMessageDaily()
    {
        consequancePanel.SetActive(true);
        if (isAcceptBribe == true)
        {
            
           

            foreach (var item in DataHolder.Bribes)
            {

                if (item.Key == Types.Medicals)
                { consequanceText.text = "Your " + relatives[Random.Range(0, relatives.Count)] + " had " + eventsMedicens[Random.Range(0, eventsRawMaterial.Count)] + " due to taking spoiled medicens."; }
                else if (item.Key == Types.Raw_Materials || item.Key == Types.Materials)
                    consequanceText.text = "Your " + relatives[Random.Range(0, relatives.Count)] + " had " + eventsRawMaterial[Random.Range(0, eventsRawMaterial.Count)] + " because of using spoiled  materials.";
                else if (item.Key == Types.Organics)
                    consequanceText.text = "Your " + relatives[Random.Range(0, relatives.Count)] + " had " + eventsFood[Random.Range(0, eventsRawMaterial.Count)] + " because of eating spoiled food .";
                else if (item.Key == Types.Vehicles)
                    consequanceText.text = "Your " + relatives[Random.Range(0, relatives.Count)] + " had " + eventsDamagedCars[Random.Range(0, eventsRawMaterial.Count)] + " because of driving their new car.";
                else if (item.Key == Types.Electronics)
                    consequanceText.text = "Your " + relatives[Random.Range(0, relatives.Count)] + " had " + eventsDamegedElectronics[Random.Range(0, eventsDamegedElectronics.Count)] + " due to usage of  new electronic device. ";
            }


        }
        else
        {
            List<string> nottakingBribeSentance = new List<string> {
        "Adhering to the rule of law ensures fairness and justice for all.", "Accountability holds individuals and organizations responsible for their actions.","Transparency fosters trust and confidence in institutions.","Justice ensures that rights are upheld and violations are addressed.","Equality promotes equal opportunities and treatment for everyone.",
        "Integrity is the foundation of ethical behavior and moral principles.","Following ethical standards promotes integrity in all actions.","Honesty and integrity go hand in hand in maintaining credibility.","Respecting diversity and inclusion is essential for upholding integrity.",
        "Integrity is not just a value; it is a way of life.","Promoting integrity standards creates a culture of trust and respect.","Leading with integrity inspires others to do the same.","Integrity requires courage to stand up for what is right, even in difficult situations.","By upholding integrity standards, we build a better future for generations to come." };

            consequanceText.text = "Alwayas remamber " + nottakingBribeSentance[Random.Range(0, nottakingBribeSentance.Count)];
        }




    }

    void phoneMassegeDaily()
    {
        massegePanel1.SetActive(true);
      
        int costsDaily = Random.Range(30, 130);
        int costDaily2 = Random.Range(30, 130);


        totaldailyCost = costsDaily + costDaily2;


        string thedailyCostText = dailyCosts[Random.Range(0, dailyCosts.Count)];
        string theDailyCostText2 = dailyCosts[Random.Range(0, dailyCosts.Count)];
        if (thedailyCostText.Equals(theDailyCostText2))
        {
            thedailyCostText = dailyCosts[Random.Range(0, dailyCosts.Count)];
        }

        massege.text = "Today's costs:\n" + thedailyCostText + " : " + costsDaily.ToString() + "\n" + theDailyCostText2 + " : " + costDaily2.ToString();



      

    }

    void phoneMassegeDaily2()
    {
        massegePanel2.SetActive(true);
        massege2.text = "Today's Earnings:\n" + "Correct Trantions " +earnings +" x "+ "20 = " + earnings * 20;



        Coins -= totaldailyCost;

        Moany.text = "Cash: " + (Coins + earnings * 20);


    }

    public void LoadData(GameData data)
    {
        Coins = data.Money;

        isAcceptBribe = data.TockBribe;

        earnings = data.CurrectPaperForTheDay;
    }

    public void SaveData(ref GameData data)
    {
        data.Money = Coins;
    }
}