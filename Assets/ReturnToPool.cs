using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public Transform parentHolder;
    private List<Vector3> startingPositions = new List<Vector3> { };
    private List<Quaternion> startingRotations = new List<Quaternion> { };

    private void Start()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform obj = transform.GetChild(i).transform;
                startingPositions.Add(obj.position);
                startingRotations.Add(obj.rotation);
            }
        }
    }

    public void OnObjectSpawn()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform obj = transform.GetChild(i).transform;
                obj.position = startingPositions[i];
                obj.rotation = startingRotations[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {
            if (transform.childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            transform.parent = parentHolder;
            gameObject.SetActive(false);
        }
    }
}
