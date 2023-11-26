using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Amber.Engine;

public static class TextureManager
{
    private static readonly Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

    public static void LoadTexture(ContentManager content, string path, string textureName)
    {
        // Error Checking
        if (content == null) { throw new ArgumentException("Content cannot be null", nameof(content)); }
        if (textureName == "") { throw new ArgumentException("Name cannot be empty", nameof(textureName)); }
        
        // Creating Texture2D
        var texture = content.Load<Texture2D>(path);

        // Add to Dictionary
        Textures.Add(textureName, texture);
    }

    public static Texture2D GetTexture(string textureName) { return Textures[textureName]; }
}

public class Sprite
{
    private static Texture2D _texture;
    private Rectangle _sourceRectangle;
    
    // First integer specifies the row
    // Second integer specifies the number of columns
    private int _currentAnimation;
    private readonly Dictionary<int, int> _animations = new Dictionary<int, int>();
    private readonly int _rows, _columns;
    private readonly int _sizeX, _sizeY;

    public Sprite(Texture2D texture, int rows, int columns)
    {
        if (rows < 1) { throw new ArgumentException("Rows cannot be under 1", nameof(rows)); }
        if (columns < 1) { throw new ArgumentException("Columns cannot be under 1", nameof(columns)); }
        _texture = texture ?? throw new ArgumentException("Texture cannot be null", nameof(texture));
        _rows = rows;
        _columns = columns;
        _sizeY = _texture.Height / _rows;
        _sizeX = _texture.Width / _columns;
        _sourceRectangle.Height = _sizeY;
        _sourceRectangle.Width = _sizeX;
        _sourceRectangle.X = 0;
        _sourceRectangle.Y = 0;
    }

    public void RegisterAnimation(int row, int frames)
    {
        if (frames < 0 || frames > _columns) { throw new IndexOutOfRangeException("Frames number out of range"); }
        if (row < 0 || row > _rows) { throw new IndexOutOfRangeException("Row number out of range"); }
        _animations.Add(row, frames);
    }

    public void SelectAnimation(int row)
    {
        if (row < 0 || row > _rows) { throw new IndexOutOfRangeException("Row number out of range"); }
        _currentAnimation = row;
        _sourceRectangle.X = 0;
        _sourceRectangle.Y = _sizeY * row;
    }

    public void MoveFrame(int amount)
    {
        _sourceRectangle.X = (_sourceRectangle.X + _sizeX * amount) % (_sizeX * _animations[_currentAnimation]);
    }
    
    public void DrawTexture(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(
            texture: _texture,
            position: position,
            sourceRectangle: _sourceRectangle,
            color: Color.White
            );
    }
}