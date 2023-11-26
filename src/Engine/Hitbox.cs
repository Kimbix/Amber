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
    
    // Returns a vector 2 with 2 possible values: 0 for no collision and 1 for collision on that axis
    public Vector2 CollisionAxis(Hitbox hitbox)
    {
        bool TouchingX = (hitbox.Position.X >= this.Position.X && hitbox.Position.X <= this.Width) ||
                         (hitbox.Width >= this.Position.X && hitbox.Width <= this.Width);
        bool TouchingY = (hitbox.Position.Y >= this.Position.Y && hitbox.Position.Y <= this.Height) ||
                         (hitbox.Height >= this.Position.Y && hitbox.Height <= this.Height);

        Vector2 vector = new Vector2(0.0f, 0.0f);
        if (TouchingX) vector.X = 1.0f;
        if (TouchingY) vector.Y = 1.0f;

        return vector;
    }
}