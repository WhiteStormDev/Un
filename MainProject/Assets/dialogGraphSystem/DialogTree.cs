using UnityEngine;
using System.Collections;

public class DialogTree : MonoBehaviour {

    public TextAsset parseText;

    private string[] lines;
    public enum phraseType
    {
        player,
        npc
    }
    public void Parser()
    {
        if (parseText != null)
        {
            lines = parseText.text.Split('\n');
            //DialogueGraph.Parser0(lines);
        }
    }
    public class DialogueGraphtry
    {
        public Node[] nodes;
        public class Node
        {
            string textRus;
            string textEng;
            phraseType type;
            int[] edgeInd;
            public Node(string textRus, string textEng, phraseType type)
            {
                this.textRus = textRus;
                this.textEng = textEng;
                this.type = type;
                edgeInd = new int[0];
            }
        }
        
        public static void Parser0(string[] lines)
        {
            
        }

        
    }
    
    private class Phrase
    {
        phraseType type;

        //protected class playerPhrase : Phrase
        //{
        //    string 
        //    Phrase.npcPhrase _anser;
        //}

        //protected class npcPhrase : Phrase
        //{

        //}

        Phrase parent;
        Phrase[] children;
        string text;
        public Phrase(string text, phraseType type)
        {
            this.type = type;
            this.text = text;
            children = new Phrase[0];
        }

        void AddToArr(string str, phraseType type)
        {
            int l = children.Length;
            Phrase[] arr = new Phrase[children.Length + 1];
            for (int i = 0; i < l; i++)
                arr[i] = children[i];
            arr[l] = new Phrase(str, type);
        }
        


    }
}
    

