using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private GameObject ShopLabel;
    [SerializeField]
    private GameObject BuildingPanel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetActiveShop(bool active) {
        ShopLabel.SetActive(active);
    }
    public void ChangeActiveShop()
    { 
        ShopLabel.SetActive(!ShopLabel.activeSelf);
    }

    public void ChangeActiveBuildingPanel(bool active) {
        BuildingPanel.SetActive(active);
    }
}
