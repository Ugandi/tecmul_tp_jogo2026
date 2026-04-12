using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    public bool isOpen = false;

    public float openAngle = 90f;
    public float speed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * speed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * speed);
        }
    }

    public void Interact()
    {
        if (isLocked)
        {
            Debug.Log("A porta está trancada!");
            return;
        }

        isOpen = !isOpen;
    }

    public void Unlock()
    {
        isLocked = false;
    }
}