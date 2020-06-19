using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filler : MonoBehaviour
{
    Transform parent;
    [SerializeField]
    float boundary = 0.7f;

    private void OnEnable()
    {
        parent = transform.parent;
    } 


    void Update()
    {
        float a = Mathf.Clamp01((parent.position.z + parent.lossyScale.z * 0.5f - boundary) / parent.lossyScale.z) * 0.875f;
        transform.localScale = new Vector3(a, 1, 1);
    }
}
