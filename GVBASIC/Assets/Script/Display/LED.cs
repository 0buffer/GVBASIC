﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// LED screen emulator 
/// </summary>
public class LED : MonoBehaviour 
{
    public SpriteRenderer m_spriteRender;
    public Color m_whiteColor;
    public Color m_blackColor;

    protected Texture2D m_texture;
    protected Dictionary<int,ASCII> m_asciis;
    protected Color[] m_cleanColorData;

	// Use this for initialization
	void Start () 
    {
        m_texture = m_spriteRender.sprite.texture;

        // set clean color data 
        m_cleanColorData = new Color[12800];
        for (int i = 0; i < 12800; i++)
        {
            m_cleanColorData[i] = m_whiteColor;
        }

        initASCIITable();
        
        CleanScreen();
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_texture.Apply();
	}

    /// <summary>
    /// set pixel 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="set"></param>
    public void SetPixel( int x, int y, bool set )
    {
        m_texture.SetPixel(x, y, set ? m_blackColor : m_whiteColor);
    }

    /// <summary>
    /// draw letter 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="ascii"></param>
    public void DrawLetter( int x, int y, int ascii, bool reverse )
    {
        if( reverse )
        {
            m_texture.SetPixels(x, y, ASCII.WIDTH, ASCII.HEIGHT, m_asciis[ascii].m_reverseColor);
        }
        else
        {
            m_texture.SetPixels(x, y, ASCII.WIDTH, ASCII.HEIGHT, m_asciis[ascii].m_color);
        }
    }

    /// <summary>
    /// clean screen 
    /// </summary>
    public void CleanScreen()
    {
        m_texture.SetPixels(m_cleanColorData);
    }


    //--------------------- private functions ---------------------- 

    /// <summary>
    /// initial the ASCII table 
    /// </summary>
    protected void initASCIITable()
    {
        m_asciis = new Dictionary<int, ASCII>();

        // initial the ASCII code 
        for( int i = 0; i < 128; i++ )
        {
            ASCII ascii = new ASCII(i, m_whiteColor, m_blackColor);
            m_asciis[i] = ascii;
        }
    }

}
