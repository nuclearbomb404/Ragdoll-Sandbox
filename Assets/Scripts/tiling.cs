using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiling : MonoBehaviour
 {
     [SerializeField] private float tileX = 10;
     [SerializeField] private float tileY = 10;
     Mesh mesh;
     private Material mat;
     void Start()
     {
         mat = GetComponent<MeshRenderer>().material;
         mesh = GetComponent<MeshFilter>().mesh;
         
     }
 
     void Update()
     {
         mat.mainTextureScale = new Vector2((mesh.bounds.size.x * 
        transform.localScale.x)/100*tileX, (mesh.bounds.size.y * transform.localScale.y)/100*tileY);
     }
 }

