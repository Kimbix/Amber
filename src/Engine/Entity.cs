using Microsoft.Xna.Framework;

namespace Amber.Engine;

public abstract class Entity
{
    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Acceleration;
    public Hitbox Hitbox = null;
}