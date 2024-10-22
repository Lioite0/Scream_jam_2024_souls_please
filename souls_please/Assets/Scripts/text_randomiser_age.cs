using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class text_randomiser_age : MonoBehaviour
{
    // Start is called before the first frame update
     System.Random random = new System.Random();
    public TMP_Text text;
    void Start()
    {
       randomize();
    }
    void randomize(){
 int randAge = random.Next(10, 101);

        text.text = randAge.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
