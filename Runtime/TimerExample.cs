using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickTimer;

public class TimerExample : MonoBehaviour
{
	private bool canSpam = true;

	async void Update()
	{
		if (Input.GetKeyDown(KeyCode.A) && canSpam)
		{
            // Timer using callbacks
			canSpam = false;
			new Timer( .3f, ResetSpam);
		}

        if (Input.GetKeyDown(KeyCode.S) && canSpam)
		{
            // Timer using async/await
			canSpam = false;
            await Timer.Start(.3f);
            ResetSpam();
        }
	}

	void ResetSpam()
	{
		canSpam = true;
		Debug.Log("Can tap A/S again.");
	}
}
