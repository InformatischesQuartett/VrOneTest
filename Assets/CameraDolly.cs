using UnityEngine;
using System.Collections;

public class CameraDolly : MonoBehaviour {
	
	public float distance = 4;
	public float mouseSense = 2.5f;
	public float mouseScrollSense = 1.0f;

	private float distMax = 10.0f;
	private float distMin = 1.2f;
	
	private Transform cam;
	private Transform dolly;
	private Transform target;
	
	private float hRot;
	private float vRot;
    private float vRotMax = 60;
    private float vRotMin = -20;
    private float zRot;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("/Cube").transform;
        cam = transform.FindChild("VROneSDKHead");
		dolly = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		// Do raycast on click and get the new character
		
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit)
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "Player")
				{
					target = hitInfo.transform;
				}
			}
		} 

        // Do camera stuff		
		dolly.position = target.position;
	    dolly.rotation = target.rotation;
		
		if (Input.GetMouseButton(1))
		{
		    hRot += Input.GetAxis("Mouse X")*mouseSense;
		    vRot -= Input.GetAxis("Mouse Y")*mouseSense;
		}

	    zRot -= Input.GetAxis("Horizontal");

		vRot = Mathf.Clamp(vRot, vRotMin, vRotMax);

	    distance -= Input.GetAxis("Mouse ScrollWheel")*mouseScrollSense;
		distance = Mathf.Clamp(distance, distMin, distMax);

	    dolly.rotation = Quaternion.Euler(vRot, hRot, zRot);

	    hRot += dolly.rotation.z;

	    cam.localPosition = new Vector3(0, 0, -distance);
	}
}
