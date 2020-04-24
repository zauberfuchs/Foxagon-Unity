using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {



    public   GameObject      player;
    public   float           CameraZ;

    private  Rigidbody       rb;
    private  float           CameraY;
    private  AudioSource[]   backgroundMusic;
    private  bool            musicSwitched;
    private  Camera          mainCamera;

    // Use this for initialization
    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        backgroundMusic = GetComponents<AudioSource>();
        mainCamera = GetComponent<Camera>();
        CameraY = 2;
        backgroundMusic[0].volume = MyVariableStorage.musicVolume;
        MyVariableStorage.hasBeenPaused = false;
        MyVariableStorage.hasBeenSaved = false;
    }
    
    // Update is called once per frame
    void LateUpdate () 
    {
        rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.x + 5, CameraY, CameraZ);
        if (player.transform.position.y - CameraY > 0.5)
        {
            CameraY += 0.1f;
        }

        if (CameraY - player.transform.position.y > 3.5)
        {
            CameraY -= 0.1f;
        }
        if(MyVariableStorage.performsRestart)
        {
            backgroundMusic[0].time = 0;
        }   
    


        if((MyVariableStorage.hasBeenPaused || MyVariableStorage.hasBeenSaved) && !musicSwitched)
        {
            backgroundMusic[0].Stop();
            backgroundMusic[1].Play();
            backgroundMusic[1].volume = MyVariableStorage.musicVolume;
            musicSwitched = true;
        }
    }

    void FlipCamera()
    {
        mainCamera.ResetWorldToCameraMatrix ();
        mainCamera.ResetProjectionMatrix ();
        mainCamera.projectionMatrix = mainCamera.projectionMatrix * Matrix4x4.Scale(new Vector3 (-1, 1, 1));
        GameObject.Find("Background_Moon").GetComponent<Transform>().transform.Rotate(0,180,0);
        GameObject.Find("Background_lower").GetComponent<Transform>().transform.Rotate(0,180,0);
        GameObject.Find("Background_Mountains").GetComponent<Transform>().transform.Rotate(0,180,0);
    }
}
