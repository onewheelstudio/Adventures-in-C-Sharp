using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOverload : MonoBehaviour
{
    [Range(1,1000)]
    public int raycasts = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < raycasts; i++)
        {
            Ray ray = new Ray(this.transform.position, this.transform.forward);
            Raycast(ray, out RaycastHit hit, Physics.DefaultRaycastLayers, 1000, true);
        }
    }

    public bool Raycast(Ray ray, out RaycastHit hit, LayerMask layerMask, float distance, bool debug = false)
    {
        if(debug)
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        return Physics.Raycast(ray, out hit, distance, layerMask);
    }
}
