using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
    public bool isReversed = true;

	// Update is called once per frame
	void Update () {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;
        
        Vector2 offset = mat.mainTextureOffset;

        if (!isReversed)
        {
            offset.x += Time.deltaTime / 25f;
            offset.y -= Time.deltaTime / 25f;
        }
        else
        {
            offset.x -= Time.deltaTime / 25f;
            offset.y += Time.deltaTime / 25f;
        }

        mat.mainTextureOffset = offset;
	}
}
