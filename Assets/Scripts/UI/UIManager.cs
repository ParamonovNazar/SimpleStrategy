using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private GameObject ShopLabel;
    [SerializeField]
    private GameObject Cancel;
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

    public void ChangeActiveCancel(bool active) {
        Cancel.SetActive(active);
    }
}
