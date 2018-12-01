using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	public string url;

	// Use this for initialization
	void Start () {
		StartCoroutine(getData());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator getData()
	{
		//tantsaha.alphagroup.mg/lib/vendor/controls/getter.php?zone=x&surface=y&semence=x
		WWWForm form = new WWWForm();
		form.AddField("zone","");
		form.AddField("surface", "");
		form.AddField("semence", "");

		WWW myWWW = new WWW(url, form);

		yield return myWWW;

		if(myWWW.error != null && myWWW.error != "")
		{
			Debug.LogError(myWWW.error);
		}
		else
		{
			
			Debug.Log(myWWW.text);
		}


	}
}
