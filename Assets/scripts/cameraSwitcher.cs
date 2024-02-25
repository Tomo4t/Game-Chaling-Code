using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static  class cameraSwitcher 
{
 public static List<CinemachineVirtualCamera >  cameras= new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera cam) { return cam == ActiveCamera; }
    public static void swichCameras(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;
        foreach (CinemachineVirtualCamera c in cameras) {
            if (c != camera)
                c.Priority = 0;
                }
    }

    public static void registear(CinemachineVirtualCamera cam)
    {
        cameras.Add(cam);
    }

    public static void unregister(CinemachineVirtualCamera cam)
    {
        cameras.Remove(cam);
    }
    

    
}
