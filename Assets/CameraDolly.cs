using UnityEngine;
using System.Collections;

public class CameraDolly : MonoBehaviour {
	
	private float distance = 5;
	public float mouseSense = 2.5f;
	public float mouseScrollSense = 1.0f;

	private float distMax = 10.0f;
	private float distMin = 1.2f;
	
	private Transform cam;
	private Transform dolly;
    public Transform Target { get; set; }

    private float hRot;
	private float vRot;
    private float vRotMax = 60;
    private float vRotMin = -20;
    private float zRot;

    public Quaternion headOrientation;

    private bool _dollying = true;

    public bool Dollying
    {
        get { return _dollying; }
        set { _dollying = value; }
    }

    // Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Target = GameObject.Find("/BieneContainer").transform;
	    distance = Target.GetComponent<ObjectData>().OrbitDistance;
        cam = GameObject.Find("VROneSDKHead").transform;
		dolly = this.gameObject.transform;
        dolly.position = Target.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (_dollying)
	    {
	        // Do camera stuff		
	        //dolly.position = Target.position;
	        //dolly.rotation = Target.rotation;

	        hRot += cam.localRotation.z;

	        Target.localRotation = Quaternion.Euler(0, hRot*10, 0);

	        cam.position = new Vector3(0, 0, -distance);
	    }
	}
}
