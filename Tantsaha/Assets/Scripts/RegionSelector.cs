using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionSelector : MonoBehaviour {

	private Text display;

	public int currentIndex = 0;
	public string[] regions;

	public void incIndex()
	{
		currentIndex++;
		if(currentIndex>= regions.Length)
		{
			currentIndex = 0;
		}
	}

	public void decIndex()
	{
		currentIndex--;
		if (currentIndex < 0)
		{
			currentIndex = regions.Length - 1;
		}
	}


	// Use this for initialization
	void Start () {
		display = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		display.text = regions[currentIndex];
	}
}
