using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickTimer;

public class TimerExample : MonoBehaviour
{
	private bool canSpam = true;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A) && canSpam)
		{
			canSpam = false;
			new Timer( .3f, ResetSpam);
		}
	}

	void ResetSpam()
	{
		canSpam = true;
		Debug.Log("Can tap A again.");
	}
}
