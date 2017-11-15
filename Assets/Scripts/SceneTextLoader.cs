using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTextLoader : MonoBehaviour {


    float timer;
    public string TextToLoad;
    public float FadeInTime;
    public float StayTime;
    public float FadeOutTime;
    Text SceneText;
    float alpha = 0f;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
        SceneText = GameObject.FindWithTag("SceneText").GetComponent<Text>();
        SceneText.text = TextToLoad;
        SceneText.material.color = new Color(SceneText.material.color.r, SceneText.material.color.g, SceneText.material.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < FadeInTime)
        {
            alpha += .007f;
            SceneText.material.color = new Color(SceneText.material.color.r, SceneText.material.color.g, SceneText.material.color.b, alpha);
        }
        else if (timer < FadeInTime + StayTime) { }
        else if (timer < FadeInTime + StayTime + FadeOutTime)
        {
            alpha -= .007f;
            SceneText.material.color = new Color(SceneText.material.color.r, SceneText.material.color.g, SceneText.material.color.b, alpha);
        }
        else
            SceneText.text = "";
    }
}
