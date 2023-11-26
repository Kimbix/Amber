using System;
using System.Threading;
using Amber.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Amber;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Sprite _test;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        TextureManager.LoadTexture(Content, "Sprites/Player/player_sprite", "player_sprite");
        TextureManager.LoadTexture(Content, "Sprites/Player/testing_sprite", "testing_sprite");

        _test = new Sprite(TextureManager.GetTexture("testing_sprite"), 4, 8);
        _test.RegisterAnimation(0, 8);
        _test.RegisterAnimation(1, 4);
        _test.RegisterAnimation(2, 8);
        _test.RegisterAnimation(3, 4);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();

        _test.DrawTexture(_spriteBatch, Vector2.Zero);
        
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
