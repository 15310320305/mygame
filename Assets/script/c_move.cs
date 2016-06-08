using UnityEngine;
using System.Collections;

public class c_move : MonoBehaviour {

    public Transform character;   //摄像机要跟随的人物 

    private Vector3 cameraVelocity ;

    private Camera mainCamera;
    public float pianyi;

    //主摄像机（有时候会在工程中有多个摄像机，但是只能有一个主摄像机吧）     

    void Awake()
    {
        pianyi = character.transform.position.x;
        cameraVelocity = transform.position;

    }

    void Update()
    {
        float xx = character.transform.position.x - pianyi;
        if(transform.position.x+xx>=4&&transform.position.x+xx<=22)
        transform.position = cameraVelocity + new Vector3(xx,0f,0f);
        

    }

    
}
