using System.Collections;
using UnityEngine;

public class shootTowards : MonoBehaviour
{
    public GameObject aimCursor;
    Vector2 mousePos;
    public Scroller scroller;
    public InventoryObject inventory;
    private float maskcooldown = 11;
    //mask properties 
    public GameObject spawnposition;
    public GameObject maskPrefab;
    public Vector3 clickedposition;
    //Stainerizer properties
    private float stainerizercooldown = 11;
    public GameObject stainerizerPrefab;
    //wall properties
    private float wallcooldown = 11;
    public GameObject wallPrefab; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        updateAim();
        checkmousepress();
    }
    void updateAim()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimCursor.transform.position = mousePos; 
    }
    void checkmousepress()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            //if mask been selected shoot mask out
            if (scroller.indication == 1)
            {
                if (inventory.maskcounts > 0 && maskcooldown > 10)
                {
                    maskcooldown = 0;
                    //instainate this prefab
                    Instantiate(maskPrefab,spawnposition.transform.position,Quaternion.identity);
                    inventory.maskcounts -= 1; 
                    //fly towards mouse position without stop 
                    clickedposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    StartCoroutine(skillmask());
                }
            }
            //if stainerizer has been selected 
            if (scroller.indication == 2)
            {
                if (inventory.stainerizercounts > 0 && stainerizercooldown > 10)
                {
                    stainerizercooldown = 0;
                    Instantiate(stainerizerPrefab, spawnposition.transform.position, Quaternion.identity);
                    inventory.stainerizercounts -= 1;
                    //fly towards mouse position without stop 
                    clickedposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    StartCoroutine(skillstainerizer());
                }
            }
            //if wall has been selected
            if (scroller.indication == 3)
            {
                if (inventory.wallcounts > 0 && wallcooldown > 10)
                {
                    wallcooldown = 0;
                    Instantiate(wallPrefab, spawnposition.transform.position, Quaternion.identity);
                    inventory.wallcounts -= 1;
                    //fly towards mouse position without stop 
                    clickedposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    StartCoroutine(skillwall());
                }
            }
        }
    }
    IEnumerator skillmask()
    {
        yield return new WaitForSeconds(2);
        maskcooldown = 11;
    }
    IEnumerator skillstainerizer()
    {
        yield return new WaitForSeconds(2);
        stainerizercooldown = 11; 
    }
    IEnumerator skillwall()
    {
        yield return new WaitForSeconds(2);
        wallcooldown = 11;
    }
}
