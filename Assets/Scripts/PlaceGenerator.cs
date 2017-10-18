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
    private GameObject tree;
    [SerializeField]
    private float Density=1f;
    void Start()
    {
        int CountObects = (int)(farBorder * farBorder * Density);
        Vector3[] TressPositions = new Vector3[CountObects];

        for (int i = 0; i < CountObects; i++)
        {
            float x=Random.Range(-farBorder, farBorder) + center.x;
            float z= Random.Range(-farBorder, farBorder) + center.z;
            Vector3 newPositon = new Vector3(x, center.y, z);
            TressPositions[i] = newPositon;
        }

        for (int i = 0; i < CountObects; i++)
        {
            if (Mathf.Abs(TressPositions[i].x) < nearBorder && Mathf.Abs(TressPositions[i].z) < nearBorder) {

            }
        }
        for (int i = 0; i < CountObects; i++)
        {
            if (!(Mathf.Abs(TressPositions[i].x) < nearBorder && Mathf.Abs(TressPositions[i].z) < nearBorder))
            {
                Instantiate(tree, TressPositions[i], transform.rotation);
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
