using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cursorBarrel : MonoBehaviour
{
    public bool isbarrelclick;
    public DragandDrop cursorcontroller;
    public GameObject rockPrefab;
    public GameObject player;
    public float rockspeed = 8f;
    public InventoryObject inventory;
    public TextMeshProUGUI rockcounts; 
    public GameObject equipemptywarning;
    public List<GameObject> supplies;
    private bool IsFirstClicked = false;
    private GameObject supply;
    public GameObject barrelinstruction;
    public GameObject equipwarnpointer;
    public GameObject needmorerocks; 

    // Update is called once per frame
    void Update()
    {
        if (isbarrelclick)
        {
            //if maskcounts are zero and other's are either two 
            if (inventory.maskcounts == 0 && (inventory.stainerizercounts >= inventory.maskcounts + 10 || inventory.wallcounts >= inventory.maskcounts + 10))
            {
                supply = supplies[0];
            }
            //if stanitizer are zero 
            else if (inventory.stainerizercounts == 0 && (inventory.maskcounts >= inventory.stainerizercounts + 10 || inventory.wallcounts >= inventory.stainerizercounts + 10))
            {
                supply = supplies[1];
            }
            //if wallcounts are zero 
            else if (inventory.wallcounts == 0 && (inventory.maskcounts >= inventory.wallcounts + 10 || inventory.stainerizercounts >= inventory.wallcounts + 10))
            {
                supply = supplies[2];
            }
            else
            {
                supply = supplies[Random.Range(0, supplies.Count)];
            }
            //Then instainiate
            Instantiate(supply, transform.position, Quaternion.identity);
            //Then destory this barrel 
            Destroy(gameObject);
            isbarrelclick = false; 
        }
    }
    public void OnMouseEnter()
    {
        if (inventory.ismouseonselectbox == false)
        {
            cursorcontroller.enableaim();
            barrelinstruction.SetActive(true);
        }
        else
        {
            return; 
        }
        
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal();
        barrelinstruction.SetActive(false); 
    }
    public void OnMouseDown()
    {
        if (inventory.ismouseonselectbox == false)
        {
            if (GameObject.Find("RockSprite(Clone)") != null && inventory.rockcounts > 0 && IsFirstClicked == false)
            {
                IsFirstClicked = true;
                isbarrelclick = true;
                inventory.barrelstag.Add(gameObject.name);
                cursorcontroller.enablenormal();
                barrelinstruction.SetActive(false);
                inventory.rockcounts -= 1;
                rockcounts.text = inventory.rockcounts.ToString("0");
            }
            else if (GameObject.Find("RockSprite(Clone)") == null && inventory.rockcounts > 0)
            {
                StartCoroutine(showemptysign());
                isbarrelclick = false;
            }
            else if (GameObject.Find("RockSprite(Clone)") == null && inventory.rockcounts == 0)
            {
                StartCoroutine(shownorocksign());
            }
            else if (IsFirstClicked)
            {
                return;
            }
        }
        else
        {
            return; 
        }
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }

    IEnumerator showemptysign()
    {
        equipemptywarning.SetActive(true);
        equipwarnpointer.SetActive(true); 
        yield return new WaitForSeconds(3f);
        equipemptywarning.SetActive(false);
        equipwarnpointer.SetActive(false);
    }
    IEnumerator shownorocksign()
    {
        needmorerocks.SetActive(true);
        yield return new WaitForSeconds(3f);
        needmorerocks.SetActive(false); 
    }
}
