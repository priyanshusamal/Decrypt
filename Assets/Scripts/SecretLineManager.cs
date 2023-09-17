using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class SecretLineManager : MonoBehaviour
{
    // [SerializeField] TextMeshProUGUI mainText;

    // // Start is called before the first frame update
    // //void Start()
    // //{
    // //    //SetMainText();
    // //}

    // // Update is called once per frame
    // void Update()
    // {
       
    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         SearchAlphabets("t");
    //     }
    //     if (currentIndex < originalText.Length)
    //     {
    //         char currentChar = originalText[currentIndex];

    //         // Check if the current letter matches the target letter and it's not already green
    //         if (char.ToUpper(currentChar) == char.ToUpper(targetLetter) && !letterChanged[currentIndex])
    //         {
    //             // Change the color of the current letter to green
    //             ModifyText(currentIndex, "<color=green>" + currentChar + "</color>");
    //             letterChanged[currentIndex] = true; // Mark this letter as changed
    //         }

    //         currentIndex++; // Move to the next index
    //     }
    // }
    // public void SetMainText()
    // {
    //     mainText.text = "We have to make a game on given theme";
    // }
    // public void SearchAlphabets(string alphabet)
    // {
    //     int letterValue = 0;
    //     string s = mainText.text;
    //     char newChar = alphabet.ToCharArray()[0];
    //     if (Regex.IsMatch(mainText.text, alphabet))
    //     {
    //         Debug.Log(alphabet);
    //     }
    //     for (int i = 0; i < s.Length; i++)
    //     {
    //         char c = s[i];
    //         //Debug.Log(c);
    //         if (c != newChar)
    //         {
    //             continue;
    //         }
    //         else
    //         {
                
    //             //string n = $"Deal <color=green>{ alphabet }</color> damage to the target";
    //             //mainText.text = n;
    //             //Debug.Log("work");
    //             //TextMeshProUGUI newString;
    //             //newString.text = s[i].ToString();
    //             //if(newString.color != Color.green)
    //             //{
    //             //if (mainText != null && !string.IsNullOrEmpty(alphabet))
    //             //    {
    //             //        // Format the text with rich text to make the first letter green
    //             //        string formattedText = "<color=green>" + s.Substring(0, letterValue) + "</color>" + s.Substring(letterValue);

    //             //        // Update the UI Text component with the formatted text
    //             //        mainText.text = formattedText;
    //             //    }
    //             //    letterValue++;
    //             //}
                
    //         }

           
    //     }

    //     //foreach (char c in s)
    //     //{
    //     //    //Debug.Log(c);
    //     //}
    // }
    // public int targetLetterIndex;
    // public TextMeshProUGUI textComponent; // Reference to the Text component where the string is displayed
    // public char targetLetter = 'A'; // The letter you want to match

    // private string originalText; // Store the original text
    // private bool[] letterChanged; // Keep track of which letters have been changed
    // private int currentIndex = 0; // Index of the current letter

    // private void Start()
    // {
    //     SetMainText();
    //     if (textComponent != null)
    //     {
    //         originalText = textComponent.text; // Store the original text
    //         letterChanged = new bool[originalText.Length]; // Initialize the array
    //     }
    //     else
    //     {
    //         Debug.LogError("Text component not assigned!");
    //     }
    // }

  

    // private void ModifyText(int index, string newText)
    // {
    //     // Create a StringBuilder to modify the text efficiently
    //     System.Text.StringBuilder modifiedText = new System.Text.StringBuilder(originalText);
    //     modifiedText.Remove(index, newText.Length);
    //     modifiedText.Insert(index, newText);

    //     // Update the text component with the modified text
    //     textComponent.text = modifiedText.ToString();
    // }
   

}


    
