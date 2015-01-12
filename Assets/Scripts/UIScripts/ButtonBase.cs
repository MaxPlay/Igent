using UnityEngine;
using System.Collections;

public class ButtonBase : MonoBehaviour {

	public bool Pressed = false;
	public Transform ButtonMesh;


	void OnMouseEnter()
	{
		ButtonMesh.localPosition = new Vector3(0,0,-0.3f);
	}

	void OnMouseExit()
	{
		ButtonMesh.localPosition = new Vector3(0,0,0);
	}

	public void OnPressed() 
	{
		Pressed = true;
	}
}
