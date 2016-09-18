using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {




    public GameObject typingSound1;
    public GameObject typingSound2;
    public GameObject typingSound3;
    public GameObject typingSound4;


    private AudioSource tSound1;
    private AudioSource tSound2;
    private AudioSource tSound3;
    private AudioSource tSound4;
    //____________________________________________________________________________________________________



    public bool launched;
    public bool isCurrentLineChanged = false;
    public bool holdCurrent;

    public bool isTyping = false;
    public bool cancelTyping = false;
    public float typeSpeed;

    public bool _stopPlayerMovement;
    public bool _isActive;
    public GameObject _textBox;

    CharacterControl player;
    public Text _theText;

    public TextAsset _textFile;
    public string[] _textLines;

    public int _currentLine;
    public int _endAtLine;
    private int _oldCurrentLine;


	// Use this for initialization
	void Start () {

        tSound1 = typingSound1.GetComponent<AudioSource>();
        tSound2 = typingSound2.GetComponent<AudioSource>();
        tSound3 = typingSound3.GetComponent<AudioSource>();
        tSound4 = typingSound4.GetComponent<AudioSource>();


        holdCurrent = false;
        isCurrentLineChanged = false; 

        player = FindObjectOfType<CharacterControl>();


        _theText.text = "";
        _oldCurrentLine = _currentLine;
        if (_textFile != null)
        {
            _textLines =_textFile.text.Split('\n');

        }
        if (_endAtLine == 0)
        {
            _endAtLine = _textLines.Length - 1;
        }
        if (!_isActive)
            DisableTextBox();
        else
            EnableTextBox();


        
    }

    // Update is called once per frame
    void Update ()
    {
        
        if (!_isActive) return;

        if (isCurrentLineChanged)
        {
            StartCoroutine(TextScroll(_textLines[_currentLine]));
            isCurrentLineChanged = false;
        }
            

        //_theText.text = _textLines[_currentLine];

        //if (isCurrentLineChanged)
        //{
        //    if (isTyping)
        //    {
        //    //if (!holdCurrent)
        //    //    _currentLine++;

        //        //if (holdCurrent) return;
        //        //_currentLine++;

        //    if (_currentLine > _endAtLine)
        //    {
        //        DisableTextBox();
        //    }
        //    else
        //    {
        //        StartCoroutine(TextScroll(_textLines[_currentLine]));
        //    }

        //    isCurrentLineChanged = false;


        //    }
        //    //else if (isTyping && !cancelTyping)
        //    //{
        //    //    cancelTyping = true;
        //    //}

        //}
        if (Input.GetKeyDown(KeyCode.DownArrow) && !launched)
        {
            if (!isTyping)
            {
                if (!holdCurrent)
                    _currentLine++;
               //if (holdCurrent) return;

                //_currentLine++;

                if (_currentLine > _endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(_textLines[_currentLine]));
                }

                

            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }

        }

    }

    private IEnumerator TextScroll(string lineOfText)
    {
        if (holdCurrent && _theText.text != "")
        {
            _theText.text = lineOfText;
            isTyping = false;
            cancelTyping = false;
        }
        else
        {
            int letter = 0;
            _theText.text = "";
            isTyping = true;
            cancelTyping = false;
            while (isTyping && !cancelTyping && letter < lineOfText.Length - 1)
            {
                if (lineOfText[letter] == ' ')
                {
                    
                    _theText.text += lineOfText[letter];
                    letter++;
                }
                else
                {


                    if (letter % 2 == 0)
                    {
                        float x = Random.Range(0, 4);
                        if (x == 0)
                            tSound1.PlayOneShot(tSound1.clip);
                        if (x == 1)
                            tSound2.PlayOneShot(tSound2.clip);
                        if (x == 2)
                            tSound3.PlayOneShot(tSound3.clip);
                        if (x == 3)
                            tSound4.PlayOneShot(tSound4.clip);
                    }
                        
                        
                    _theText.text += lineOfText[letter];
                    letter++;
                    yield return new WaitForSeconds(typeSpeed);
                }
                


            }
            _theText.text = lineOfText;
            isTyping = false;
            cancelTyping = false;
        launched = false;
       }


    }
    

    public void EnableTextBox()
    {
        
        _textBox.SetActive(true);
        if (_stopPlayerMovement)
        {
            player.canMove = false;
        }
        StartCoroutine(TextScroll(_textLines[_currentLine]));
        _isActive = true;
    }

    public void DisableTextBox()
    {
        _isActive = false;
        _textBox.SetActive(false);
        player.canMove = true;
    }

    public void ReloadScript(TextAsset _theText)
    {
        if (_theText != null)
        {
            _textLines = new string[1];
            _textLines = _theText.text.Split('\n');
        }
    }

    
        
    

     
}
