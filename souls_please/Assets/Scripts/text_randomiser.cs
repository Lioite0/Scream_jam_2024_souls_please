using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text_randomiser : MonoBehaviour
{
    public TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        string[] neutralList = {"A musical instrument","Perfect weather","A house by the sea","Endless food supply","Knowledge of languages","Strength","A comfortable bed","An endless library","A quiet forest","A rare gemstone","An old map","A unique painting","A warm coat","An ancient artifact","A lifelong friendship","A new identity","A hidden talent","Eternal calm","A garden that never withers","A mountain cabin","Endless curiosity","An enchanted sword","An endless night sky","Control over one element","A locked chest","A secret recipe","A loyal pet","A room full of candles","A warm hearth","A cozy cottage","A full moon","A mysterious book","An old photograph","A well of fresh water","A treehouse","A compass","A single flower","Endless ink","A golden coin","A pair of wings","A ring","A glass of wine that never empties","A blanket that always warms","A stone tower","A deep well","A shadow that obeys","A door to nowhere","A staircase with no end","A lantern that never goes out","A box of secrets","A single wish","A peaceful meadow","A pair of shoes","A mirror","A cup of tea","A sunset that lasts forever","A bridge over a river","A glowing crystal","A pocket watch","A lake that reflects memories","A soft pillow","A whispering breeze","A set of keys","A path through the woods","A feather","A pair of gloves","A golden harp","A cup of fresh coffee","A friendly smile","A quiet place","A pair of spectacles","A handwritten letter","A bonfire","A hat","A melody"};
        string randomWord = neutralList[UnityEngine.Random.Range(0, neutralList.Length)];

        text.text = randomWord;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
