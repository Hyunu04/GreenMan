using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private DialogueManager theDM;

    //public GameObject namebar;
    public GameObject bar;

    [SerializeField] private Camera cam;
    [SerializeField] private bool isProgress = false;
    private RaycastHit hitInfo;
    // Start is called before the first frame update

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