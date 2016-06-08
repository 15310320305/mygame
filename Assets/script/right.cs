using UnityEngine;
using System.Collections;

public class right : MonoBehaviour {
    public move hori;

    public void OnMouseEnter()
    {
        hori.horiziontal_move = 1f;
    }

    public void OnMouseExit()
    {
        hori.horiziontal_move = 0f;
    }   
	
}
