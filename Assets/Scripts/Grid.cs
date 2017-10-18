using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public const float UNITSIZE = 10f;
    [SerializeField]
    private Vector3 StartCell=Vector3.zero;
    [SerializeField]
    private int col=10;
    [SerializeField]
    private int row=10;

    public float CellSize = 2f;
    [SerializeField]
    private Color GridColorEmpty=Color.white;
    [SerializeField]
    private Color GridColorBusy = Color.white;
    [SerializeField]
    private GameObject Cell;

    private bool[,] StateCell;
    private GameObject[,] grid;

    void Start () {
        grid = new GameObject[col,row];
        StateCell = new bool[col,row];
        for (int i =0; i < col; i++)
        {
            for(int j=0; j<row; j++)
            {
                Vector3 pos = StartCell;
                pos += new Vector3(i * CellSize * UNITSIZE, 0, j * CellSize * UNITSIZE);
                Quaternion q = Quaternion.Euler(0, 0, 0);
                GameObject cell = Instantiate(Cell, pos, q);
                cell.transform.localScale = new Vector3(CellSize, 1, CellSize);
                StateCell[i, j] = true;
                cell.SetActive(false);
                grid[i, j] = cell;

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M)) {
            SetActiveGrid(!grid[0, 0].activeSelf);
        }
	}

    public void SetActiveGrid() {
        SetActiveGrid(!grid[0, 0].activeSelf);
    }

    public void SetActiveGrid(bool show)
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                grid[i, j].SetActive(show);
                if (show)
                {
                    Renderer rend = grid[i, j].GetComponent<Renderer>();
                    if (rend)
                    {
                        if (StateCell[i, j])
                        {
                            rend.material.color = GridColorEmpty;
                        }
                        else
                        {
                            rend.material.color = GridColorBusy;
                        }
                    }
                }
            }
        }

    }

    public bool CheckArea(Vector3 pos, int c, int r) {
        float StartX = StartCell.x;
        float StartZ = StartCell.z;

        int colBegin = Mathf.RoundToInt((pos.x - StartX) / (UNITSIZE * CellSize));
        int rowBegin = Mathf.RoundToInt((pos.z - StartZ) / (UNITSIZE * CellSize));
        if ((colBegin + c > col) || (rowBegin + r > row)|| (colBegin<0)|| (rowBegin<0)) {
            return false;
        }

        for (int i = colBegin; i < colBegin + c; i++)
        {
            for (int j = rowBegin; j < rowBegin + r; j++)
            {
                
                if(!StateCell[i, j])
                    return false;
            }
        }
        return true;
    }

    public Vector3 GetGridCenter()
    {
        return StartCell;
    }

    public Vector3 GetCellCenter(float x, float z) {
        return StartCell;
    }

    public void Build(Vector3 pos, int c, int r) {
        float StartX = StartCell.x ;
        float StartZ = StartCell.z ;

        int colBegin = Mathf.RoundToInt((pos.x - StartX)/ (UNITSIZE * CellSize));
        int rowBegin = Mathf.RoundToInt((pos.z - StartZ) / (UNITSIZE * CellSize));

        for (int i = colBegin; i < colBegin + c; i++) {
            for (int j = rowBegin; j < rowBegin + r; j++) {
                StateCell[i, j] = false;
            }
        }
        SetActiveGrid(false);
    }
}
