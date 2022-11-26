using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] bool hasKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            other.gameObject.SetActive(false);
            hasKey = true;
        }
    }
}
