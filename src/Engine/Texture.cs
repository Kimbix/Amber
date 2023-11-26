using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Amber.Engine;

public class Texture
{
    private Texture2D texture;
    private Rectangle source_rectangle; 

    void DrawTexture(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(
            position: position,
            sourceRectangle: source_rectangle,
            color: Color.White
            );
    }
}