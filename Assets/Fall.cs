using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {

	public void MakeFall()
	{
		Rigidbody2D[] constraintsToRemove = GetComponentsInChildren<Rigidbody2D>();
		for (int i = 0; i < constraintsToRemove.Length; i++)
		{
			constraintsToRemove[i].bodyType = RigidbodyType2D.Dynamic;
			constraintsToRemove[i].constraints = RigidbodyConstraints2D.None;
		}
		StartCoroutine(DisableObject());
	}

	IEnumerator DisableObject()
	{
		yield return new WaitForSeconds(2);
        gameObject.transform.parent = null;
	}
}
