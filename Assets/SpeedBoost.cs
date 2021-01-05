using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

	private float speedBoost;
	private float regularSpeed;

	private void Start()
	{
        speedBoost = 0.55f;
        regularSpeed = 0.15f;
	}

	private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
			WorldGen.totalPickupsCollected += 1;
            col.GetComponent<MoveRightTemp>().Accel = regularSpeed;
            GameObject[] buffs = GameObject.FindGameObjectsWithTag("Pickup");
            for (int i = 0; i > buffs.Length; i++)
            {
                buffs[i].GetComponent<SpeedBoost>().StopAllCoroutines();
            }
            StartCoroutine(SpeedBuff(col));
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(Destroy(4));
        }
		if(col.transform.tag == "Destruction")
		{
			StartCoroutine(Destroy(2));
		}
    }

	IEnumerator Destroy(int delay)
	{
		yield return new WaitForSeconds(delay);
		Destroy(gameObject);
	}

    IEnumerator SpeedBuff(Collider2D col)
    {
        col.GetComponent<MoveRightTemp>().Accel = speedBoost;
        Debug.Log("Accel = " + col.GetComponent<MoveRightTemp>().Accel);
        yield return new WaitForSeconds(3);
        col.GetComponent<MoveRightTemp>().Accel = regularSpeed;
        Debug.Log("Accel = " + col.GetComponent<MoveRightTemp>().Accel);
        Destroy(gameObject);
    }
}
