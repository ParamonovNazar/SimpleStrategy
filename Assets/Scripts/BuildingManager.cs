using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {
    [SerializeField]
    private GameObject building;
    private GameObject tryToLacate = null;
    [SerializeField]
    private Grid GridManager;
    [SerializeField]
    private UIManager uIManager;
    private BuildingHelper bh;
    private List<GameObject> buildings;
    // Use this for initialization
	void Start () {
        buildings = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        if (tryToLacate) {
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                MoveBuildingRight();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveBuildingLeft();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveBuildingUp();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveBuildingDown();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tryToLacate)
            {
                Locate();
            }
            else {
                Quaternion q = Quaternion.Euler(0, 0, 0);
                tryToLacate = Instantiate(building, GridManager.GetGridCenter(), q);
                bh = tryToLacate.GetComponent<BuildingHelper>();
                bh.SetStart(GridManager.GetGridCenter());
                uIManager.ChangeActiveCancel(true);
            }
        }
        if (tryToLacate) {
            GridManager.SetActiveGrid(true);
        }
    }

    public void MoveBuildingUp() {
        Vector3 newPos = bh.GetStart() + new Vector3(GridManager.CellSize * Grid.UNITSIZE, 0, 0);
        if (GridManager.CheckArea(newPos, bh.col, bh.row))
        {
            bh.SetStart(newPos);
        }
    }
    public void MoveBuildingDown()
    {
        Vector3 newPos = bh.GetStart() - new Vector3(GridManager.CellSize * Grid.UNITSIZE, 0, 0);
        if (GridManager.CheckArea(newPos, bh.col, bh.row))
        {
            bh.SetStart(newPos);
        }
    }
    public void MoveBuildingLeft()
    {
        Vector3 newPos = bh.GetStart() - new Vector3(0, 0, GridManager.CellSize * Grid.UNITSIZE);
        if (GridManager.CheckArea(newPos, bh.col, bh.row))
        {
            bh.SetStart(newPos);
        }
    }
    public void MoveBuildingRight()
    {
        Vector3 newPos = bh.GetStart() + new Vector3(0, 0, GridManager.CellSize * Grid.UNITSIZE);
        if (GridManager.CheckArea(newPos, bh.col, bh.row))
        {
            bh.SetStart(newPos);
        }
    }
    public void TryToLocate(ShopItem item) {
        if (tryToLacate)
        {
            Destroy(tryToLacate);
        }
        else {
            tryToLacate = Instantiate(item.Prefab, GridManager.GetGridCenter(), Quaternion.identity);
            bh = tryToLacate.GetComponent<BuildingHelper>();
            bh.SetStart(GridManager.GetGridCenter());
            uIManager.ChangeActiveCancel(true);
        }
    }

    private void Locate() {
        if (GridManager.CheckArea(bh.topLeftOfArea, bh.col, bh.row))
        {
            buildings.Add(tryToLacate);
            GridManager.Build(bh.topLeftOfArea, bh.col, bh.row);
            tryToLacate = null;
            uIManager.ChangeActiveCancel(false);
        }
        else {
            Debug.Log("BUSY!!!");
        }
    }

    public void CancelBuilding() {
        Destroy(tryToLacate);
        uIManager.ChangeActiveCancel(false);
    }
}
