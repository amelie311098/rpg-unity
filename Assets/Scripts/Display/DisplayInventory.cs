using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public GameObject object_template;
    Inventory inventory_manager = null;

    List<GameObject> object_displayed;
    uint lines = 4;
    uint columns = 8;
    Vector2 size;
    float multi = 1.23f;

    void Awake()
    {
        inventory_manager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Inventory>();
        object_displayed = new List<GameObject>();
        size = object_template.GetComponent<RectTransform>().sizeDelta;
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
}