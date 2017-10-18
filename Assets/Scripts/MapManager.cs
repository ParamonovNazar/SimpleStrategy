using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(FogGenerator))]
[RequireComponent(typeof(PlaceGenerator))]
public class MapManager : MonoBehaviour {
    [SerializeField]
    public Vector3 Center { get; private set; }
    private FogGenerator fog;
    private PlaceGenerator place;

    void Start () {
        fog = GetComponent<FogGenerator>();

        fog.StartUp();
    }
	
	void Update () {
		
	}
}
