using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float range = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range))
            {
                Door door = hit.collider.GetComponent<Door>();

                if (door != null)
                {
                    door.Interact();
                }
            }
        }
    }
}
