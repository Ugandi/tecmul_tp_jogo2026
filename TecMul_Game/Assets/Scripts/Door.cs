using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    public bool isOpen = false;
    public string requiredKeyID = "door_01_key";
    public TextMeshProUGUI lockedMessage;
    public float openAngle = 90f;

    private Coroutine hideCoroutine;

    public void TryOpen()
    {
        if (isLocked)
        {
            ShowMessage("Locked");
        }
        else
        {
            if (isOpen)
                StartCoroutine(DoorAnimation(openAngle, 0f));
            else
                StartCoroutine(DoorAnimation(0f, openAngle));

            isOpen = !isOpen;
        }
    }

    public void Unlock()
    {
        isLocked = false;
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

    private System.Collections.IEnumerator DoorAnimation(float fromAngle, float toAngle)
    {
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, toAngle - fromAngle, 0);
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, elapsed / duration);
            yield return null;
        }

        transform.localRotation = endRotation;
    }
}