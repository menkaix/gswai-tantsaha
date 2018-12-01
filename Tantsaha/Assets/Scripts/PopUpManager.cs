using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour {

	public GameObject itemModel;
	public RegionSelector caller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clear()
	{
		StartCoroutine(clearChildren());
	}

	private IEnumerator clearChildren()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(0).gameObject.SetActive(false);
			
		}
		while (transform.childCount > 0)
		{
			Destroy(transform.GetChild(0).gameObject);
			yield return new WaitForEndOfFrame ();
		}
		
	}

	public void display(RegionSelector regionSelector)
	{
		caller = regionSelector;
		for(int i = 0 ; i < regionSelector.regions.Length;i++)
		{
			GameObject go = Instantiate(itemModel);
			go.transform.parent = transform;
			Text t = go.GetComponent<Text>();
			if (t != null)
			{
				t.text = regionSelector.regions[i];
			}
			PopUpElement elt = go.GetComponent<PopUpElement>();

			if(elt != null)
			{
				elt.index = i;
			}

		}
	}
}
