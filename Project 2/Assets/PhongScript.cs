using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhongScript : MonoBehaviour {

    public PointLight pointLight;
    public Shader shader;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

        // Pass updated light positions to shader
        renderer.material.SetColor("_PointLightColor", this.pointLight.color);
        renderer.material.SetVector("_PointLightPosition", this.pointLight.GetWorldPosition());
    }
}
