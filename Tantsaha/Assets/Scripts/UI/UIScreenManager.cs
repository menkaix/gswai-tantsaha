using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public enum DialogAnswer
{
	PENDING = 0,
	YES = 1,
	NO = 2,
	CANCEL = 3

}

public enum DialogType
{
	CANCEL,
	YES_NO,
	YES_NO_CANCEL
}

public delegate void DialogCallback(DialogAnswer userAnswer);


public class UIScreenManager : MonoBehaviour {

    private UIScreen[] screens;
    private int currentPage = 0;
    private ReadableStack<int> history = new ReadableStack<int>();
	private GameObject currentDialog = null ;

    public int defaultPage = 0;

	public UserDialog genericDialog;

	public Text title;
	public Text message;
	public Button yes;
	public Button no;
	public Button cancel;
	public Button outSide;

	// Use this for initialization
	void Start () {
        screens = gameObject.GetComponentsInChildren<UIScreen>();

        for(int i=0; i< screens.Length; i++)
        {
            screens[i].pageID = i;
            screens[i].pageNumbers = screens.Length;
        }

        EnableScreen(defaultPage);
        history.Add(defaultPage);
        
	}
	
	// Update is called once per frame
	void Update () {
        	
	}
	public void EnableScreen(int i)
    {
        if(i<0 || i >= screens.Length)
        {
            return;
        }

		if (history.Count > 0)
		{
			if(history[history.Count - 1] == i)
			{
				HistoryBack();
				return;
			}
		}


        history.Add(currentPage);

        for(int j = 0; j<screens.Length ; j++)
        {
            if (i == j)
            {
                screens[i].gameObject.SetActive(true);
            }
            else
            {
                screens[j].gameObject.SetActive(false);
            }
        }

        currentPage = i;

    }

    public void EnableScreen(string s)
    {
        int i = -1;
        int j = -1;

        foreach (UIScreen scr in screens)
        {
            i++;

            if(scr.gameObject.name == s)
            {
                j = i;
            }
        }
        EnableScreen(j);
	}

	public void EnableScreen(UIScreen screen)
	{
		int i = -1;
		int j = -1;

		foreach (UIScreen scr in screens)
		{
			i++;

			if (scr.GetInstanceID()==screen.GetInstanceID())
			{
				j = i;
			}
		}
		EnableScreen(j);
	}

    public void HistoryBack()
    {
        int i = history.Depile();

        for (int j = 0; j < screens.Length; j++)
        {
            if (i == j)
            {
                screens[i].gameObject.SetActive(true);
            }
            else
            {
                screens[j].gameObject.SetActive(false);
            }
        }

        currentPage = i;
    }

    public void NextPage()
    {
        EnableScreen(currentPage + 1);
    }

    public void PreviousPage()
    {
        EnableScreen(currentPage - 1);
    }

    public void GoHome()
    {
        EnableScreen(defaultPage);
    }


	public bool ShowAsDialog(GameObject go)
	{
		if (currentDialog == null || !currentDialog.activeInHierarchy)
		{
			go.SetActive(true);
			return true;
		}
		else
		{
			return false;
		}
	}

	public void HideDialog()
	{
		if(currentDialog != null)
		{
			currentDialog.SetActive(false);
			currentDialog = null;
		}
		
	}

	public bool GenericDialog(DialogType type, string titleText, string messageText, DialogCallback callback)
	{
		if (currentDialog == null || !currentDialog.activeInHierarchy)
		{
			StartCoroutine(ShowGenericDialog(type, titleText, messageText, callback));
			return true;
		}
		else
		{
			return false;
 		}
		
	}

	public IEnumerator ShowGenericDialog(DialogType type, string titleText, string messageText, DialogCallback callback)
	{
		
		genericDialog.answer.value = DialogAnswer.PENDING;
		currentDialog = genericDialog.gameObject;
		
		switch (type)
		{
			case DialogType.CANCEL:
				cancel.gameObject.SetActive(true);
				yes.gameObject.SetActive(false);
				no.gameObject.SetActive(false);
				break;
			case DialogType.YES_NO:
				cancel.gameObject.SetActive(false);
				yes.gameObject.SetActive(true);
				no.gameObject.SetActive(true);
				break;
			case DialogType.YES_NO_CANCEL:
				cancel.gameObject.SetActive(true);
				yes.gameObject.SetActive(true);
				no.gameObject.SetActive(true);
				break;

		}

		title.text = titleText;
		message.text = messageText;

		genericDialog.gameObject.SetActive(true);

		while (genericDialog.answer.value == DialogAnswer.PENDING)
		{
			yield return genericDialog.answer.value;
			
		}

		callback(genericDialog.answer.value);

		genericDialog.gameObject.SetActive(false);

		currentDialog = null ;

	}
	
}
