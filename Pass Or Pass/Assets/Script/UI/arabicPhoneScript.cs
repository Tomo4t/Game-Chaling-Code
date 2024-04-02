using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class arabicPhoneScript : MonoBehaviour, IDataPersistence
{
    List<List<string>> relatives = new List<List<string>>
{
 new List<string> { "تعرض أخوك", "تعرض والدك", "تعرض جدك", "تعرض عمك", "تعرض ابنك", "تعرض صديقك المقرب" },new List<string> { "تعرضت أختك", "تعرضت والدتك", "تعرضت جدتك", "تعرضت عمتك",   "تعرضت ابنتك", "تعرضت صديقتك المقربة" }

};



    List<string> dailyCosts = new List<string> { "مواد غذائية", "أدوية", "رسوم المدرسة", "فواتير المرافق", "وسائل النقل", "الترفيه", "الملابس", "تناول الطعام في المطاعم", "رعاية الحيوانات الأليفة", "التأمين" };
    List<string> monthlyCosts = new List<string> { "الإنترنت", "فواتير الهاتف", "الإيجار" };
    List<string> eventsMedicens = new List<string> { "المضاعفات الطبية", "تدهور الصحة", "آثار جانبية تتطلب علاج", " زيادة في نفقات العلاج بسبب تدهور الحالة الصحية" };
    List<string> eventsFood = new List<string> { "لتسمم غذائي", "لآلام في المعدة", "لإسهال", "لقيء", "لغثيان", "لتوتر في الجهاز الهضمي" };

    List<string> eventsRawMaterial = new List<string> { "لحوادث صناعية", "  لمواد سامة بسبب استخدام مواد تالفة", "لحروق كيميائية بسبب استخدام مواد تالفة", " تفاعلات حساسية بسبب استخدام مواد تالفة", "مشاكل في التنفس بسبب استخدام مواد تالفة", "تهيج في الجلد بسبب استخدام مواد تالفة" };
    List<string> eventsDamagedCars = new List<string> { "حادث سيارة بسبب فرامل معيبة", "تصادم على الطريق بسبب تعطل في المقود", "إصابة بسبب وسائد هوائية معيبة", "اندلاع حريق بسبب أسلاك كهربائية معيبة", "انفجار إطار ناتج عن حادث", "تصادم بسبب فشل في المحرك" };
    List<string> eventsDamegedElectronics = new List<string> { "لحروق كهربائية بسبب أسلاك معيبة", "لحروق ناتجة عن انفجار بطاريات تالفة", "لمخاطر صحية ناتجة عن تعرض لمواد سامة ", "مخاطر صحية ناتجة عن الإشعاع الناتج عن الإلكترونيات المعيبة" };
   
    


    public TMP_Text massege;
    public TMP_Text massege2;
    public TMP_Text consequanceText;
    public TMP_Text Moany;

    public GameObject ExteButten;
    public GameObject massegePanel1;
    public GameObject massegePanel2;
    public GameObject consequancePanel;
    public AudioSource soundEffect;

    private int totaldailyCost, earnings, Coins;
    private bool isAcceptBribe;
    // Start is called before the first frame update
    void Start()
    {
        DataPersistenceManager.Instance.LoadGame();
        ExteButten.SetActive(false);

        Moany.text = "الرصيد: " + Coins+ " JD";

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
    {
        DataPersistenceManager.Instance.SaveGame();
        ExteButten.SetActive(true);
    }
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
                { consequanceText.text = relatives[Random.Range(0, relatives.Count)]  + eventsMedicens[Random.Range(0, eventsRawMaterial.Count)] + " بسبب استعمال ادويه تالفه."; }
                else if (item.Key == Types.Raw_Materials || item.Key == Types.Materials)
                    consequanceText.text =  relatives[Random.Range(0, relatives.Count)] +  eventsRawMaterial[Random.Range(0, eventsRawMaterial.Count)] + "بسبب مواد رديئه.";
                else if (item.Key == Types.Organics)
                    consequanceText.text = relatives[Random.Range(0, relatives.Count)] +  eventsFood[Random.Range(0, eventsRawMaterial.Count)] + " بسبب تناول طعام فاسد.";
                else if (item.Key == Types.Vehicles)
                    consequanceText.text =  relatives[Random.Range(0, relatives.Count)] +  eventsDamagedCars[Random.Range(0, eventsRawMaterial.Count)] + " بينما قيادتهم لعربتهم الجديدة.";
                else if (item.Key == Types.Electronics)
                    consequanceText.text =  relatives[Random.Range(0, relatives.Count)] +  eventsDamegedElectronics[Random.Range(0, eventsDamegedElectronics.Count)] + " بسبب جهازهم الحديد. ";
            }


        }
        else
        {
            List<string> nottakingBribeSentance = new List<string> {
    "الالتزام بسيادة القانون يضمن العدالة والمساواة للجميع.",
    "المساءلة تجعل الأفراد والمؤسسات مسؤولين عن أفعالهم.",
    "الشفافية تعزز الثقة  في المؤسسات.",
    "العدالة تضمن حماية الحقوق ومعالجة الانتهاكات.",

    "النزاهة هي أساس السلوك الأخلاقي والمبادئ الأخلاقية.",
    "اتباع المعايير الأخلاقية يعزز النزاهة في جميع الأفعال.",
    "الشفافية والنزاهة يتماشيان في الحفاظ على المصداقية.",
    "احترام التنوع والاندماج أمر أساسي للحفاظ على النزاهة.",
    "النزاهة ليست مجرد قيمة؛ إنها طريقة للحياة.",
    "تعزيز معايير النزاهة يخلق حالة من الثقة والاحترام.",

    "النزاهة تتطلب الشجاعة للوقوف من أجل ما هو صحيح، حتى في الظروف الصعبة.",
    "من خلال الالتزام بمعايير النزاهة، نبني مستقبلًا أفضل للأجيال القادمة."
};

            consequanceText.text = "دائما تذكر " + nottakingBribeSentance[Random.Range(0, nottakingBribeSentance.Count)];
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

        massege.text = "مصاريف البوم:\n" + thedailyCostText + " : " + costsDaily.ToString() + "\n" + theDailyCostText2 + " : " + costDaily2.ToString();





    }

    void phoneMassegeDaily2()
    {
        massegePanel2.SetActive(true);
        massege2.text = "ارباح اليوم:\n" + "المعاملات الصحيحه: " + earnings + " x " + "20 = " + earnings * 20;



        Coins -= totaldailyCost;

        Moany.text = "الرصيد: " + (Coins + earnings * 20) + " JD"; ;


    }

    public void LoadData(GameData data)
    {
        Coins = data.Money;

        isAcceptBribe = data.TockBribe;

        earnings = data.CurrectPaperForTheDay;
    }

    public void SaveData(ref GameData data)
    {
        data.CurrectPaperForTheDay = 0;
        data.Money = Coins + (earnings * 20);
    }
}