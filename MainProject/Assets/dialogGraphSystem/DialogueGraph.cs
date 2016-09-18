using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class DialogueGraph : MonoBehaviour {


    public string characterNpcName;
    //__________Совсем_обязательные_поля______________
    public Text uiText;
    public GameObject uiBox;

    //__________Обязательные_Поля_____________________
    public float typeSpeed;
    public bool isRus;
    public bool isActive;
    public int currentNumNode;

    //__________Костыльные_Поля_______________________
    public bool isCurrentNodeChanged;
    public bool isTyping;
    public bool holdCurrent;
    public bool cancelTyping;
    public bool launched;
    
    //__________Топорные_Поля_________________________
    Animator anim;
    CharacterControl player;
    AnimatorHelp animatorHelp;


    //__________Методы_вывода_диалога_________________
    void Start()
    {
        //launched = false;
        uiText = FindObjectOfType<Text>();
        uiText.supportRichText = true;
        anim = FindObjectOfType<Animator>();
        isCurrentNodeChanged = false;
        //uiText.supportRichText = true;
        holdCurrent = false;
        uiText.text = "";
        isActive = false;
        
    }
    void Update()
    {
        
        if (!isActive) return;
        //---------------------------------
        if (Input.GetKeyDown(KeyCode.Q) && !isTyping)
            DisableTextBox();
        //---------------------------------
        if (isCurrentNodeChanged)
        {
            PrintCurrent(currentNumNode);
            isCurrentNodeChanged = false;
        }
        //---------------------------------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping && !cancelTyping)
                cancelTyping = true;
        }
        

    }
    public void ActivateDialog(string PATH, string charNpcName)
    {
        animatorHelp = FindObjectOfType<AnimatorHelp>();
        uiBox.SetActive(true);
        animatorHelp.unTrue();
        characterNpcName = charNpcName;
        player = FindObjectOfType<CharacterControl>();
        player.canMove = false;
        Parser(PATH);
        isActive = true;
        
        
        
        PrintCurrent(currentNumNode);
    }
    void PrintCurrent(int NumNode)
    {
        string allText = "";
        uiText.text = "";
        Node curr = nodes[NumNode];
        if (curr.type == phraseType.player)
            allText = curr.type.ToString() + ": ";
        else allText = characterNpcName + ": ";
        if (curr.edgeInd.Length == 1)
        {
            if (isRus)
            {
                allText += curr.textRus;
                StartCoroutine(TextScroll(allText));
            }
            else
            {
                allText += curr.textEng;
                StartCoroutine(TextScroll(allText));
            }
        }
        if (curr.edgeInd.Length != 1)
        {
            if (isRus)
            {
               
                allText += curr.textRus + "\n";
                
                for (int i = 0; i < curr.edgeInd.Length; i++)
                {
                    int t = i + 1;
                    allText += " " + t + ". " + nodes[curr.edgeInd[i]].shortRus;
                }
                StartCoroutine(TextScroll(allText));
            }
            else
                if (!isRus)
            {
                allText += curr.textEng + "\n";

                for (int i = 0; i < curr.edgeInd.Length; i++)
                {
                    int t = i + 1;
                    allText += " " + t + ". " + nodes[curr.edgeInd[i]].shortEng;
                }
                StartCoroutine(TextScroll(allText));
            }

        }
    }
    private IEnumerator TextScroll(string lineOfText)
    {
        //if (holdCurrent && uiText.text != "")
        //{
        //    uiText.text = lineOfText;
        //    isTyping = false;
        //    cancelTyping = false;
        //}
        //else
        //{
            int letter = 0;
            uiText.text = "";
            isTyping = true;
            cancelTyping = false;
            while (isTyping && !cancelTyping && letter < lineOfText.Length - 1)
            {
                if (lineOfText[letter] == ' ')
                {

                    uiText.text += lineOfText[letter];
                    letter++;
                }
                else
                {


                    //if (letter % 2 == 0)
                    //{
                    //    float x = Random.Range(0, 4);
                    //    if (x == 0)
                    //        tSound1.PlayOneShot(tSound1.clip);
                    //    if (x == 1)
                    //        tSound2.PlayOneShot(tSound2.clip);
                    //    if (x == 2)
                    //        tSound3.PlayOneShot(tSound3.clip);
                    //    if (x == 3)
                    //        tSound4.PlayOneShot(tSound4.clip);
                    //}


                    uiText.text += lineOfText[letter];
                    letter++;
                    yield return new WaitForSeconds(typeSpeed);
                }



            }
            uiText.text = lineOfText;
            isTyping = false;
            cancelTyping = false;
            //launched = false;
        //}
    }
    public void DisableTextBox()
    {
        if (isTyping) return;
        cancelTyping = true;
        StartCoroutine(TextScroll(" "));
        uiText.text = " ";
        isActive = false;
        uiBox.SetActive(false);
        player.canMove = true;
        currentNumNode = -1;
    }




    public enum phraseType
    {
        player,
        npc
    }
    //_________________________GRAPH_________________________
    public Node[] nodes;
    public string[] lines;
    public class Node
    {
        public string shortRus;
        public string shortEng;
        public string textRus;
        public string textEng;
        public phraseType type;
        public int[] edgeInd;
        public int numNode;
        public Node(int numNode, string textRus, string textEng, string shortRus, string shortEng, phraseType type, int edgesLength)
        {
            this.shortEng = shortEng;
            this.shortRus = shortRus;
            this.numNode = numNode;
            this.textRus = textRus;
            this.textEng = textEng;
            this.type = type;
            edgeInd = new int[edgesLength];
            
        }
    }
    public void Print()
    {
        Debug.Log("Print start__" + nodes.Length);
        for (int i = 0; i < nodes.Length; i++)
        {
            Debug.Log("Printing...");
            string numEd = "";
            for (int z = 0; z < nodes[i].edgeInd.Length; z++)
                numEd += nodes[i].edgeInd[z].ToString()  + ',';

            Debug.Log("numNode: " + nodes[i].numNode + '|' + "phraseType: " + nodes[i].type + '|' + "Rus: " + nodes[i].textRus + '/' + "Eng: " + nodes[i].textEng + '|' + "shortRus: " + nodes[i].shortRus + '/' + "shortEng: " + nodes[i].shortEng + '|' + "Edges Ind: " + numEd + "\n");
        }
    }
    public void Parser(string path)
    {

        FileStream f = new FileStream(path, FileMode.Open);
        StreamReader fr = new StreamReader(f);
        string ans = fr.ReadToEnd();
        fr.Close();
        f.Close();
        //like that: nodeNum--> 1|N/P|rusText/engText|2,3,4| <-- edge indexes

        lines = ans.Split('\n');
        int L = lines.Length;
           
        nodes = new Node[L];
        int ind = 0;
            
        int nodeNum;

            Debug.Log("textAssetCheck");
        for (int i = 0; i < L; i++)
        {
            Debug.Log(lines[i]);
            phraseType t = new phraseType();
            string line = lines[i];
            //_________NodeNum____________
            ind = line.IndexOf('|');
            nodeNum = int.Parse(line.Substring(0, ind));

            int x = 0;
            while (line[x] != '|') x++;
            x++;
            //_______PhraseType_____________
            if (line[x] == 'N') t = phraseType.npc;
            else if (line[x] == 'P') t = phraseType.player;
            x++;
            x++;
            //_________Rus&Eng____________
            string Rus = "";
            string Eng = "";
            while (line[x] != '/')
            {
                Rus += line[x];
                x++;
            }
            x++;
            while (line[x] != '|')
            {
                Eng += line[x];
                x++;
            }
            x++;
            //_________shortRus&shortEng____________
            string shortRus = "";
            string shortEng = "";
            while (line[x] != '/')
            {
                shortRus += line[x];
                x++;
            }
            x++;
            while (line[x] != '|')
            {
                shortEng += line[x];
                x++;
            }
            x++;
            //__________endgeInd_____________
            string[] edgeid = line.Substring(x).Split(',');
            nodes[i] = new Node(nodeNum, Rus, Eng, shortRus, shortEng, t, edgeid.Length);
            for (int z = 0; z < edgeid.Length; z++)
            {
                nodes[i].edgeInd[z] = int.Parse(edgeid[z]);
            }
        }
        Print();
    }

}
