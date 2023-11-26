using Microsoft.Xna.Framework;

namespace Amber.Engine;

public class Hitbox
{
    public Vector2 Position;
    public int Width, Height;
    
    // Returns true if another hitbox is intersecting this one
    public bool IsTouching(Hitbox hitbox)
    {
        return (hitbox.Position.X >= this.Position.X && hitbox.Position.X <= this.Width) || 
               (hitbox.Width >= this.Position.X && hitbox.Width <= this.Width) ||
               (hitbox.Position.Y >= this.Position.Y && hitbox.Position.Y <= this.Height) ||
               (hitbox.Height >= this.Position.Y && hitbox.Height <= this.Height);
    }
}