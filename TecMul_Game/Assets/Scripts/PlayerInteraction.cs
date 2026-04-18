using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float range = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f))
            {
                Door door = hit.collider.GetComponentInParent<Door>();

                if (door != null)
                {
                    door.Interact();
                }
            }

        }
    }
}
