using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;

public class CustomersMovement : MonoBehaviour
{
    public GameObject character;
    public SpriteRenderer spriteRenderer;
    public GameObject phone;
    public GameObject paper;
    public GameObject PaperEndPos;
    public float popUpDuration = 1f;
    public float popDownDuration = 1f;
    public AnimationCurve popUpCurve;
    public AnimationCurve popDownCurve;
    private Vector3 originalScale;
    private bool isPoppingUp = false;
    private bool isPoppingDown = false;
    public bool phoneEnabled = true;
    public AudioSource phoneAudioSource;
    public AudioSource WishAudioSors;



    public List<Sprite> sprite;

    private bool isCameraMovementLocked = false;

    public float paperSpeedMultiplier = 0.1f;

    private Vector3 originalPaperPosition;

    public GameObject happinessBar;
    public float maxHappinessScale = 1f;
    public float minHappinessScale = 0f;
    public float decreaseSpeed = 1f;
    public float decreaseMultiplier = 0.1f;

    private const float BaseDuration = 30f;
    private const float DurationIncrement = 2f;

    public int totalCoins = 250;
    public int dailyMistakesCount = 0;
    public int dailyMistakesLimite = 5;

    public static CustomersMovement instance;
    public TMP_Text coinsText;
    public static bool TryToBribe = false;

    public static bool inRoom = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        originalScale = character.transform.localScale;
        character.transform.localScale = Vector3.zero;
        originalPaperPosition = paper.transform.position;
        paper.SetActive(false);
        paper.transform.position = PaperEndPos.transform.position;
        happinessBar.transform.localScale = Vector3.one;

    }

    void Update()
    {
        if (!isCameraMovementLocked)
        {
            Vector2 startPos = Vector2.zero, endPos;

            if (CameraMovement.instance.Cam == CameraMovement.CurrentCam.First)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    switch (touch.phase)
                    {
                        case TouchPhase.Began:

                            startPos = touch.position;
                            if (Physics.Raycast(ray, out hit))
                            {
                                GameObject touchedObject = hit.collider.gameObject;
                                if (hit.collider != null && hit.collider.CompareTag("phone") && phoneEnabled)
                                {
                                    phoneAudioSource.Play();
                                    Debug.Log("Phone hit");
                                    if (!isPoppingDown)
                                    {
                                        inRoom = true;
                                        StopAllCoroutines();
                                        Asiner.Instince.NextCharecter();
                                        WishAudioSors.Play();
                                        StartPopUp();

                                        phoneEnabled = false;
                                        
                                        happinessBar.transform.localScale = Vector3.one;
                                    }
                                }

                            }
                            break;

                        case TouchPhase.Ended:

                            endPos = touch.position;
                            float DeltaY = endPos.y - startPos.y;

                            Physics.Raycast(ray, out hit);
                            if (hit.collider != null && hit.collider.CompareTag("paper") && CameraMovement.instance.Cam == CameraMovement.CurrentCam.First)
                            {

                                if (SealMovement.instance.approved.activeSelf || SealMovement.instance.denied.activeSelf)
                                {
                                    Debug.Log("Paper hit");
                                    Vector3 moveDirection = touch.deltaPosition;


                                    if (Asiner.CurintClint.DoamintInfo.isCoreact == true && SealMovement.instance.approved.gameObject.activeSelf)
                                    {
                                        Debug.Log("PAper is core Action is coreact");
                                        Asiner.CurintClint.Speatch.GiveBrib = false;
                                        Asiner.Instince.curectPapers++;


                                    }
                                    else if (Asiner.CurintClint.DoamintInfo.isCoreact == true && SealMovement.instance.denied.gameObject.activeSelf)
                                    {
                                        dailyMistakesCount++;
                                        Debug.Log("PAper is core Action is Wrong");
                                        Asiner.CurintClint.Speatch.GiveBrib = false;



                                    }
                                    else if (Asiner.CurintClint.DoamintInfo.isCoreact == false && SealMovement.instance.denied.gameObject.activeSelf)
                                    {
                                        if (Asiner.CurintClint.DoamintInfo.TackBribe)
                                        {
                                            Debug.Log("try to bribe");
                                            Asiner.CurintClint.Speatch.GiveBrib = true;
                                        }
                                        else
                                        {
                                            Debug.Log("PAper is wrong Action is coreact");
                                            Asiner.CurintClint.Speatch.GiveBrib = false;
                                            Asiner.Instince.curectPapers++;

                                        }
                                    }
                                    else if (Asiner.CurintClint.DoamintInfo.isCoreact == false && SealMovement.instance.approved.gameObject.activeSelf)
                                    {
                                        dailyMistakesCount++;
                                        Debug.Log("PAper is wrong Action is Wrong");
                                        Asiner.CurintClint.Speatch.GiveBrib = false;

                                    }
                                    TryToBribe = true;

                                }

                            }
                            break;
                    }
                }
            }
        }

        float decreaseAmount = decreaseSpeed + (decreaseMultiplier);
        if (inRoom)
        {
            DecreaseHappiness(decreaseAmount);
        }
        if (dailyMistakesCount <= dailyMistakesLimite)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        StopAllCoroutines();

    }


    void DecreaseHappiness(float amount)
    {

        float baseDuration = BaseDuration;
        float durationIncrement = DurationIncrement;
        float duration = baseDuration + (Asiner.Instince.SelectedItems * durationIncrement);


        Vector3 newScale = happinessBar.transform.localScale;


        float scaledAmount = amount * Time.deltaTime / duration;


        newScale.x -= scaledAmount;

        newScale.x = Mathf.Clamp(newScale.x, minHappinessScale, maxHappinessScale);
        if (newScale.x == minHappinessScale)
        {

            inRoom = false;
            DilogeManger.instance.LeveRome();
        }


        happinessBar.transform.localScale = newScale;
    }

    void StartPopUp()
    {
        spriteRenderer.sprite = sprite[Random.Range(0, sprite.Count - 1)];
        if (!isPoppingUp)
        {
            Debug.Log("aaa");
            isPoppingUp = true;
            StartCoroutine(PopUp());
        }
        DilogeManger.instance.dialogueStart(Asiner.CurintClint);
    }

    void PopDown()
    {
        if (!isPoppingDown)
        {

            isPoppingDown = true;
            StartCoroutine(PopDownCoroutine());
        }
    }

    IEnumerator PopDownCoroutine()
    {
        float timer = 0f;
        Vector3 targetScale = originalScale;
        targetScale.y = 0;
        Vector3 startScale = originalScale;
       

        while (timer < popDownDuration)
        {
            float scale = popDownCurve.Evaluate(timer / popDownDuration);
            character.transform.localScale = Vector3.Lerp(startScale, targetScale, scale);
            timer += Time.deltaTime;
           
        }

        character.transform.localScale = targetScale;
        isPoppingDown = false;
        yield return null;
    }

    IEnumerator PopUp()
    {
        Debug.Log("aazza");
        float timer = 0f;
      
        while (isPoppingUp)
        {
            float scale = popUpCurve.Evaluate(timer / popUpDuration);
            character.transform.localScale = originalScale * scale;
            timer += Time.deltaTime;

            if (timer >= popUpDuration)
            {
                isPoppingUp = false;
            }
           
        }
        ResetPaperPosition();
        
        character.transform.localScale = originalScale;
        yield return null;
    }

    void ResetPaperPosition()
    {
        paper.SetActive(true);
        paper.transform.DOMove(originalPaperPosition, 0.5f).OnComplete(() =>
        {

        });
    }

    public void MovePaperToCharacter()
    {
        Vector3 endPosition = PaperEndPos.transform.position;
        paper.transform.DOMove(endPosition, 0.5f).OnComplete(() =>
        {
            paper.SetActive(false);
            SealMovement.instance.approved.SetActive(false);
            SealMovement.instance.denied.SetActive(false);
            WishAudioSors.Play();
            PopDown();
            phoneEnabled = true;
        });
    }
}
