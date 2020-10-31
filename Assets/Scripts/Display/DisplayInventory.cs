using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public GameObject object_template;
    public GameObject item_info_panel;
    public Image item_image;
    public Text item_name;
    public Text item_number;
    public Text item_type;
    public Text item_description;

    Inventory inventory_manager = null;

    MyObject item_selected;

    List<GameObject> object_displayed;
    uint lines = 4;
    uint columns = 8;
    Vector2 size;
    float multi = 1.23f;

    void Awake()
    {
        if (inventory_manager is null)
        {
            inventory_manager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Inventory>();
            object_displayed = new List<GameObject>();
            size = object_template.GetComponent<RectTransform>().sizeDelta;
            item_selected = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayObjects()
    {
        if (inventory_manager is null)
        {
            Awake();
        }
        List<MyObject> myObjects = inventory_manager.GetSubListObjects(columns * lines);
        object_template.SetActive(true);

        for (int i = 0; i < myObjects.Count; ++i)
        {
            GameObject duplicate = Utils.DuplicateObject(object_template);
            Image img = duplicate.GetComponent<Image>();
            img.sprite = myObjects[i].sprite;

            // elements on grid
            duplicate.GetComponent<RectTransform>().anchoredPosition += new Vector2((i % columns) * size.x * multi,
                                                                                    (int)(i / columns) * -size.y * multi);
            duplicate.name = myObjects[i].objname;
            object_displayed.Add(duplicate);
        }
        object_template.SetActive(false);
    }

    public void DestroyTmpObjects()
    {
        for (int i = 0; i < object_displayed.Count; ++i)
        {
            Destroy(object_displayed[i]);
        }
        object_displayed.Clear();
    }

    public void ShowItemDetail()
    {
        string objname = EventSystem.current.currentSelectedGameObject.name;

        List<MyObject> items = inventory_manager.SearchByName(objname);
        if (items.Count == 0)
        {
            Debug.Log("Error: item not found");
            return;
        }

        objname = objname[0].ToString().ToUpper() + objname.Substring(1);
        item_name.text = objname;
        item_image.sprite = items[0].sprite;
        item_number.text = "Nb items: " + items.Count.ToString();
        item_type.text = "Type: " + items[0].type.ToString();
        item_description.text = items[0].description;

        item_selected = items[0];

        item_info_panel.SetActive(true);
    }

    public void ItemActionClick()
    {
        bool to_remove = inventory_manager.UseObject(item_selected);
        if (to_remove)
        {
            int nb = System.Int32.Parse(item_number.text.Split(' ')[2]);
            item_number.text = "Nb items: " + (nb - 1).ToString();
        }
    }

    public void ItemDeleteClick()
    {
        inventory_manager.RemoveObject(item_selected);
        int nb = System.Int32.Parse(item_number.text.Split(' ')[2]);
        item_number.text = "Nb items: " + (nb - 1).ToString();
    }

    public void ItemReturnClick()
    {
        item_info_panel.SetActive(false);
        DestroyTmpObjects();
        DisplayObjects();
    }
}