using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToutorealCame : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstView;
    [SerializeField] CinemachineVirtualCamera secondView;
    [SerializeField] CinemachineVirtualCamera thirdView;

    public static ToutorealCame instance;
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public enum CurrentCam
    {
        First,
        Second,
        Third,
    }
    public CurrentCam Cam = CurrentCam.First;

    public float SiwpSisetivete = 0.1f;

    public float swipeSpeed = .1f;

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

                case TouchPhase.Ended:
                    endPos = touch.position;
                    float DeltaX = endPos.x - startPos.x, DeltaY = endPos.y - startPos.y;


                    if (Cam == CurrentCam.First)
                    {
                        if (DeltaY > SiwpSisetivete && Mathf.Abs(DeltaY) > Mathf.Abs(DeltaX) && Toutorial.Right && Toutorial.Left && Toutorial.Phone && Toutorial.Up == false)
                        {

                            Toutorial.Doun = true;
                            cameraSwitcher.swichCameras(thirdView);
                            Cam = CurrentCam.Third;

                        }
                        else if (Mathf.Abs(DeltaY) < Mathf.Abs(DeltaX) && DeltaX > -SiwpSisetivete && Toutorial.Left == false)
                        {
                            Toutorial.Right = true;
                            cameraSwitcher.swichCameras(secondView);
                            Cam = CurrentCam.Second;

                        }

                    }
                    else if (Cam == CurrentCam.Second)
                    {
                        if (Mathf.Abs(DeltaY) < Mathf.Abs(DeltaX) && DeltaX < -SiwpSisetivete && Toutorial.butten)
                        {
                            Toutorial.Left = true;
                            cameraSwitcher.swichCameras(firstView);
                            Cam = CurrentCam.First;

                        }
                    }
                    else if (Cam == CurrentCam.Third)
                    {
                        if (Mathf.Abs(DeltaY) > Mathf.Abs(DeltaX) && DeltaY < -SiwpSisetivete && Toutorial.stamp )
                        {
                            cameraSwitcher.swichCameras(firstView);
                            Cam = CurrentCam.First;
                           Toutorial.Up = true;
                        }

                    }
                    break;
            }
        }
    }


}
