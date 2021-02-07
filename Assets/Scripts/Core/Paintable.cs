using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public GameObject Brush;
    public float BrushSize = 0.1f;

    
	
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButton(0))
        {
            //cast a ray to the plane
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit))
            {
                //instanciate a brush
                var go = Instantiate(Brush, hit.point + Vector3.forward *(-1f/20f), Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize;
                go.transform.localRotation = new Quaternion(0f,0f,-90f, 1f);
            }

        }
    }

}
