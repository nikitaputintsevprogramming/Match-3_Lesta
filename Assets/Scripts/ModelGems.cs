using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelGems : ViewGems
{
	

	void Start()
	{
		
	}

	

	void OnMouseDown()
	{
        ControllerGems.ClickCountControl(gameObject);
	}
}