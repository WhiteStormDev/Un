using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

    public string NpcName;

    public bool MonkeyX;

    private bool ACTIVATED;
    public bool isRus;
    public string PATH;
    DialogueGraph D;
	// Use this for initialization
	void Start () {
        D = FindObjectOfType<DialogueGraph>();
        D.currentNumNode = -1;
        MonkeyX = false;
        ACTIVATED = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (MonkeyX)
        {
            Debug.Log("Trigger checked");
            if (Input.GetKeyDown(KeyCode.E) && D.currentNumNode == -1)
            {
                ACTIVATED = true;
                D.isRus = isRus;
                //D.launched = true;
                D.currentNumNode = 0;
                D.ActivateDialog(PATH, NpcName);
            }
            if (Input.GetKeyDown(KeyCode.Q) && ACTIVATED)
            {
                D.DisableTextBox();
                ACTIVATED = false;
            }

        }
        //if (Input.GetKeyDown(KeyCode.E) && D.isTyping && !D.cancelTyping)
        //    D.cancelTyping = true;
        if (D.currentNumNode != -1 && !D.isTyping)
        {
            D.holdCurrent = true;
            if (D.nodes[D.currentNumNode].edgeInd.Length == 1)
            {
                if (Input.GetKeyDown(KeyCode.E) && !D.isTyping)
                {
                    D.holdCurrent = false;
                    D.currentNumNode = D.nodes[D.currentNumNode].edgeInd[0];
                    D.isCurrentNodeChanged = true;
                    D.cancelTyping = false;
                    D.isTyping = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    D.holdCurrent = false;
                    D.currentNumNode = D.nodes[D.currentNumNode].edgeInd[0];
                    D.isCurrentNodeChanged = true;
                    D.cancelTyping = false;
                    D.isTyping = true;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) && D.nodes[D.currentNumNode].edgeInd.Length > 1)
                {
                    D.holdCurrent = false;
                    D.currentNumNode = D.nodes[D.currentNumNode].edgeInd[1];
                    D.isCurrentNodeChanged = true;
                    D.cancelTyping = false;
                    D.isTyping = true;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3) && D.nodes[D.currentNumNode].edgeInd.Length > 2)
                {
                    D.holdCurrent = false;
                    D.currentNumNode = D.nodes[D.currentNumNode].edgeInd[2];
                    D.isCurrentNodeChanged = true;
                    D.cancelTyping = false;
                    D.isTyping = true;
                }
                if (Input.GetKeyDown(KeyCode.Alpha4) && D.nodes[D.currentNumNode].edgeInd.Length > 3)
                {
                    D.holdCurrent = false;
                    D.currentNumNode = D.nodes[D.currentNumNode].edgeInd[3];
                    D.isCurrentNodeChanged = true;
                    D.cancelTyping = false;
                    D.isTyping = true;
                }
                if (Input.GetKeyDown(KeyCode.Alpha5) && D.nodes[D.currentNumNode].edgeInd.Length > 4)
                {
                    D.holdCurrent = false;
                    D.currentNumNode = D.nodes[D.currentNumNode].edgeInd[4];
                    D.isCurrentNodeChanged = true;
                    D.cancelTyping = false;
                    D.isTyping = true;
                }
            }

        }
	}



    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
            MonkeyX = true;
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
            MonkeyX = false;
    }
    //void OnTriggerStay2D(Collider2D coll)
    //{
    //    Debug.Log("Trigger checked");
    //    if (coll.tag == "Player" && Input.GetKeyDown(KeyCode.E) && D.currentNumNode == -1)
    //    {

    //        D.isRus = isRus;
    //        D.launched = true;
    //        D.currentNumNode = 0;
    //        D.ActivateDialog(PATH, NpcName);
    //    }
    //}
    //void OnCollisionStay2D(Collision2D coll)
    //{
    //    Debug.Log("Trigger checked");
    //    if (Input.GetKeyDown(KeyCode.E) && D.currentNumNode == -1)
    //    {

    //        D.isRus = isRus;
    //        D.launched = true;
    //        D.currentNumNode = 0;
    //        D.ActivateDialog(PATH, NpcName);
    //    }
    //}
}
