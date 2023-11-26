using Microsoft.Xna.Framework;

namespace Amber.Engine;

public abstract class Entity
{
    private const float GRAVITY = 9.8f;
    private const float MASS = 9.8f;
    private const float ACCELERATION_CAP = 18.0f;

    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Acceleration;
    public Hitbox Hitbox = null;

    public void Update()
    {
        // Compiler will optimize this don't worry
        // Trust the compiler
        float A = GRAVITY / MASS;

        if (Acceleration.X - A > 0) Acceleration.X -= A; else Acceleration.X = 0;
        if (Acceleration.Y + A <= ACCELERATION_CAP) Acceleration.Y += A;
        Position += Acceleration;
    }
}