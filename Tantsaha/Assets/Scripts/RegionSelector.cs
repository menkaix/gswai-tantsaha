﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Step{
	GEOGRAPHY,
	SEMANCE, 
	ENGRAIS
}

public class RegionSelector : MonoBehaviour, IPointerClickHandler{

	private Text display;
	private Calculator calc;
	private PopUpManager manager;

	public Step step ;
	public int currentIndex = 0;
	public string[] regions;

	public void incIndex()
	{
		currentIndex++;
		if(currentIndex>= regions.Length)
		{
			currentIndex = 0;
		}
		updateData();
	}

	public void decIndex()
	{
		currentIndex--;
		if (currentIndex < 0)
		{
			currentIndex = regions.Length - 1;
		}
		updateData();
	}

	public void updateData()
	{
		switch (step)
		{
			case Step.ENGRAIS:
				calc.engrais = regions[currentIndex];
				break;
			case Step.GEOGRAPHY:
				calc.geography = regions[currentIndex];
				break;
			case Step.SEMANCE:
				calc.semence = regions[currentIndex];
				break;
			default:
				
				break;
		}
	}



	// Use this for initialization
	void Start () {
		display = GetComponentInChildren<Text>();
		calc = FindObjectOfType<Calculator>();
		manager = FindObjectOfType<PopUpManager>();

	}
	
	// Update is called once per frame
	void Update () {
		display.text = regions[currentIndex];
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		manager.display(this);
		
	}
}
