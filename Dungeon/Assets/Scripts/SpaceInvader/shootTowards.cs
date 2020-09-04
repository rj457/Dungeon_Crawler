using System.Collections;
using UnityEngine;
using UnityEngine.UI; 

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
    public GameObject exitbutton;
    //skillcooldown
    public GameObject maskLoader;
    public GameObject washLoader;
    public GameObject wallLoader; 

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
        if (Input.GetMouseButtonDown(0) && exitbutton.GetComponent<IsButtonhover>().isexitbuttonhover == false)
        {   
            //if mask been selected shoot mask out
            if (scroller.indication == 1)
            {
                if (inventory.maskcounts > 0 && maskLoader.GetComponent<maskcooldown>().ismaskbooldown == false)
                {
                    maskLoader.GetComponent<maskcooldown>().ismaskbooldown = true;
                    maskLoader.GetComponent<Image>().fillAmount = 1; 
                    //instainate this prefab
                    Instantiate(maskPrefab,spawnposition.transform.position,Quaternion.identity);
                    inventory.maskcounts -= 1; 
                    //fly towards mouse position without stop 
                    clickedposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            //if stainerizer has been selected 
            if (scroller.indication == 2)
            {
                if (inventory.stainerizercounts > 0 && washLoader.GetComponent<washcooldown>().iswashcooldown == false)
                {
                    washLoader.GetComponent<washcooldown>().iswashcooldown = true;
                    washLoader.GetComponent<Image>().fillAmount = 1;
                    Instantiate(stainerizerPrefab, spawnposition.transform.position, Quaternion.identity);
                    inventory.stainerizercounts -= 1;
                    //fly towards mouse position without stop 
                    clickedposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            //if wall has been selected
            if (scroller.indication == 3)
            {
                if (inventory.wallcounts > 0 && wallLoader.GetComponent<wallcooldown>().iswallcooldown == false)
                {
                    wallLoader.GetComponent<wallcooldown>().iswallcooldown = true;
                    wallLoader.GetComponent<Image>().fillAmount = 1;
                    Instantiate(wallPrefab, spawnposition.transform.position, Quaternion.identity);
                    inventory.wallcounts -= 1;
                    //fly towards mouse position without stop 
                    clickedposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
    }
    
}
