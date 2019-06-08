using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject go_DialogueBar;
    [SerializeField] private GameObject dial;

    //[SerializeField] GameObject go_DialogueNameBar;
    private DialogueManager theDM;

    //public GameObject namebar;
    public GameObject bar;

    [SerializeField] private Camera cam;
    [SerializeField] private bool isProgress = false;
    private RaycastHit hitInfo;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Text txt_Name;
    private bool isDialogue = false;
    private Dialogue[] dialogues;
    private bool isNext = false;

    [SerializeField] private float textDelay;

    private int lineCount;
    private int contextCount = 0;

    private void Awake()
    {
        // namebar.SetActive(false);
        bar.SetActive(false);
    }

    private void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        CheckObject();
        if (isDialogue)
        {
            if (isNext)
            {
                if (isProgress)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        isNext = false;
                        txt_Dialogue.text = "";
                        txt_Name.text = "";
                        if (++contextCount < dialogues[lineCount].contexts.Length)
                        {
                            StartCoroutine(txtNext());
                        }
                        else
                        {
                            contextCount = 0;
                            if (++lineCount < dialogues.Length)
                            {
                                StartCoroutine(txtNext());
                            }
                            else
                            {
                                EndDialogue();
                            }
                        }
                    }
                }
            }
        }
    }

    private void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null; ;
        isNext = false;
        isProgress = false;
        //SettingUI(false);
    }

    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = p_dialogues;
        StartCoroutine(txtNext());
    }

    private IEnumerator txtNext()
    {
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ",");
        txt_Name.text = dialogues[lineCount].name;
        for (int i = 0; i < t_ReplaceText.Length; i++)
        {
            txt_Dialogue.text += t_ReplaceText[i];
            yield return new WaitForSeconds(textDelay);
        }
        isNext = true;
    }

    private void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        //go_DialogueNameBar.SetActive(p_flag);
    }

    private void Interact()
    {
        // namebar.SetActive(true);
        bar.SetActive(true);
        theDM.ShowDialogue(hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue());
    }

    private void CheckObject()
    {
        Vector3 t_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        if (Physics.Raycast(cam.ScreenPointToRay(t_MousePos), out hitInfo, 100))
        {
            ClickLeftButton();
        }
    }

    private void ClickLeftButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("클릭1");
            if (!isProgress)
            {
                //Debug.Log("클릭2");
                if (hitInfo.transform.CompareTag("Player"))
                {
                    Interact();
                }
                isProgress = true;
            }
        }
    }

    public IEnumerable WatodCoroutine()
    {
        Debug.Log("코루틴 실행");
        theDM.ShowDialogue(hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue());
        yield return null;
    }
}