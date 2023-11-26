using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Amber.Engine;

public static class TextureManager
{
    private static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

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

    public Sprite(Texture2D texture, int rows, int columns)
    {
        if (rows < 1) { throw new ArgumentException("Rows cannot be under 1", nameof(rows)); }
        if (columns < 1) { throw new ArgumentException("Columns cannot be under 1", nameof(columns)); }
        _texture = texture ?? throw new ArgumentException("Texture cannot be null", nameof(texture));
        _sourceRectangle.Height = texture.Height / rows;
        _sourceRectangle.Width = texture.Width / columns;
        _sourceRectangle.X = 0;
        _sourceRectangle.Y = 0;
    }
    public void ChangeSourceRectangle(int x, int y)
    {
        _sourceRectangle.X = x;
        _sourceRectangle.Y = y;
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