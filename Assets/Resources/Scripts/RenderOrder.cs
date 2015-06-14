using UnityEngine;
using System.Collections;

/*Sets Renderorder so the objects gets rendered first*/
public class RenderOrder : MonoBehaviour {

    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.renderQueue = 1000;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
