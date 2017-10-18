using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    [SerializeField]
    private BuildingManager buildingManager;
    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private List<Button> items;

    [SerializeField]
    private GameObject parentToItem;
  
    void Start () {
        foreach (Button b in items) {
            Button item = Instantiate(b);
            ShopItem shopItem = item.GetComponent<ShopItem>();
            if (shopItem) {
                Text text = item.GetComponentInChildren<Text>();
                if (text) {
                    text.text = shopItem.NameItem;
                }
                Image icon = item.GetComponent<Image>();
                if (icon)
                {
                    icon.sprite = shopItem.Icon;
                }
                item.transform.SetParent( parentToItem.transform);
                shopItem.SetUIManager(uIManager);
                shopItem.SetBuildingManager(buildingManager);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
