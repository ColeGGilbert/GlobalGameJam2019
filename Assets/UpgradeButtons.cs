using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtons : MonoBehaviour {

    private PermanantUpgrades stats;
    private GameObject holder;

	private void Start()
	{
        stats = GameObject.FindGameObjectWithTag("GameEngine").GetComponent<PermanantUpgrades>();
        holder = GameObject.FindGameObjectWithTag("UpgradeHold");
	}

	public void IncreaseMinSpeed()
    {
        if (stats.minSpeed < 3)
        {
            stats.minSpeed += 0.25f;
            holder.SetActive(false);
        }

    }

    public void IncreaseMaxSpeed()
    {
        if (stats.maxSpeed < 7.5)
        {
            stats.maxSpeed += 0.5f;
            holder.SetActive(false);
        }
    }

    public void IncreaseStartSpeed()
    {
        if (stats.startSpeed < 5)
        {
            stats.startSpeed += 0.25f;
            holder.SetActive(false);
        }
    }
}
