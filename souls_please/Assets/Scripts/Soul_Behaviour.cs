using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Soul_Behaviour : MonoBehaviour
{
    private GameObject[] Souls;
    private float spacing = 0.75f;
    private float speed = 0.3f;
    private Vector3 destination = new Vector3(-0.382f, 0.26f, -7.52f);


    private void Start()
    {
        Souls = GameObject.FindGameObjectsWithTag("Souls");
    }
    private void Update()
    {
        for (int i = 0; i < Souls.Length; i++)
        {
            if (i == 0)
            {
                // Move the first object toward the target
                Souls[i].transform.position = Vector3.MoveTowards(Souls[i].transform.position, destination, speed * Time.deltaTime);
            }
            else
            {
                // Calculate the target position with respect to the previous object
                Vector3 previousPosition = Souls[i - 1].transform.position;
                Vector3 targetPosition = previousPosition - Souls[i - 1].transform.forward * spacing;

                // Move the current object only if it's not colliding with the previous object
                if (Vector3.Distance(Souls[i].transform.position, previousPosition) > spacing)
                {
                    Souls[i].transform.position = Vector3.MoveTowards(Souls[i].transform.position, targetPosition, speed * Time.deltaTime);
                }
            }
        }
    }
}
