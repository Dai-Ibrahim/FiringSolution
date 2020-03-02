using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public float myTimeScale = 1.0f;
    public GameObject[] targets;
	public int targetIndex = 0;
    public float launchForce = 10f;
	private bool hit;
	public string targetTag;


    Rigidbody rb;

    void Start()
    {
		targets = GameObject.FindGameObjectsWithTag(targetTag);
		Debug.Log(targetIndex);

		Debug.Log(targets[0]);

        Time.timeScale = myTimeScale;
        rb = GetComponent<Rigidbody>();

        FiringSolution fs = new FiringSolution();
        Nullable<Vector3> aimVector = fs.Calculate(transform.position, targets[targetIndex].transform.position, launchForce, Physics.gravity);

        if (aimVector.HasValue)
        {
            rb.AddForce(aimVector.Value.normalized * launchForce , ForceMode.VelocityChange);
        }
    }
	 void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == targetTag)
        {
            hit = true;
			if(targetIndex < targets.Length-1)
			{
				targetIndex++;
				Reset();
			}
			else 
			{
				Reset();
			}
			
        }
		else
		{
			hit = false;
		}
		Debug.Log(hit);

    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        FiringSolution fs = new FiringSolution();
        Nullable<Vector3> aimVector = fs.Calculate(transform.position, targets[targetIndex].transform.position, launchForce, Physics.gravity);

        if (aimVector.HasValue)
        {
            rb.AddForce(aimVector.Value.normalized * launchForce , ForceMode.VelocityChange);
        }
    }
}

   