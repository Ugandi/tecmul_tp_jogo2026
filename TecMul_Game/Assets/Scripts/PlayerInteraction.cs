using System.Diagnostics;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer))
        {
            Door door = hit.collider.GetComponentInParent<Door>();
            if (door != null)
            {
                door.TryOpen();
            }

            if (hit.collider.TryGetComponent<Key>(out Key key))
            {
                Door[] allDoors = FindObjectsByType<Door>(FindObjectsSortMode.None);
                foreach (Door targetDoor in allDoors) // "door" renomeado para "targetDoor"
                {
                    if (targetDoor.requiredKeyID == key.keyID)
                    {
                        key.Pickup(targetDoor);
                        break;
                    }
                }
            }
        }
    }
}
