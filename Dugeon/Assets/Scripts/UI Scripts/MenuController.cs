using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject Instruction;
    public Animator transition; 

    public void OnStartButton()
    {
        StartCoroutine(StartGame());
    }

    public void OnInstructionButton()
    {
        Instruction.SetActive(true);
        startmenu.SetActive(false);
    }
    
    public void OnBackButton()
    {
        Instruction.SetActive(false);
        startmenu.SetActive(true);
    }

    public void OnQuitButton()
    {
        Application.Quit(); 
    }

    IEnumerator StartGame()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
