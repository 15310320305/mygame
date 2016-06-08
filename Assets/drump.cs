using UnityEngine;
using System.Collections;

public class drump : MonoBehaviour {

    public move hori;

    public void OnMouseEnter()
    {
        hori.drump = true;
    }

    public void OnMouseExit()
    {
        hori.drump = false;
    }   
}
