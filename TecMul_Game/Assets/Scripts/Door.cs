using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    public string requiredKeyID = "door_01_key"; // ID único por porta
    public TextMeshProUGUI lockedMessage;         // Arrasta o texto UI aqui

    private Coroutine hideCoroutine;

    public void TryOpen()
    {
        if (isLocked)
        {
            ShowMessage("Locked");
        }
        else
        {
            Open();
        }
    }

    public void Unlock()
    {
        isLocked = false;
    }

    private void Open()
    {
        
    }

    private void ShowMessage(string message)
    {
        if (hideCoroutine != null) StopCoroutine(hideCoroutine);
        lockedMessage.text = message;
        lockedMessage.gameObject.SetActive(true);
        hideCoroutine = StartCoroutine(HideAfterDelay(2f));
    }

    private System.Collections.IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        lockedMessage.gameObject.SetActive(false);
    }
}