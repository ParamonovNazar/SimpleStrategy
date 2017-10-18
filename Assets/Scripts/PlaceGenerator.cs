using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceGenerator : MonoBehaviour {
    
    private Vector3 center=Vector3.zero;
    [SerializeField]
    private float nearBorder;
    [SerializeField]
    private float farBorder;
    [SerializeField]
    private List<GameObject>  TerraObjects;
    [SerializeField]
    private float Density=1f;

    [SerializeField]
    private GameObject terraParent;
    void Start()
    {
        int CountObects = (int)(farBorder * farBorder * Density);
        Vector3[] TerraPosition = new Vector3[CountObects];

        for (int i = 0; i < CountObects; i++)
        {
            float x=Random.Range(-farBorder, farBorder) + center.x;
            float z= Random.Range(-farBorder, farBorder) + center.z;
            Vector3 newPositon = new Vector3(x, center.y, z);
            TerraPosition[i] = newPositon;
        }

        for (int i = 0; i < CountObects; i++)
        {
            if (!(Mathf.Abs(TerraPosition[i].x) < nearBorder && Mathf.Abs(TerraPosition[i].z) < nearBorder))
            {
                int rand = Random.Range(0, TerraObjects.Count);
                GameObject terra =Instantiate(TerraObjects[rand], TerraPosition[i], transform.rotation);
                terra.transform.SetParent(terraParent.transform);
            }  
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCenter(Vector3 c) {
        center = c;
    }
}
