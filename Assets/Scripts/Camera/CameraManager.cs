using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    Camera nowActive;
    int index;
    void Awake()
    {
        nowActive = cameras[0];
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(index==0)index=cameras.Count-1;
            else index--;
            
            nowActive.gameObject.SetActive(false);
            cameras[index].gameObject.SetActive(true);
            nowActive = cameras[index];
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            if(index == cameras.Count-1)index = 0;
            else index++;

            nowActive.gameObject.SetActive(false);
            cameras[index].gameObject.SetActive(true);
            nowActive = cameras[index];
        }
    }
}
