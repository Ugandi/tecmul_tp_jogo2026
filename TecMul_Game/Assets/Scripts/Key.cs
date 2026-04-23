using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyID = "door_01_key"; // Tem de coincidir com o da porta

    public void Pickup(Door targetDoor)
    {
        if (targetDoor.requiredKeyID == keyID)
        {
            targetDoor.Unlock();
            Destroy(gameObject);
        }
    }
}