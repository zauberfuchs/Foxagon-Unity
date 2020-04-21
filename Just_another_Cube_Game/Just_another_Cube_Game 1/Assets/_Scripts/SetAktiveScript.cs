using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAktiveScript : MonoBehaviour {
    // Use this for initialization
    public GameObject myObject;
    void Start () {
        myObject.SetActive(false);
    }
    

    void OnBecameVisible()
    {
        myObject.SetActive(true);
    }
    void OnBecameInvisible()
    {
        myObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        
    }
}
