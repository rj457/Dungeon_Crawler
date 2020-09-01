using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class inventorybuttons : MonoBehaviour
{
    public GameObject equipSlot;
    public GameObject rockPrefab;
    public TextMeshProUGUI numbercount;
    public InventoryObject inventory;
    public Animator transition;
    public GameObject noRocksign; 

    public void OnRockClick()
    {
        if (GameObject.Find("RockSprite(Clone)") == null && inventory.rockcounts > 0)
        {
            var newrock = Instantiate(rockPrefab, equipSlot.transform.position, Quaternion.identity);
            newrock.transform.parent = equipSlot.transform;
            numbercount.text = inventory.rockcounts.ToString("0");
        }
        else if (GameObject.Find("RockSprite(Clone)") == null && inventory.rockcounts == 0)
        {
            StartCoroutine(shownorocksign()); 
        }
        else
        {
            return; 
        }
    }
    public void OnEnterPress()
    {
        StartCoroutine(PlayerEngage());
    }

    IEnumerator PlayerEngage()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
    IEnumerator shownorocksign()
    {
        noRocksign.SetActive(true);
        yield return new WaitForSeconds(2f);
        noRocksign.SetActive(false); 
    }
}
