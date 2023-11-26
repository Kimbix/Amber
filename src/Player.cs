using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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

    private void Loop()
    {
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
        {
            Position.Y -= Acceleration.Y;
        }

        if(kstate.IsKeyDown(Keys.Down))
        {
            Position.Y += Acceleration.Y;
        }

        if (kstate.IsKeyDown(Keys.Left))
        {
            Position.X -= Acceleration.X;
        }

        if(kstate.IsKeyDown(Keys.Right))
        {
            Position.X += Acceleration.X;
        }
    }
}