using UnityEngine;
using DG.Tweening;
using Unity.Burst.CompilerServices;

public class SealMovement : MonoBehaviour
{
    public bool freeTransform = true;


    public Transform startRed;
    public Transform startGreen;
    public Transform EndPos;
    public static SealMovement instance;
    public GameObject approved;
    public GameObject denied;
    public GameObject paperObject;

    public AudioSource Stamp;

    private GameObject Seal;
    public GameObject GreanSeal;
    private bool SealisMoving = false;
    


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        approved.SetActive(false);
        denied.SetActive(false);
       

    }

    void Update()
    {
        if (CameraMovement.instance.Cam == CameraMovement.CurrentCam.Third)
        {
            if (Input.touchCount > 0)
            {
                RaycastHit hit;
                Touch touch = Input.GetTouch(0);
                if (freeTransform)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {

                        if (SealisMoving == false)
                        {
                            Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit);
                            if (hit.collider != null)
                            {
                                if (hit.collider.gameObject.CompareTag("Red") || hit.collider.gameObject.CompareTag("Green"))
                                {
                                    Seal = hit.collider.gameObject; SealisMoving = true;
                                }
                            }
                           
                        }
                        if (SealisMoving)
                            MoveSealWithFinger(Seal, touch);
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit);
                        if (hit.collider != null && Seal != null)
                        {
                            if (Seal.CompareTag("Red") && Vector3.Distance(Seal.transform.position, EndPos.transform.position) < 0.7f)
                            {

                                MoveSeal(Seal.transform, startRed.position, EndPos.position, denied, approved);
                                SealisMoving = false;
                            }
                            else if (Seal.CompareTag("Green") && Vector3.Distance(Seal.transform.position, EndPos.transform.position) < 0.7f)
                            {

                                MoveSeal(Seal.transform, startGreen.position, EndPos.position, approved, denied);
                                SealisMoving = false;
                            }
                            else if (Seal.CompareTag("Green"))
                            {
                                Seal.transform.DOMove(startGreen.position, 0.5f).OnComplete(() =>
                                {
                                    SealisMoving = false;
                                });
                            }
                            else
                            {
                                Seal.transform.DOMove(startRed.position, 0.5f).OnComplete(() =>
                                {
                                    SealisMoving = false;
                                });
                            }
                        }
                    }
                   
                }
                else
                {
                    if (touch.phase == TouchPhase.Ended)
                    {

                        if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit))
                        {
                            GameObject seal = hit.collider.gameObject;
                            if (seal.CompareTag("Red"))
                            {

                                MoveSeal(seal.transform, startRed.position, EndPos.position, denied, approved);
                            }
                            else if (seal.CompareTag("Green"))
                            {

                                MoveSeal(seal.transform, startGreen.position, EndPos.position, approved, denied);
                            }
                        }
                    }
                }
            }
        }
    }
        void MoveSeal(Transform seal, Vector3 startPos, Vector3 endPos, GameObject statusObject, GameObject oppositeStatus)
        {
            seal.DOMove(endPos, .5f).OnComplete(() =>
            {
                Stamp.Play();
                statusObject.SetActive(true);
                oppositeStatus.SetActive(false);
                seal.DOMove(startPos, 0.5f).OnComplete(() =>
                {

                });
            });
        }

    public void AcpetBribe() 
    {
        GreanSeal.transform.DOMove(EndPos.position, .5f).OnComplete(() =>
        {
            approved.SetActive(true);
            Stamp.Play();
            denied.SetActive(false);
            GreanSeal.transform.DOMove(startGreen.position, 0.5f).OnComplete(() =>
            {
                
            });
        });
    }
    public void Toutoreal()
    {
        GreanSeal.transform.DOMove(EndPos.position, .5f).OnComplete(() =>
        {
            approved.SetActive(true);
            Stamp.Play();

            GreanSeal.transform.DOMove(startGreen.position, 0.5f).OnComplete(() =>
            {
              
            });
        });
    }
    void MoveSealWithFinger(GameObject Seal, Touch touch)
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit);
            Vector3 newPosition = hit.point;
            newPosition.y = Seal.transform.position.y;
            Seal.transform.position = newPosition;

        }
    
}