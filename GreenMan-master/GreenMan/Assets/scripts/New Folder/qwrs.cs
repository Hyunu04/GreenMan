using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qwrs : MonoBehaviour
{
    public Dialogue[] Parse(string csv_Filename)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();

        TextAsset csvData = Resources.Load(csv_Filename) as TextAsset;

        string[] data = csvData.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Dialogue dialogue = new Dialogue();

            dialogue.name = row[1];// 문제점!!!!!!!!!!!!!!!
            Debug.Log(row[1]);
            List<string> contextlist = new List<string>();

            do
            {
                contextlist.Add(row[2]);
                Debug.Log(row[2]);
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }
            } while (row[0].ToString() == "");

            dialogue.contexts = contextlist.ToArray();

            dialogueList.Add(dialogue);
        }
        return dialogueList.ToArray();
    }
    void Start()
    {
        Parse("qwerty");
    }
}

    // Update is called once per frame
  
