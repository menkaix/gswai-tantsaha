using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PopUpElement : MonoBehaviour, IPointerClickHandler
{
	private PopUpManager manager;

	public int index;

	public void OnPointerClick(PointerEventData eventData)
	{
		manager.caller.currentIndex = index;
		manager.clear();
	}

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<PopUpManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
