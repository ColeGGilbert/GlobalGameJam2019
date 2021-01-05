using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	public GameObject[] safeBlocks;
	public GameObject[] obstacles;
	public GameObject[] pickups;
	public GameObject homePrefab;

    [SerializeField] private GameObject activeWorldPieces;

    private ObjectPooler pooler;

	private float spawnDelay;
	public static int nightNum;
	private float nextXPos;
	private int currentChanceForPickup = 15;
	public static int totalSegments = 0;
	private bool notFirst;
	public static int woodRemaining;
	private float itemYPos;
	private int segmentsSinceWood;
    public float xOffset = -5.6f;
	private int itemIndex;
	private float difficultyMod;
	public static int totalPickupsCollected;


    private void OnEnable()
    {
        ResetLevelScene.OnReset += ResetGame;
    }

    // Use this for initialization
    void Start () {
        ResetGame();
	}

    void ResetGame()
    {
        if(activeWorldPieces == null)
        {
            activeWorldPieces = new GameObject("Active World Pieces");
        }
        else
        {
            activeWorldPieces.transform.DetachChildren();
        }

        if(pooler == null)
        {
            pooler = ObjectPooler.instance;
        }

        notFirst = true;
        nextXPos = xOffset;
        nightNum = VariablesBetweenNights.currentNight;
        totalPickupsCollected = 0;
        woodRemaining = nightNum * 2;
        currentChanceForPickup = 15;
        totalSegments = 0;
        segmentsSinceWood = 0;
    }

	// Update is called once per frame
	void Update () {
		if (spawnDelay < 0 && woodRemaining > 0 && totalSegments <= 25)
		{
			int typeOfBlock = Random.Range(0, nightNum + 6);
			if (typeOfBlock > 3)
			{
				int index = Random.Range(0, obstacles.Length);
				pooler.SpawnFromPool(obstacles[index].name, new Vector3(nextXPos, -4, 0), activeWorldPieces.transform);
			}
			else
			{
				int index = Random.Range(0, safeBlocks.Length);
                pooler.SpawnFromPool(safeBlocks[index].name, new Vector3(nextXPos, -4, 0), activeWorldPieces.transform);
                int spawnPickup = Random.Range(0, currentChanceForPickup);
				if (spawnPickup == 0 || segmentsSinceWood >= Mathf.RoundToInt(6 * Mathf.Max(1, nightNum / 3)))
				{
					if (index == 0 || index == 3)
					{
						int upOrDown = Random.Range(0, 2);
						if (upOrDown == 0)
						{
							itemYPos = -3.2f;
						}
						else
						{
							itemYPos = -0.35f;
						}
					}
					else if (index == 2)
					{
						int upOrDown = Random.Range(0, 2);
						if (upOrDown == 0)
						{
							itemYPos = -3.2f;
						}
						else
						{
							itemYPos = 1.85f;
						}
					}
					else
					{
						itemYPos = -3.2f;
					}
					if(segmentsSinceWood >= Mathf.RoundToInt(6 * Mathf.Max(1, nightNum / 3)))
					{
						itemIndex = 0;
						segmentsSinceWood = 0;
					}
					else
					{
						itemIndex = Random.Range(1, pickups.Length);
					}
					pooler.SpawnFromPool(pickups[itemIndex].name, new Vector3(nextXPos, itemYPos, 0), activeWorldPieces.transform);
					currentChanceForPickup = 15;
				}
				else
				{
					currentChanceForPickup--;
					segmentsSinceWood++;
				}
			}
			spawnDelay = 0.1f;
			nextXPos += 0.8f;
			totalSegments++;
		}
		else if (woodRemaining <= 0 && notFirst)
		{
			Instantiate(homePrefab, new Vector3(nextXPos + 7.5f, -4, 0), Quaternion.identity, activeWorldPieces.transform);
			notFirst = false;
		}
		else
		{
			spawnDelay -= Time.deltaTime;
		}
	}
}
