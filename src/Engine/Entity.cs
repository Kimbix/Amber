using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Amber.Engine;

public class Entity
{
    private const float GRAVITY = 5.0f;
    private const float MASS = 10.0f;
    private const float ACCELERATION_CAP = 18.0f;

    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Acceleration;
    public Hitbox hitbox = null;
    public Sprite sprite;
    
    // this is temporal. Very much like our human existance
    public bool isRigid = false;
    
    // temporal for debugging
    public Entity testEntity = null;
    
    private void _Update(){}
    
    private void Loop(){}
    
    public void Update()
    {
        Loop();

        if (isRigid) return;
        
        // Compiler will optimize this don't worry
        // Trust the compiler
        float A = GRAVITY / MASS;

        // temp
        if (testEntity == null || testEntity.hitbox == null)
            return;
        
        // Holy shit this is horrible game jam vibe starting to set in
        if (hitbox.CollisionAxis(testEntity.hitbox).X == 0)
        {
            if (Acceleration.X - A > 0) Acceleration.X -= A;
        } else Acceleration.X = 0;

        if (hitbox.CollisionAxis(testEntity.hitbox).Y == 0)
        {
            if (Acceleration.Y + A <= ACCELERATION_CAP) Acceleration.Y += A;
        } else Acceleration.Y = 0;
        
        Position += Acceleration;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw texture
        sprite.DrawTexture(spriteBatch, Position);
    }
}

public class EntityManager
{
    private static readonly Dictionary<string, Entity> Entities = new Dictionary<string, Entity>();
    
    public static Entity NewEntity(string entityName)
    {
        return AddEntity(new Entity(), entityName);
    }

    public static Entity AddEntity(Entity entity, string entityName)
    {
        // Error Checking
        if (entityName == "") { throw new ArgumentException("Name cannot be empty", nameof(entityName)); }
        
        // Add to Dictionary
        Entities.Add(entityName, entity);

        return entity;
    }
    
    public static Entity NewEntity()
    {
        string id = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        return AddEntity(new Entity(), id);
    }

    public static Entity AddEntity(Entity entity)
    {
        string id = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        return AddEntity(entity, id);
    }
    
    public static Entity GetEntity(string entityName) { return Entities[entityName]; }

    public static void UpdateAll()
    {
        // Run the Update() method on each and every one of the entities
        foreach(KeyValuePair<string, Entity> entity in Entities)
        {
            entity.Value.Update();
        }
    }

    public static void DrawAll(SpriteBatch spriteBatch)
    {
        // Run the Draw() method on each and every one of the entities
        foreach(KeyValuePair<string, Entity> entity in Entities)
        {
            entity.Value.Draw(spriteBatch);
        }
    }
}