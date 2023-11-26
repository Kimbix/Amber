using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Amber.Engine;

public class Texture
{
    private Texture2D _texture;
    private Rectangle _sourceRectangle;
    
    void LoadTexture(ContentManager content, int columns, int rows, string path)
    {
        _texture = content.Load<Texture2D>(path);
        _sourceRectangle.Height = _texture.Height / rows;
        _sourceRectangle.Width = _texture.Width / columns;
        _sourceRectangle.X = 0;
        _sourceRectangle.Y = 0;
    }

    void ChangeSourceRectangle(int x, int y)
    {
        _sourceRectangle.X = x;
        _sourceRectangle.Y = y;
    }

    void DrawTexture(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(
            texture: _texture,
            position: position,
            sourceRectangle: _sourceRectangle,
            color: Color.White
            );
    }
}