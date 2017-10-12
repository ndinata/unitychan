/* Source code : Tutorial Week 4*/

using UnityEngine;
using System.Collections;

public class PointLight : MonoBehaviour {

    public Color color;

    //Function to get the position
    public Vector3 GetWorldPosition()
    {
        return this.transform.position;
    }
}
