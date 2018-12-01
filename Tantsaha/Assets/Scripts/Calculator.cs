using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Calculator : MonoBehaviour {

	public string geography;
	public string semence;
	public string engrais;

	public InputField semenceField;
	public InputField engraisField;
	public InputField productionField;
	public InputField sufaceField;



	public void changeSemence()
	{
		float semance = float.Parse(semenceField.text);
		
		float surface = (semance / 50);
		float intrant = (surface * 150);
		float production = ((semance * 5000) / 50);

		engraisField.text = intrant + "";
		sufaceField.text = surface + "";
		productionField.text = production + "";
	}

	public void changeSurface()
	{
		float surface = float.Parse(sufaceField.text);

		float semance = (surface * 50);
		float intrant = (surface * 150);
		float production = ((semance * 5000) / 50);

		engraisField.text = intrant + "";
		productionField.text = production + "";
		semenceField.text = semance + "";
	}

	public void changeProduction()
	{
		float production = float.Parse(productionField.text);

		float semance = ((production * 50) / 5000);
		float surface = (semance / 50);
		float intrant = (surface * 150);

		semenceField.text = semance + "";
		sufaceField.text = surface + "";
		engraisField.text = intrant + "";

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
