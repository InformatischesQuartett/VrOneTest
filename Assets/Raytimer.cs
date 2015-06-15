using UnityEngine;
using System.Collections;
using System.Threading;

public class Raytimer : MonoBehaviour
{

    private float timer;
    private Travel traveler;

    void Start()
    {
        traveler = GameObject.Find("VROneSDK").GetComponent<Travel>();
    }

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
	    if (Physics.Raycast(transform.position, transform.forward, out hit))
	    {
	        if (timer > 5)
	        {
	            traveler.StartTravel(hit.transform.gameObject);
	            timer = 0;
	        }

            if (hit.collider == null)
            {
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
	    }

        

	}
}
