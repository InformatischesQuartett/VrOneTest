using UnityEngine;
using System.Collections;
using System.Text;

public class Travel : MonoBehaviour
{
    private GameObject _next;

    public float Speed = 0.01f;
    private Vector3 travelVector;

    private bool traveling = false;
	
	// Update is called once per frame
	void Update () {
	    if (traveling && _next != null)
	    {
            if ((_next.GetComponent<ObjectData>().OrbitDistance * 1/12) > Vector3.Distance(this.gameObject.transform.position, _next.transform.position))
	        {
	            StopTravel();
	        }
	        else
	        {
                this.gameObject.transform.position = this.gameObject.transform.position + (travelVector * Speed);
	        }

            //Debug.Log(Vector3.Distance(this.transform.position, _next.transform.position));
	    }

	    if (Input.GetKeyDown(KeyCode.X))
	    {
	        StartTravel(GameObject.Find("/Cube2"));
	    }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            StartTravel(GameObject.Find("/Cube1"));
        }
	}

    public void StartTravel(GameObject next)
    {
        _next = next;

        this.GetComponent<CameraDolly>().Dollying = false;
        traveling = true;

        travelVector = Vector3.Normalize(next.transform.position - this.gameObject.transform.position);
        Debug.Log(travelVector);
    }

    private void StopTravel()
    {
        this.GetComponent<CameraDolly>().Target = _next.transform;
        this.GetComponent<CameraDolly>().Dollying = true;

        traveling = false;
    }
}
