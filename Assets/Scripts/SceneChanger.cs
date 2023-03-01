using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	//initialise variables

	//camera check
	public Nav cameraCheck;

	public void Update(){	
		if (cameraCheck.unlockCamera == true){
			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				SceneManager.LoadScene("Camera");
			}
		}
	}

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(name);
	}
	public void Exit()
	{
		Application.Quit();
	}
}