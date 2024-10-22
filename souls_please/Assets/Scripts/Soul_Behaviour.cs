using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul_Behaviour : MonoBehaviour
{
    private Game_Mechanic gameMachanicScript;
    public float speed = 1f;

    private void Start()
    {
        gameMachanicScript = GetComponent<Game_Mechanic>();
    }
    private void Update()
    {
          transform.position = Vector3.MoveTowards(transform.position, gameMachanicScript.destinationPoint.position, speed * Time.deltaTime);
    }
}
