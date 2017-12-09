using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void playSfx1()
    {
        AudioManager.instance.playSFX1();
    }

    public void playSfx2()
    {
        AudioManager.instance.playSFX2();
    }

    public void playTheme()
    {
        AudioManager.instance.PlayTheme();
    }
	public void playSlashattack1()
	{
		AudioManager.instance.soundfx(3, .5f);
	}
	public void playSlashattack2()
	{
		AudioManager.instance.soundfx(4,.5f);
	}
	public void playGunFire()
	{
		AudioManager.instance.soundfx(5,.3f);
	}
	public void playDash()
	{
		AudioManager.instance.soundfx(6,.4f);
	}
	public void playDamagedSound()
	{
		AudioManager.instance.soundfx(7,.8f);
	}
	public void playJump()
	{
		AudioManager.instance.soundfx(8,.5f);
	}
	public void playWalk()
	{
		AudioManager.instance.soundfx(9,.6f);
	}

}
