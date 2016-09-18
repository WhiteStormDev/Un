using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool destroyWhenActivated;

  
    void Start() {
        theTextBox = FindObjectOfType<TextBoxManager>();
    }

    
    void Update() {
        if (theTextBox._currentLine == 1 && !theTextBox.isTyping)
        {
            theTextBox.holdCurrent = true;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                theTextBox.holdCurrent = false;
                theTextBox._currentLine = 3;

                theTextBox.isCurrentLineChanged = true;
                theTextBox.cancelTyping = false;
                theTextBox.isTyping = true;


            }
        }
        //if (theTextBox._currentLine == 1)
        //{
        //    theTextBox.holdCurrent = true;
        //    if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {
        //        //theTextBox.holdCurrent = false;
        //        theTextBox._currentLine = 4;

        //        theTextBox.isCurrentLineChanged = true;
        //    }
        //}
        //if (theTextBox._currentLine == 1)
        //{
        //    theTextBox.holdCurrent = true;
        //    if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {
        //        //theTextBox.holdCurrent = false;
        //        theTextBox._currentLine = 5;

        //        theTextBox.isCurrentLineChanged = true;
        //    }
        //}



    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
            Debug.Log("Checked");

        if (Input.GetKeyDown(KeyCode.DownArrow) && col.gameObject.tag == "Player" && theTextBox._currentLine == -1)
        {



            //if (theTextBox.isTyping || !theTextBox.isTyping && theTextBox._currentLine != 1 )
            //{
            theTextBox.launched = true;
                theTextBox.ReloadScript(theText);
                theTextBox._currentLine = startLine;
                theTextBox._endAtLine = endLine;
                theTextBox.EnableTextBox();
                
            //}
            
        }
    }


}
