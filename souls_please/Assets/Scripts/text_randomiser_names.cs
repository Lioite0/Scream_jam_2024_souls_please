using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class text_randomiser_names : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text text;

    
    void Start()
    {
        System.Random random = new System.Random();
        string[] namesFem = new string[]
        {
            "Elsie",
            "Cordelia",
            "Cheryl",
            "Diana",
            "Lara",
            "Rheyna",
            "Charlotte",
            "Sofia",
            "Ashe",
            "Luna",
            "Gabrielle",
            "Isabella",
            "Kaloipe",
            "Felicia",
            "Artemis",
            "Baylie",
            "Willow",
            "Natalie",
            "Maria",
            "Sarah"
        };

        string[] namesMasc = new string[]
        {
            "Liam",
            "James",
            "Oliver",
            "Jack",
            "Adrian",
            "Leon",
            "Mitchell",
            "Daniel",
            "Darcy",
            "Trevor",
            "Jonathan",
            "Noel",
            "Marty",
            "Ryan",
            "Paul",
            "Andreas",
            "Peter",
            "Colin",
            "Dominic",
            "Tobias"
        };

        string[] namesLast = new string[]
        {
            "Danslow",
            "O'Farrel",
            "Ignatidis",
            "Rossi",
            "Machell",
            "Reiper",
            "Tepes",
            "Belmont",
            "Morningstar",
            "Bowie",
            "Mason",
            "Sunderland",
            "Winters",
            "Beifong",
            "Azula",
            "Chase",
            "Griffith",
            "Joestar",
            "Giles",
            "Miyazaki"
        };
        List<string[]> first = new List<string[]>();
        first.Add(namesFem);
        first.Add(namesMasc);
       int randint = random.Next(first.Count);
       string randName = first[randint][UnityEngine.Random.Range(0, first[randint].Length)];
        text.text = randName + " " + namesLast[UnityEngine.Random.Range(0, namesLast.Length)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
