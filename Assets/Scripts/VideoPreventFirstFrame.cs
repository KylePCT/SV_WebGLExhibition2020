using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//Prevents the first frame of a video being interrupted by the graphics buffer of the previously played video.
//i.e. stops the last video's last frame from appearing initially on the new video.
public class VideoPreventFirstFrame : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer videoplayer; //Find the video player.
    public Color defaultFrameColour = new Color32(23, 36, 48, 255); //A customisable colour the user can set to display instead of an image. It defaults as the L3Harris blue. 
    public Texture2D videoFirstFrameStill = null; //The picture to be shown on the first frame of the video instead of the existing buffer.

    //When the asset is awakened...
    void Awake()
    {
        //Get the video player component and re-set the colour.
        videoplayer = GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
        defaultFrameColour = new Color32(23, 36, 48, 255);

        //Set the active render texture to the targetTexture of the player.
        RenderTexture.active = videoplayer.targetTexture;
        //Clear the graphics buffer and set the background to the selected colour.
        GL.Clear(true, true, defaultFrameColour);
        //Remove the last render texture.
        RenderTexture.active = null;

        //If there is an image to be added instead of a colour...
        if (videoFirstFrameStill != null)
        {
            //Copy the source texture into the destination render texture using a shader and then draws a full-screen quad. More informationn at https://docs.unity3d.com/ScriptReference/Graphics.Blit.html.
            Graphics.Blit(videoFirstFrameStill, videoplayer.targetTexture);
        }
    }
}
