using System.Diagnostics.Metrics;
using Microsoft.Xna.Framework;
using Amber.Engine;

namespace Amber;

public class Player : Entity
{
    private bool Alive = true;
    private bool Jumping = false;
    private bool Dashing = false;
    
    public void Move(Vector2 newPosition)
    {
        this.Position = newPosition;
    }
    
    // Same as Move. Hopefully the compiler will optimize this thing
    public void SetPosition(Vector2 newPosition)
    {
        Move(newPosition);
    }
    
    public void SetVelocity(Vector2 newVelocity)
    {
        this.Velocity = newVelocity;
    }

    public void SetAcceleration(Vector2 newAcceleration)
    {
        this.Acceleration = newAcceleration;
    }
    
    // Called whenever the player collides with another entity
    public void OnPlayerCollision(Entity entity)
    {
        
    }
    
    // Getter for Alive
    public bool IsAlive()
    {
        return Alive;
    }
    
    // Called to trigger the player's death animation
    public void Die()
    {
        // Play sprite animation for death
        Alive = false;
    }
}