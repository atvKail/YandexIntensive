using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public void SetMaterialChild(Material material) 
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Renderer _renderer = transform.GetChild(i).GetComponent<Renderer>();
            _renderer.material = material;
        }
    }

}
