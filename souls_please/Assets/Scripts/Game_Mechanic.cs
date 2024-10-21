using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Mechanic : MonoBehaviour
{
    //setup for getting the banned requests
    public List<string[]> bannedRequests = new List<string[]>();
    
    public string[] bannedGood = SelectRandomRequests(goodList, 10);

    public string[] bannedBad = SelectRandomRequests(badList, 10);

    public string[] bannedNeutral = SelectRandomRequests(neutralList, 15);

// lists containing possible reuqests
    static string[] goodList = new string[]
        {
            "World Peace",
            "Inspiration",
            "Truth",
            "Bring a lost soul back from the brink",
            "A random act of kindness",
            "Wonder",
            "Compassion",
            "Laughter",
            "Remind someone why they should live",
            "Protect future generations from harm",
            "No one should go hungry",
            "Stop natural disasters",
            "Find a cure for cancer",
            "Wisdom",
            "Give my soul to someone who needs it",
            "Everyone gets access to education",
            "Stop persecution",
            "Hope",
            "Freedom",
            "Restore ecological balance to the world",
            "No more addiction",
            "Old people won't be lonely",
            "Justice",
            "Cease all physical pain",
            "To let people speak to their loved ones, one more time",
            "Remove all billionaires (lol)",
            "Strength",
            "A House",
            "A lifelong friendship",
            "A well of fresh water",
            "A lantern that never goes out",
            "A lake that reflects memories",
            "A pair of spectacles",
            "Magic Powers",
            "1 Up mushroom",
            "My guiding moonlight",
            "Be good at everything I do",
            "A comfortable bed",
            "Endless food supply",
            "Perfect weather",
            "A house by the sea",
            "A warm coat",
            "Eternal calm",
            "A loyal pet",
            "A single wish",
            "To win the scream jam",
            "Make people realize Nintendo isn't actually good",
            "One more night of the boys playing games together",
            "Him to call me back",
            "I hope I get that job"
        };

        static string[] badList = new string[]
        {
            "The raven comes back",
            "Never ending famine",
            "Betrayal",
            "A grudge",
            "A curse",
            "Fear that paralyzes",
            "A debt never forgiven",
            "Chains that bind",
            "Anger",
            "Change my identity at will",
            "Spread an uncurable virus",
            "Complete monopoly on medical supplies",
            "An obsession",
            "Despair in a smile",
            "Time stolen away",
            "A storm that never ends",
            "To stop Harry from meeting Sally",
            "An empty promise",
            "A venomous thought",
            "Fear",
            "Greed beyond measure",
            "Loss",
            "A candle snuffed out",
            "A wound that never heals",
            "A Massacre",
            "The Abyss",
            "Slavery",
            "My neighbour goes homeless",
            "Frostbite of the soul",
            "To rule the world with an iron fist",
            "Bring Hitler back",
            "A shadow that obeys",
            "Take my soul so I can have theirs",
            "Always win at gambling",
            "X-ray vision",
            "Invisible",
            "World Domination",
            "Bring the dead back to life as they are now",
            "They get fired from work",
            "My rich parents take everyone out of the will but measure",
            "Knowledge of everyone's darkest secret",
            "Everyone only has nightmares, no dreams",
            "Immunity from all laws",
            "Influence over the world’s media",
            "Manipulation of someone’s memories",
            "Control over the stock markets",
            "Can gaslight anyone",
            "Don't have to give back that game I borrowed",
            "Own anything I touch",
            "Spoil the endings to every show people start watching"
        };

        static string[] neutralList = new string[]
        {
            "A musical instrument",
            "My room always smells nice",
            "To change the paint in my house whenever I want",
            "Knowledge of languages",
            "To be skinny",
            "An endless library",
            "A quiet forest",
            "A rare gemstone",
            "An old map",
            "A unique painting",
            "Be muscular",
            "An ancient artifact",
            "Fish and chips",
            "A key that doesn't open anything but looks cool",
            "A hidden talent",
            "Become fit again",
            "A hat",
            "A melody",
            "A garden that never withers",
            "A mountain cabin",
            "Endless curiosity",
            "An enchanted sword",
            "An endless night sky",
            "Control over one element",
            "A locked chest",
            "A secret recipe",
            "That new smartwatch",
            "A room full of candles",
            "A warm hearth",
            "A cozy cottage",
            "A full moon",
            "A mysterious book",
            "An old photograph",
            "Ice cream",
            "A treehouse",
            "A compass that leads to a random spot in the world",
            "A single flower",
            "Endless ink",
            "A golden coin",
            "A pair of wings",
            "A ring",
            "A glass of wine that never empties",
            "A blanket that always warms",
            "A stone tower",
            "A deep well",
            "All the books I want",
            "A door to nowhere",
            "Chicken",
            "A new computer",
            "A box of secrets",
            "Every rare card",
            "A peaceful meadow",
            "A pair of shoes",
            "A mirror",
            "A cup of tea",
            "A sunset that lasts forever",
            "Comfy shoes",
            "A glowing crystal",
            "A pocket watch",
            "Fix my car",
            "A soft pillow",
            "A whispering breeze",
            "A set of keys",
            "A path through the woods",
            "A feather",
            "A pair of gloves",
            "A golden harp",
            "A cup of fresh coffee",
            "A quiet place",
            "Tendies",
            "A handwritten letter",
            "A bonfire",
            "The strength to tell my boss off",
            "French tipped nails",
            "Fix my hearing"
        };

    //Assign day and quota perday
    public int startQuota=15;
    public int dayQuota = 10;
    private int currentQuota;
    private int dayNumber = 1;
    private int quotaProgress = 0;

    //Assign Timer
    public TMP_Text timerText;
    private float duration = 300f;
    private float currentTime = 0f;

    public static bool completedQuota = false;

    private UI_Manager uiManagerScript;

    public GameObject soulPref;
    private GameObject[] soulNumb;
    private float spacing;

//function for selecting the random banned requests
    public static T[] SelectRandomRequests<T>(T[] array, int numberOfItems)
    {
        
        HashSet<int> indices = new HashSet<int>();
        System.Random random = new System.Random();

        while (indices.Count < numberOfItems)
        {
            int randomIndex = random.Next(array.Length);
            indices.Add(randomIndex);
        }

        T[] selectedItems = new T[numberOfItems];
        int i = 0;
        foreach (var index in indices)
        {
            selectedItems[i++] = array[index];
        }

        return selectedItems;
    }

    private void Start()
    {
        currentQuota = startQuota;
        currentTime = duration;
        uiManagerScript = GetComponent<UI_Manager>();
    }

    private void Update()
    {
        //Find all the soul in a scene
        //soulNumb = GameObject.FindGameObjectsWithTag("Souls");
        if (completedQuota == false || currentTime > 0)
        {
            TimerStart();
        }
        if (quotaProgress == currentQuota)
        {
            completedQuota = true;
        }
    }

    /*void InstantiateSouls()
    {
        //Instantiate Souls 
        for (int i = 0; i < currentQuota; i++)
        {
            if (soulNumb.Length < 10)
            {
                Vector3 position = new Vector3(i * spacing, 0, 0);
                GameObject instantiateSoul = Instantiate(soulPref, position, Quaternion.identity);
            }
        }
    }*/
    void TimerStart()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            timerText.text = Mathf.Floor(currentTime).ToString("00");
        }
    }

    public void NewDay()
    {
        // InstantiateSouls();
        bannedRequests.Add(bannedBad);
        bannedRequests.Add(bannedGood);
        bannedRequests.Add(bannedNeutral);
        uiManagerScript.dayText.text = ("Day" + dayNumber);
        dayNumber++;
        completedQuota = false;
        currentQuota = startQuota + dayQuota*(dayNumber-1);
        quotaProgress = 0;
    }
}
