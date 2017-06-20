using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : Window
{
    bool ServerMode = false;

    private void Start()
    {
       if(!ServerMode)
        {
            ShowView(R.findViewById("Client"));
            HideView(R.findViewById("Server"));
        }
       else
        {
            HideView(R.findViewById("Client"));
            ShowView(R.findViewById("Server"));
        }
    }
}
