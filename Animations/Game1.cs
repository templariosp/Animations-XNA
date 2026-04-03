using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoLink;
using System.Collections.Generic;

namespace Animations
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        FrameAnimation _frameAnimation;
        TextureAnimation _textureAnimation;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Definindo os frames da animação do personagem "Bonkers" a partir de um sprite sheet
            List<SpriteFrame> frames = new List<SpriteFrame>()
            {
                new SpriteFrame(156, 230, 76, 86),
                new SpriteFrame(244, 226, 54, 88),
                new SpriteFrame(308, 228, 74, 86),
                new SpriteFrame(388, 224, 80, 88),
                new SpriteFrame(472, 230, 80, 82),
                new SpriteFrame(560, 230, 76, 88),
                new SpriteFrame(652, 230, 56, 90),
                new SpriteFrame(716, 230, 74, 90),
                new SpriteFrame(792, 230, 82, 92),
                new SpriteFrame(878, 242, 78, 88)
            };

            // Criando a animação do personagem "Bonkers" com os frames definidos e tempo em milissegundos para cada frame
            _frameAnimation = new FrameAnimation(100, string.Empty, Content.Load<Texture2D>("Assets/bonkers"), frames);

            // Definindo a posição inicial da animação do personagem "Bonkers" na tela
            _frameAnimation.Position = new Vector2(500, 300);

            // Definindo os frames separados da animação do cavalo a partir de várias imagens
            Texture2D[] textures =
                [
                    Content.Load<Texture2D>("Assets/horse-run-01"),
                    Content.Load<Texture2D>("Assets/horse-run-02"),
                    Content.Load<Texture2D>("Assets/horse-run-03"),
                    Content.Load<Texture2D>("Assets/horse-run-04"),
                    Content.Load<Texture2D>("Assets/horse-run-05"),
                    Content.Load<Texture2D>("Assets/horse-run-06")
                ];

            // Criando a animação do cavalo com os frames definidos, baseado nas texturas reunidas
            _textureAnimation = new TextureAnimation(70, "horse-run", textures);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Atualiza a animação do personagem "Bonkers"
            _frameAnimation.Update(gameTime);

            // Atualiza a animação do cavalo
            _textureAnimation.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Desenha animação do personagem "Bonkers"
            _frameAnimation.Draw(gameTime, _spriteBatch);

            // Desenha animação do cavalo
            _textureAnimation.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
