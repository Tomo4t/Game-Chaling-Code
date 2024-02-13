using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField ] CinemachineVirtualCamera secondView;
    [SerializeField] CinemachineVirtualCamera firstView;
    [SerializeField] CinemachineVirtualCamera thirdView;



    public float swipeSpeed = .1f;
   // public GameObject gameObject;
    //public GameObject leftGameOb;
    private Vector3 touchStartPos, lastPosition;
    private bool isMoving;


   


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
    private void Start()
    {
      
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isMoving = true;
                    break;

                case TouchPhase.Moved:
                    lastPosition = touch.position;
                    float deltaZ = lastPosition.z - touchStartPos.z;
                    float deltaY = lastPosition.y - touchStartPos.y;

                    if (Mathf.Abs(deltaZ) > Mathf.Abs(deltaY))
                    {
                        if (deltaZ > 0)

                            cameraSwitcher.swichCameras(secondView);
                        else
                            cameraSwitcher.swichCameras(firstView);
                    }
                    else
                    {
                        if (deltaY > 0)
                            cameraSwitcher.swichCameras(firstView);
                        else
                            cameraSwitcher.swichCameras(thirdView);

                    }
                    break;

                case TouchPhase.Ended:
                    isMoving = false;
                    break;
            }
        }
    }

   
}
