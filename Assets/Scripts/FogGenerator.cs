using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGenerator : MonoBehaviour {
    private const float EXP = 2.71f;
    private Vector3 center = Vector3.zero;
    [SerializeField]
    private float Rad = 20f;
    [SerializeField]
    private float EndRad = 100f;
    [SerializeField]
    private GameObject FogPanel;
    [SerializeField] 
    private int CountPlane=10;
    [SerializeField]
    private int CountA=6;
    [SerializeField]
    private float factor=1.5f;
    [SerializeField]
    private Color ColorFog = Color.white;


    public void StartUp() {
        for (float j = 0; j < CountA; j++)
        {
            float angle = j * (360f / CountA);
            for (int i = 0; i < CountPlane; i++)
            {
                float multi = ((float)i) / CountPlane;
                float curHeight = (Rad + (EndRad - Rad) * multi) * Mathf.Cos((Mathf.PI / 180f) * (360f / CountA) / 2);
                float x = curHeight * Mathf.Sin((Mathf.PI / 180f) * angle);
                float z = curHeight * Mathf.Cos((Mathf.PI / 180f) * angle);
                Quaternion q = Quaternion.Euler(-90, angle, 0);
                float SizeX = 2 * curHeight * Mathf.Tan((Mathf.PI / 180f) * (360f / CountA) / 2) / 10f;
                Vector3 newPositon = new Vector3(x, center.y, z);
                GameObject panel = Instantiate(FogPanel, newPositon, q);
                panel.transform.localScale = new Vector3(SizeX, 1, 3);
                Renderer rend = panel.GetComponent<Renderer>();
                Color c = ColorFog;
                rend.material.SetColor("_EmissionColor", ColorFog);
                c.a = Mathf.Pow(factor, i/(float)CountPlane)-1f;
                //c.a = 1 - 1f / Mathf.Pow(FogGenerator.EXP, factor * ( Mathf.Abs((newPositon - center).magnitude - Rad)));
                rend.material.color = c;
               
            }
        }
    }

    public void SetCenter(Vector3 center) {
        this.center = center;
    }

    private void Start()
    {
    }
}
