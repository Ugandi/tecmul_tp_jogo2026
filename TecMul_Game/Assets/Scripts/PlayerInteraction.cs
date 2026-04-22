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
    
    // Mostra no Scene view para onde o ray está a apontar
    Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red, 2f);

    if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer))
    {
        Debug.Log("Acertou em: " + hit.collider.gameObject.name);

        if (hit.collider.TryGetComponent<Door>(out Door door))
        {
            door.TryOpen();
        }

        if (hit.collider.TryGetComponent<Key>(out Key key))
        {
            Door[] allDoors = FindObjectsByType<Door>(FindObjectsSortMode.None);
            foreach (Door targetDoor in allDoors)
            {
                if (targetDoor.requiredKeyID == key.keyID)
                {
                    key.Pickup(targetDoor);
                    break;
                }
            }
        }
    }
    else
    {
        Debug.Log("Raycast não acertou em nada");
    }
}
}
