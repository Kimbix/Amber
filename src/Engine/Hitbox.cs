namespace Amber.Hitbox;

public class Hitbox
{
    public int Width, Height;
    public int XPos, YPos;
    
    // Returns true if another hitbox is intersecting this one
    bool IsTouching(Hitbox hitbox)
    {
        return (hitbox.XPos >= this.XPos && hitbox.XPos <= this.Width) || 
               (hitbox.Width >= this.XPos && hitbox.Width <= this.Width) ||
               (hitbox.YPos >= this.YPos && hitbox.YPos <= this.Height) ||
               (hitbox.Height >= this.YPos && hitbox.Height <= this.Height);
    }
}