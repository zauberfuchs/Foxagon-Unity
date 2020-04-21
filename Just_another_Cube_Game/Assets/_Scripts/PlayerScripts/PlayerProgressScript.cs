using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgressScript : MonoBehaviour {

	public 	 Text 	 progressText;
	public 	 Text 	 bestProgressText;

	[SerializeField]
	private  float 	 xCordFinish;
	private  float 	 progress;
	private  float 	 bestProgress;

	void Start () 
	{
		xCordFinish = GameObject.Find("Finish").transform.position.x;
		bestProgressText.color = new Color(0, 0, 0, 0);
	}
	
	
	void Update () 
	{
		progress = this.GetComponent<Rigidbody2D>().transform.position.x / xCordFinish * 100;
        
        if(progress <= 100)
        {
            SetProgressText();
        }
	}

	void SetProgressText()
    {
        progressText.text = "Progress: " + progress.ToString("0") + "%";
    }
		
	public void SetBestProgress()
	{
		if (progress > bestProgress) 
		{
			bestProgress = progress;
			bestProgressText.text = "your best progress was = "+ BestProgress.ToString("0") + "%";
		}
	}

	public float BestProgress
	{
		get { return bestProgress; }
		set { bestProgress = value; }
	}
}
