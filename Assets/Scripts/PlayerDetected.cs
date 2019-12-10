using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
TODO: break down this script as it does too much. Probably can be written
         into 3 scripts.
*/
public class PlayerDetected : MonoBehaviour {
  // original property values
  private float originalPitch = 1f;
  private float originalVolume = 0.069f;

  // creepy property values
  private float creepyVolume = .25f;
  private float creepyPitch = 3f;

  // AudioSource background_music;
  private AudioSource background_music;

  // Creepy Image
  public RawImage creepyImage;
  private bool isImgOff;

  // grabs the raw image object in the scene and disables it
  void Awake() {
    creepyImage = GameObject.FindWithTag("canva").GetComponentInChildren<RawImage>();
    if(creepyImage){
      isImgOff = true;
      creepyImage.enabled = false;
    } else {
      return;
      // Debug.Log("Image not found");
    }
  }

  void OnTriggerEnter(Collider c){
    // parsing through collider data for targeted components
    background_music = c.gameObject.GetComponentInChildren<AudioSource>();

    // detects if player passes through trigger/ collider
    if(c.tag == "Player"){
      // change background_music properties
      background_music.volume = creepyVolume;
      background_music.pitch = creepyPitch;

      // make creepy image appear
      if(isImgOff){
        creepyImage.enabled = true;
        isImgOff = false;
      }
    // crappy error handler.
    } else {
      return;
      // Debug.Log("ERROR: Player was not successfully detected.");
    }
  }

  // should still have the background_music from when player entered
  void OnTriggerExit(Collider c){
    // reverts background_music to original propterties
    background_music.volume = originalVolume;
    background_music.pitch = originalPitch;

    // disables creepy Image
    creepyImage.enabled = false;
    isImgOff = true;
  }
}
