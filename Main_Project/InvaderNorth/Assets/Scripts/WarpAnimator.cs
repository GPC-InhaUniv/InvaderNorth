using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpAnimator : MonoBehaviour {

    private Vector2[] UVOffsets;
    private int currArrayPos;
    private float interval = 0.03f;
    private const int FramePerSecond = 60;

    public MeshRenderer rend;

    private void Start()
    {
        UVOffsets = new Vector2[60];
        for (int i = 0; i < FramePerSecond; i++)
        {
            UVOffsets[i].x = (i % 5) * 0.2f;
            UVOffsets[i].y = 1f - (((i / 5) + 1f) / 12f);
        }
        rend = GetComponent<MeshRenderer>();
        InvokeRepeating("NextRendering", 0, interval);
    }

    private void NextRendering()
    {
        currArrayPos++;
        if(currArrayPos > UVOffsets.Length - 1)
        {
            currArrayPos = 0;
        }

        rend.material.SetTextureOffset("_MainTex", UVOffsets[currArrayPos]);
    }

}
