using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSolid : MonoBehaviour
{
     public Color ObjectColor;

    private Color currentColor;
    private Material materialColored;

    void Update()
    {
        //   if (ObjectColor != currentColor)
        //   {
        //       //helps stop memory leaks
        //       if (materialColored != null)
        //           UnityEditor.AssetDatabase.DeleteAsset(UnityEditor.AssetDatabase.GetAssetPath(materialColored));
        //
        //       //create a new material
        //       materialColored = new Material(Shader.Find("Diffuse"));
        //       materialColored.color = currentColor = ObjectColor;
        //       this.GetComponent<Renderer>().material = materialColored;
        //   }
        GetComponent<Renderer>().material.color = new Color(100, 100, 0, 0f);
    }
}