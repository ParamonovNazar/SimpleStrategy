using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public string NameItem;
    public GameObject Prefab;
    public Sprite Icon;

    private BuildingManager buildingManager;
    private UIManager uIManager;
    
    void Start()
    {

    }
    public void SetBuildingManager(BuildingManager bm) {
        buildingManager = bm;
    }
    public void SetUIManager(UIManager uim)
    {
        uIManager = uim;
    }
    public void OnClickItem()
    {
        ShopItem item = GetComponent<ShopItem>();
        buildingManager.TryToLocate(item);
        uIManager.SetActiveShop(false);
    }
}
