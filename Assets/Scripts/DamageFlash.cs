using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    SkinnedMeshRenderer meshrenderer;
    Color originalColor;

    private void Awake()
    {
        meshrenderer = GetComponent<SkinnedMeshRenderer>();
        originalColor = meshrenderer.material.color;
    }

    public void DamageFlashStart()
    {
        meshrenderer.material.color = Color.red;
        Invoke("DamageFlashStop", 0.1f);
    }

    void DamageFlashStop()
    {
        meshrenderer.material.color = originalColor;
    }
}
