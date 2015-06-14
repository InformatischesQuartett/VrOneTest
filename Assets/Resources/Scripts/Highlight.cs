using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * HOW IT WORKS:
 * - create a prefab of the object you want to highlight
 * - set the ShaderHighlightObj.shader as the prefab shaders material
 * - set the ShaderObj.shader as the object shaders material
 * - out this script on the object you want to highlight
 * - the highlighting starts when the bool highlightStatus is set to true
 **/
public class Highlight : MonoBehaviour {

    private Transform highlightObj;

    private Color highlightColor;
    private Color highlightColor2;
    private List<Color> highlightColorList;
    private Renderer rend;
    private Renderer highlightObjRend;

    private bool highlightStatus = true;

    private int colorIterator = 0;
    
    //Timer
    private float timer = 0.0f;
    private float maxHighlightSize = 1.0f;
	
    // Use this for initialization
	void Start () {

        highlightColorList = new List<Color>();
        setColors();
        
        
        //get renderer for setting render queue
        //rend = GetComponent<Renderer>();
        //rend.material.renderQueue = 4000;

        //find prefab
        highlightObj = (Transform)Resources.Load("Prefabs/BieneHighlightPrefab", typeof(Transform));
        highlightObj.name = "highlightObj";
 
        
	}
	
	// Update is called once per frame
	void Update () {


        if (highlightStatus)
        {
            instantiateHighlight();
        }
		
		if (timer >= 3.0f) 
		{
			//call alex function to move to obj HERE
			
			timer = 0.0f;
		}
        

	}

    void FixedUpdate()
    {

       //after certain amount of time call alex function
       
        timer += Time.fixedDeltaTime;
    }


   /*Destroy Obj*/
   private void OnMouseExit()
   {
       Debug.Log("Exit");
       rend.material.SetColor("_Color", highlightColor2);
   }


   public bool getHighlightStatus()
   {
       return highlightStatus;
   }

   public void setHighlightStatus(bool highlightSatus)
   {
       this.highlightStatus = highlightSatus;
   }

   /*Change Obj size and color over time*/
   private void instantiateHighlight()
   {
       var highlightObjInScene = GameObject.Find("highlightObj(Clone)");
      
       /*Create Highlight Object if none is there*/
       if (!highlightObjInScene)
       {
           var myHighlightObj = (Transform) Instantiate(highlightObj, this.transform.position, this.transform.rotation);// as GameObject;
           myHighlightObj.transform.parent = this.transform;
           myHighlightObj.localRotation = Quaternion.identity;
          

       }

       /*Change Size and Color*/
       if (highlightObjInScene)
       {
           //find renderer for future references
           highlightObjRend = highlightObjInScene.GetComponent<Renderer>();

           //increase obj size
           highlightObjInScene.transform.localScale += new Vector3(0.004f, 0.004f, 0.004f);

           //crop obj size after certain number
           if (highlightObjInScene.transform.localScale.z >= maxHighlightSize)
           {
               highlightObjInScene.transform.localScale = new Vector3(maxHighlightSize, maxHighlightSize, maxHighlightSize);
           }

           //color
           highlightObjRend.material.SetColor("_Color", highlightColorList[3]);
       }

   }

   private void destroyObj()
   {
       var highlightObjInScene = GameObject.Find("highlightObj(Clone)");
       if (highlightObjInScene)
       {
           Destroy(highlightObjInScene);
           Debug.Log("Destroyed!");
       }


   }

    /*Holds the colors for highlighting*/
   private void setColors()
   {
       highlightColorList.Add(new Color(1, 1, 0, 1));
       highlightColorList.Add(new Color(1, 0.81f, 0, 1));
       highlightColorList.Add(new Color(1, 0.75f, 0, 1));
       highlightColorList.Add(new Color(1, 0.7f, 0, 1));
       highlightColorList.Add(new Color(1, 0.63f, 0, 1));
       highlightColorList.Add(new Color(1, 0.51f, 0, 1));
       highlightColorList.Add(new Color(1, 0.4f, 0, 1));
       highlightColorList.Add(new Color(1, 0.25f, 0, 1));
   }
}
