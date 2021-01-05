using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour {

	public Vector3[] optionLocationsFirst;
	public Vector3[] optionLocationsSecond;
	public GameObject secondNav;
	private int currentSelection;
	private bool changedLocation;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			currentSelection++;
			if(currentSelection > 1)
			{
				currentSelection = 1;
			}
			else
			{
				changedLocation = true;
			}
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			currentSelection--;
			if(currentSelection < 0)
			{
				currentSelection = 0;
			}
			else
			{
				changedLocation = true;
			}
		}
		else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit"))
		{
			if(currentSelection == 0)
			{
				SceneManager.LoadScene(1);
			}
			else if(currentSelection == 1)
			{
				Application.Quit();
			}
		}
	}

	private void LateUpdate()
	{
		if (changedLocation == true)
		{
			transform.position = optionLocationsFirst[currentSelection];
			secondNav.transform.position = optionLocationsSecond[currentSelection];
			changedLocation = false;
		}
	}
}
