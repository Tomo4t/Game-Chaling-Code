using UnityEngine;
using Cinemachine;
using System.Threading;





public class CameraMovement : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstView;
    [SerializeField ] CinemachineVirtualCamera secondView;
    [SerializeField] CinemachineVirtualCamera thirdView;

    
    private enum CurrentCam
    {
        First,
        Second,
        Third,
    }
    CurrentCam Cam = CurrentCam.First;

    public float swipeSpeed = .1f;
   // public GameObject gameObject;
    //public GameObject leftGameOb;
    private Vector2 startPos, endPos;
   


   


    public void OnEnable()
    {
        cameraSwitcher.registear(firstView);
        cameraSwitcher.registear(secondView);
        cameraSwitcher.registear(thirdView);
        cameraSwitcher.swichCameras(firstView);
    }
    public void OnDisable()
    {
        cameraSwitcher.registear(firstView);
        cameraSwitcher.registear(secondView);
        cameraSwitcher.registear(thirdView);
    }
   
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    endPos = touch.position;
                    break;

                case TouchPhase.Ended:

                    float DeltaX = endPos.x - startPos.x, DeltaY = endPos.y - startPos.y;


                    if (Cam == CurrentCam.First)
                    {
                        if (DeltaY > 0 && Mathf.Abs( DeltaY) > Mathf.Abs(DeltaX))
                        {

                            cameraSwitcher.swichCameras(thirdView);
                            Cam = CurrentCam.Third;

                        }
                        else if(Mathf.Abs(DeltaY) < Mathf.Abs(DeltaX))
                        {

                            cameraSwitcher.swichCameras(secondView);
                            Cam = CurrentCam.Second;

                        }

                    }
                    else if(Cam == CurrentCam.Second) 
                    {
                        if (Mathf.Abs(DeltaY) < Mathf.Abs(DeltaX) && DeltaX < 0)
                        {
                            cameraSwitcher.swichCameras(firstView);
                            Cam = CurrentCam.First;

                        }
                    }
                    else if (Cam == CurrentCam.Third)
                    {
                        if (Mathf.Abs(DeltaY) > Mathf.Abs(DeltaX) && DeltaY < 0)
                        {
                            cameraSwitcher.swichCameras(firstView);
                            Cam = CurrentCam.First;

                        }

                    }
                    break;
            }
        }
    }

   
}
