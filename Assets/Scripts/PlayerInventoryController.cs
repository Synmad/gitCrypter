using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] bool hasKey;
    [SerializeField] Collider doorcollider;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Key" && (Input.GetKeyDown(KeyCode.E)))
        {
            Debug.Log("Agarrando llave");
            other.gameObject.SetActive(false);
            doorcollider.enabled = true;
        }
    }
}
