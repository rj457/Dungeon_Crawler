﻿using System.Collections;
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
    private bool istouchingrock;
    public InventoryObject inventory;
    public TextMeshProUGUI rockcounts; 
    public GameObject equipemptywarning;
    public List<GameObject> supplies;
    private bool IsFirstClicked = false;
    private GameObject supply;
    public GameObject barrelinstruction;
    public GameObject equipwarnpointer;
    public Onselectionhover boxhover; 
    // Update is called once per frame
    void Update()
    {
        //if (isbarrelclick && GameObject.Find("RockSolid(Clone)") != null)
        //{
        //    GameObject.Find("RockSolid(Clone)").transform.position = Vector2.MoveTowards(GameObject.Find("RockSolid(Clone)").transform.position, new Vector2(transform.position.x, transform.position.y), rockspeed * Time.deltaTime);
        //    if (istouchingrock)
        //    {
        //        isbarrelclick = false; 
        //    }
        //}
        if (isbarrelclick && boxhover.ismouseoverselbox == false)
        {
            //if maskcounts are zero and other's are either two 
            if (inventory.maskcounts == 0 && (inventory.stainerizercounts >= inventory.maskcounts + 20 || inventory.wallcounts >= inventory.maskcounts + 20))
            {
                supply = supplies[0];
            }
            //if stanitizer are zero 
            else if (inventory.stainerizercounts == 0 && (inventory.maskcounts >= inventory.stainerizercounts + 20 || inventory.wallcounts >= inventory.stainerizercounts + 20))
            {
                supply = supplies[1];
            }
            //if wallcounts are zero 
            else if (inventory.wallcounts == 0 && (inventory.maskcounts >= inventory.wallcounts + 20 || inventory.stainerizercounts >= inventory.wallcounts + 20))
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
        cursorcontroller.enableaim();
        barrelinstruction.SetActive(true); 
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal();
        barrelinstruction.SetActive(false); 
    }
    public void OnMouseDown()
    {
        isbarrelclick = true;
        inventory.barrelstag.Add(gameObject.name);
        cursorcontroller.enablenormal();
        barrelinstruction.SetActive(false);
        if (GameObject.Find("RockSprite(Clone)") != null && inventory.rockcounts > 0 && IsFirstClicked == false)
        {
            IsFirstClicked = true; 
            //Vector3 spawnposition = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
            //Instantiate(rockPrefab, spawnposition, Quaternion.identity);
            inventory.rockcounts -= 1;
            rockcounts.text = inventory.rockcounts.ToString("0");
        }
        else if (GameObject.Find("RockSprite(Clone)") == null && inventory.rockcounts > 0)
        {
            StartCoroutine(showemptysign());
            isbarrelclick = false; 
        }
        if (IsFirstClicked)
        {
            return; 
        }
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }
    //void OnTriggerEnter2D (Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Rock")
    //    {
    //        istouchingrock = true;
    //        //if maskcounts are zero and other's are either two 
    //        if (inventory.maskcounts == 0 && (inventory.stainerizercounts >= inventory.maskcounts + 20 || inventory.wallcounts >= inventory.maskcounts + 20))
    //        {
    //            supply = supplies[0];
    //        }
    //        //if stanitizer are zero 
    //        else if (inventory.stainerizercounts == 0 && (inventory.maskcounts >= inventory.stainerizercounts + 20 || inventory.wallcounts >= inventory.stainerizercounts + 20))
    //        {
    //            supply = supplies[1];
    //        }
    //        //if wallcounts are zero 
    //        else if (inventory.wallcounts == 0 && (inventory.maskcounts >= inventory.wallcounts + 20 || inventory.stainerizercounts >= inventory.wallcounts + 20))
    //        {
    //            supply = supplies[2];
    //        }
    //        else 
    //        {
    //            supply = supplies[Random.Range(0, supplies.Count)];
    //        }
    //        //Then instainiate
    //        Instantiate(supply, transform.position, Quaternion.identity);
    //        //Then destory this barrel 
    //        Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
    IEnumerator showemptysign()
    {
        equipemptywarning.SetActive(true);
        equipwarnpointer.SetActive(true); 
        yield return new WaitForSeconds(3f);
        equipemptywarning.SetActive(false);
        equipwarnpointer.SetActive(false);
    }
}
