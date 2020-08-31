using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavemandilog : MonoBehaviour
{
    public recordplayer recordplayer;
    //grab all dialogs 
    public GameObject firstdialog;
    public GameObject seconddialog;
    public GameObject conditiondialog_escape;
    public GameObject conditiondialog_lost;
    public GameObject conditiondialog_win; 

    // Start is called before the first frame update
    void Start()
    {
        if (recordplayer.Isescape)
        {
            firstdialog.SetActive(false);
            seconddialog.SetActive(false);
            conditiondialog_escape.SetActive(true);
            conditiondialog_lost.SetActive(false);
            conditiondialog_win.SetActive(false);
            recordplayer.Isescape = false;
            recordplayer.IsLost = false;
            recordplayer.Iswin = false; 
        }
        if (recordplayer.IsLost)
        {
            firstdialog.SetActive(false);
            seconddialog.SetActive(false);
            conditiondialog_escape.SetActive(false);
            conditiondialog_lost.SetActive(true);
            conditiondialog_win.SetActive(false);
            recordplayer.Isescape = false;
            recordplayer.IsLost = false;
            recordplayer.Iswin = false;
        }
        if (recordplayer.Iswin)
        {
            firstdialog.SetActive(false);
            seconddialog.SetActive(false);
            conditiondialog_escape.SetActive(false);
            conditiondialog_lost.SetActive(false);
            conditiondialog_win.SetActive(true);
            recordplayer.Isescape = false;
            recordplayer.IsLost = false;
            recordplayer.Iswin = false;
        }

    }

}
