using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class MyVariableStorage
 {
     public static int attemptCount = 0;
 	 public static float musicVolume = 0.5f;
 	 public static float gameVolume = 0.2f;
 	 public static bool hasBeenPaused;
 //	 public static float musicSafe;
 	 public static bool performsRestart;
 	 public static bool hasBeenSaved;
 	// public static int highestProgress = 0;      ?? vielleicht  ne best leistungs anzeige ?
 }

 class AnyScript : MonoBehaviour
 {
     private void Start()
     {
         Debug.Log(MyVariableStorage.attemptCount);
         Debug.Log(MyVariableStorage.musicVolume);
         Debug.Log(MyVariableStorage.gameVolume);
     }
 }