using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DilogeManger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueparent;
    [SerializeField] private GameObject buttonparent;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;
    [SerializeField] private float typengSpeed = 0.05f;

    public AudioSource Text;

    public static bool isAcceptBribe = false;

    private string[][] allSentences;

    // Initialize the arrays
    public string[] customerOpeningSentences = { "Good morning!", "Hello there!", "Lovely weather today, isn't it?", "Greetings!", "I hope my transaction goes smoothly today.", "Here's hoping I don't spend the rest of the day here!", "Good luck navigating the bureaucratic maze!", "Let's hope we can wrap this up quickly.", "Crossing my fingers for a painless experience.", "Hope you've had your coffee, it's gonna be a long one!", "May the paperwork gods smile upon us today.", "Hopefully, I'll be in and out in no time." };
    public string[] leavingSentences = { "Thanks!", "Finally!", "It takes forever", "Have a good day", "See you later!", "Take care!", "Goodbye!", "Farewell!", "OK then" };
    public string[] bribeAcceptedResponses = {
        "That's good, let's make things happen.",
        "More to come if you keep this up.",
        "Excellent choice, you won't regret it.",
        "Great decision, let's keep this going.",
        "Fantastic, I knew we could work together.",
        "Smart move, there's plenty more where that came from.",
        "You won't be disappointed, I promise.",
        "Well done, we'll make a great team.",
        "Perfect, let's get down to business.",
        "I knew I could count on you, there's more where that came from."
    };
    public string[] bribeRejectedResponses = {

        "You're making a big mistake, pal.",
        "I can't believe you're passing up this opportunity.",
        "You'll regret this decision.",
        "You're playing with fire, my friend.",
        "You're really testing my patience.",
        "Think again, you don't want to make an enemy out of me.",
        "You'll pay for this, mark my words.",
        "You're missing out on a good deal here.",
        "You're making a huge error in judgment.",
        "You'll be sorry you turned me down."
    };
    public string[] bribeSentences = {
         "Come on, just a little something to speed things along. How about","You know what they say, money talks. How about",
         "I'll make it worth your while if you can push this through for me. How about",
         "How about we make a deal? You help me, I help you.How about",
         "I'm sure we can come to a mutually beneficial agreement. How about",
         "I've got something that will make it worth your while to approve this transaction. How about",
         "Let's keep this between us. I'll make sure you're taken care of. How about",
         "I know you're a person of integrity, but a little extra cash never hurt anyone. How about",
         "I'll make sure you're rewarded handsomely if you can make this happen. How about",
         "Consider this a token of appreciation for your cooperation. How about",
         "I know you have the power to make this transaction go through. Let's make a deal. How about" };


    public string[] AcustomerOpeningSentences = { "صباح الخير!", "مرحبًا!", "الجو جميل اليوم، أليس كذلك؟", "تحياتي!", "آمل أن تسير معاملتي بسلاسة اليوم.", "آمل ألا أقضي بقية اليوم هنا!", "حظا سعيدا في تجاوز المتاهة البيروقراطية!", "لنتمنى أن نتمكن من إنهاء هذا بسرعة.", "أصبت بأصابعي من أجل تجربة بدون ألم.", "آمل أن يكون لديك قهوتك، ستكون طويلة!", "لعل آلهة الأوراق تبتسم لنا اليوم.", "آمل أن أكون داخلًا وخارجًا في أقرب وقت." };
    public string[] AleavingSentences = { "شكرًا!", "أخيرًا!", "يستغرق الأمر وقتًا طويلاً", "أتمنى لك يومًا سعيدًا", "أراك لاحقًا!", "اعتن بنفسك!", "وداعًا!", "وداعا!", "حسنًا" };
    public string[] AbribeAcceptedResponses = {
        "هذا جيد، دعنا نجعل الأمور تتحرك.",
        "هناك المزيد إذا واصلت هذا.",
        "اختيار ممتاز، لن تندم عليه.",
        "قرار رائع، لنواصل هذا.",
        "رائع، كنت أعلم أننا يمكن أن نعمل معًا.",
        "خطوة ذكية، هناك الكثير من حيث أتى ذلك.",
        "لن تكون خيبة أمل، أعدك.",
        "عمل جيد، سنكون فريقًا رائعًا.",
        "ممتاز، لنبدأ في الأمر.",
        "كنت أعرف أنني يمكنني الاعتماد عليك، هناك المزيد من حيث أتى ذلك."
    };
    public string[] AbribeRejectedResponses = {
        "أنت ترتكب خطأ كبيرًا، يا صديقي.",
        "لا أستطيع أن أصدق أنك تتناسى هذه الفرصة.",
        "ستندم على هذا القرار.",
        "أنت تلعب بالنار، يا صديقي.",
        "أنت تختبر صبري حقًا.",
        "فكر مرة أخرى، لا تريد أن تحولني إلى عدو.",
        "ستدفع ثمن هذا، علامتي.",
        "أنت تضيع فرصة جيدة هنا.",
        "أنت ترتكب خطأ فادح في الحكم.",
        "ستندم على رفضك لي."
    };
    public string[] AbribeSentences = {
        "هيا، فقط شيء بسيط لتسريع الأمور. ماذا عن", "أنت تعرف ما يقال، المال يتكلم. ماذا عن",
        "سأجعله يستحق عناءك إذا استطعت تمرير هذا من أجلي. ماذا عن",
        "ماذا عن أن نعقد صفقة؟ أنت تساعدني، وأنا أساعدك. ماذا عن",
        "أنا متأكد أننا يمكن أن نتوصل إلى اتفاق مربح للجانبين. ماذا عن",
        "لدي شيء سيجعل الأمور تستحق جهدك للموافقة على هذه المعاملة. ماذا عن",
        "لنبقي هذا بيننا. سأتأكد من أنك تعتني. ماذا عن",
        "أعلم أنك شخص ذو نزاهة، ولكن القليل من المال الإضافي لم يضر أحدًا. ماذا عن",
        "سأتأكد من أنك ستكافأ بشكل جيد إذا استطعت جعل هذا يحدث. ماذا عن",
        "اعتبر هذا رمز تقدير لتعاونك. ماذا عن",
        "أعلم أن لديك القدرة على جعل هذه المعاملة تتم. دعنا نبرم صفقة. ماذا عن"
    };

    private int currentDialogeIndex = 0;

    public static DilogeManger instance;

    private bool FinshedText = false;

    public void Awake()
    {
        if (instance == null)
        instance = this; 
    }

    public void Start()
    {
        allSentences  = PlayerPrefs.GetInt("Lung", 1) == 1 ? new string[][]
        {
            customerOpeningSentences,
            bribeSentences,
            leavingSentences,
            bribeAcceptedResponses,
            bribeRejectedResponses
            
        } 
        :
        new string[][]
        {
            AcustomerOpeningSentences,
            AbribeSentences,
            AleavingSentences,
            AbribeAcceptedResponses,
            AbribeRejectedResponses
           
        };
    }

    public void dialogueStart(Pearson Customer)
    {
        dialogueparent.gameObject.SetActive(true);
        DisableButtons();
        StartCoroutine(printDialogue(Customer));
    }
    private void DisableButtons()
    {
       
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);

    }
    private bool optionSlected = false;
    public IEnumerator printDialogue(Pearson Customer)
    {
        isAcceptBribe = false;
        currentDialogeIndex = 0;

        string line = allSentences[currentDialogeIndex][UnityEngine.Random.Range(0, allSentences[currentDialogeIndex].Length  )];
        StartCoroutine(typeText(line));
        yield return new WaitUntil(() => FinshedText);
         FinshedText = false;
        yield return new WaitUntil(() => Input.touchCount > 0);
        dialogueparent.gameObject.SetActive(false);
        yield return new WaitUntil(() => CustomersMovement.TryToBribe);
         
        dialogueparent.gameObject.SetActive(true);
        if (Customer.DoamintInfo.isCoreact || Customer.Speatch.GiveBrib == false)
        {
            currentDialogeIndex = 2;
            line = allSentences[currentDialogeIndex][UnityEngine.Random.Range(0, allSentences[currentDialogeIndex].Length )];
            StartCoroutine(typeText(line));
            yield return new WaitUntil(() => FinshedText);
            FinshedText = false;
            yield return new WaitUntil(() => Input.touchCount > 0);
            LeveRome();
        }
        else
        {
            int moany = UnityEngine.Random.Range(40, 50);
            currentDialogeIndex = 1;
            line = allSentences[currentDialogeIndex][UnityEngine.Random.Range(0, allSentences[currentDialogeIndex].Length )];
            StartCoroutine(typeText(line + " " + moany + " Jo"));
            yield return new WaitUntil(() => FinshedText);
            FinshedText = false;
            option1Button.interactable = true;
            option2Button.interactable = true;
            option1Button.GetComponentInChildren<TMP_Text>().text = "No";
            option2Button.GetComponentInChildren<TMP_Text>().text = "Yes";
            option1Button.onClick.AddListener(() => PaseBribe(4));
            option2Button.onClick.AddListener(() => TackBribe(3, moany));
            yield return new WaitForSeconds(1);
            buttonparent.SetActive(true);
            option1Button.gameObject.SetActive(true);
            option2Button.gameObject.SetActive(true);
            yield return new WaitUntil(() => optionSlected);
            optionSlected = false;
            line = allSentences[currentDialogeIndex][UnityEngine.Random.Range(0, allSentences[currentDialogeIndex].Length )];
            StartCoroutine(typeText(line));
            yield return new WaitUntil(() => FinshedText);
            FinshedText = false;
            yield return new WaitUntil(() => Input.touchCount>0);
            LeveRome();
        }
               
             
           
    }
    private void PaseBribe(int indexJump)
    {
       
        DisableButtons();
        currentDialogeIndex = indexJump;
        Asiner.Instince.curectPapers++;
        optionSlected = true;
    }
    private void TackBribe(int indexJump, int moany)
    {
        isAcceptBribe = true;



        DisableButtons();
        Enum.TryParse<Types>(Asiner.CurintClint.DoamintInfo.Type, out Types parsedEnum);
        int num = 0;
        if (Asiner.Instince.Bribes.ContainsKey(parsedEnum))
        {
            Asiner.Instince.Bribes.TryGetValue(parsedEnum, out num);
            Asiner.Instince.Bribes.Remove(parsedEnum);
            Asiner.Instince.Bribes.Add(parsedEnum, num+ 1);
        }
        else
        {
            Asiner.Instince.Bribes.Add(parsedEnum, 0);
        }
        
        Asiner.Instince.UpdateMony(moany);
       
        SealMovement.instance.AcpetBribe();
        currentDialogeIndex = indexJump;
        
       
        optionSlected = true;
    }

    private IEnumerator typeText(string text)
    {
        dialogueText.text = "";
        int currentlater = 0;

        foreach (char letter in text.ToCharArray())
        {
            currentlater++;
            dialogueText.text = text.Substring(0, currentlater);
            yield return new WaitForSeconds(typengSpeed);
            Text.Play();
           
        }
        Text.Stop();
        FinshedText = true;

    }
    public void LeveRome()
    {
       
        CustomersMovement.instance.MovePaperToCharacter();
        buttonparent.gameObject.SetActive(false);
        dialogueparent.SetActive(false);
        dialogueText.text = "";
        StopAllCoroutines();
        SealMovement.instance.approved.SetActive(false);
        SealMovement.instance.denied.SetActive(false);
        CustomersMovement.TryToBribe = false;
        Asiner.Instince.NextCharecter();
        CustomersMovement.inRoom = false;
        
    }
  

}
