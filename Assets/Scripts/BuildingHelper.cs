using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHelper : MonoBehaviour {
    [SerializeField]
    private string PrefabName;
    [SerializeField]
    private Vector3 Offset = Vector3.zero;

    [SerializeField]
    public int col=1;
    [SerializeField]
    public int row=1;

    public Vector3 topLeftOfArea=Vector3.zero;

    void Start () {
        		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetStart(Vector3 cell) {
        //TODO edit to center 
        topLeftOfArea = cell ;
        transform.position = cell + Offset;
    }

    public Vector3 GetStart()
    {
        return topLeftOfArea;
    }
    public int GetCol() {
        return col;
    }

    public int GetRow() {
        return row;
    }

    public void OnMouseDown()
    {
        Debug.Log("Information about object: name:" + PrefabName+", size(c/r) " + col +"/" + row );
    }
}
