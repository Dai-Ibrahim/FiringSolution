using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
     public GameObject[] targets;
	 private int targetIndex;
	 private bool hit;

    private void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Frog");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Frog")
        {
            hit = true;
			
        }
		else
		{
			hit = false;
		}
		Debug.Log(hit);
    }
}
