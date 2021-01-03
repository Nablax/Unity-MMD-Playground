using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    //store the notes map with the music number (number define can see in the music director)
    //the notes are stored as string array where s refers to key s, fj refers to key f and j
    public static string[][] noteMap = {
        new string[]{"s", "d", "f", "j", "k", "l", "fj", "dk", "sl"}, // first song
        new string[]{"s", "d", "f", "j", "k", "l", "fj", "dk", "sl"}  // second song
    };
 }
