using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Inscribed")]
    public float rotationsPerSecond = 0.1f;

    [Header("Dynamic")]
    public int levelShown = 0;

    //A Non-public variable that cannot be seen in the inspector
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;    
    }

    // Update is called once per frame
    void Update()
    {
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);

        if(levelShown != currLevel)
        {
            levelShown = currLevel;
            //Adjust the texture offset to show different shield levels
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }
        //rotate the shield a bit every frame
        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
