using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Xengine
{
    public static class Sprite
    {
        #region private attributes

        static GraphicsDeviceManager graphics;
       
        static SpriteBatch spriteBatch;
       
        static SpriteFont spriteFont;

        static BasicEffect basicEffect;

        static Matrix viewMatrix;

        static Matrix projectionMatrix;

        static VertexPositionColor[] pointList;

        static VertexDeclaration vertexDeclaration;
        
        #endregion

        #region Properties

        public static GraphicsDeviceManager Graphics
        {
            get { return Sprite.graphics; }
            set { Sprite.graphics = value; }
        }

        public static SpriteBatch SpriteBatch
        {
            get { return Sprite.spriteBatch; }
            set { Sprite.spriteBatch = value; }
        }

        public static SpriteFont SpriteFont
        {
            get { return Sprite.spriteFont; }
            set { Sprite.spriteFont = value; }
        }

        public static BasicEffect BasicEffect
        {
            get { return Sprite.basicEffect; }
            set { Sprite.basicEffect = value; }
        }

        public static VertexDeclaration VertexDeclaration
        {
            get { return Sprite.vertexDeclaration; }
            set { Sprite.vertexDeclaration = value; }
        }


        #endregion

        static public void Create()
        {
            pointList = new VertexPositionColor[5];

            //vertexDeclaration = new VertexDeclaration(graphics.GraphicsDevice,
            //                                VertexPositionTexture.VertexElements);

            viewMatrix = Matrix.CreateLookAt(
              new Vector3(0.0f, 0.0f, 1.0f),
              Vector3.Zero,
              Vector3.Up
              );

            projectionMatrix = Matrix.CreateOrthographicOffCenter(
                0,
                Globals.ScreenWidth ,
                Globals.ScreenHeight,
                0,
                1.0f, 1000.0f);
        }

        static public void DrawSprite(Rectangle rectangle, Texture2D texture)
        {
            spriteBatch.Draw(texture, rectangle, Color.White); 
        }

        static public void DrawSprite(Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(EngineContent.GetTextureByName("white"), rectangle, color);
        }

        static public void DrawBoxFrame(Rectangle rectangle, Color colorBorder, Color colorFill, int frameSize)
        {
            spriteBatch.Draw(EngineContent.GetTextureByName("white"), rectangle, colorBorder);
            Rectangle rect = new Rectangle(rectangle.X + frameSize, rectangle.Y + frameSize,
                                           rectangle.Width - frameSize * 2, rectangle.Height - frameSize * 2);
            spriteBatch.Draw(EngineContent.GetTextureByName("white"), rect, colorFill);
        }

        static public void DrawSpriteLine(Rectangle rectangle, Color color)
        {
            Matrix saveView = Sprite.basicEffect.View;
            Matrix saveWorld = Sprite.basicEffect.World;

            Sprite.basicEffect.View = viewMatrix;
            Sprite.basicEffect.Projection = projectionMatrix;

            Sprite.basicEffect.VertexColorEnabled = true;
            Sprite.basicEffect.TextureEnabled = false;
            Sprite.BasicEffect.LightingEnabled = false;
            Sprite.basicEffect.Texture = null;

            pointList[0] = new VertexPositionColor(new Vector3(rectangle.X, rectangle.Y, 0), color);
            pointList[1] = new VertexPositionColor(new Vector3(rectangle.X + rectangle.Width, rectangle.Y, 0), color);
            pointList[2] = new VertexPositionColor(new Vector3(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height, 0), color);
            pointList[3] = new VertexPositionColor(new Vector3(rectangle.X, rectangle.Y + rectangle.Height, 0), color);
            pointList[4] = new VertexPositionColor(new Vector3(rectangle.X, rectangle.Y, 0), color);

            foreach (EffectPass pass in Sprite.BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                Sprite.Graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                    PrimitiveType.LineStrip,
                    pointList,
                    0,  // vertex buffer offset to add to each element of the index buffer
                    4  // number of vertices in pointList
                    );
            }

            Sprite.basicEffect.TextureEnabled = true;
            Sprite.basicEffect.VertexColorEnabled = false;
            Sprite.basicEffect.LightingEnabled = true;

            Sprite.basicEffect.View = saveView;
            Sprite.basicEffect.World = saveWorld; 
        }

        static public void DrawAlphaSprite(Rectangle rectangle, Color color, byte transparency)
        {
            color.A = transparency;  
            spriteBatch.Draw(EngineContent.GetTextureByName("white"), rectangle, color);
        }

        static public void DrawCenterText(Vector2 pos, string text, SpriteFont font)
        {
            int x = (int)font.MeasureString(text).X;
            pos.X = Globals.ScreenWidthOver2 - x / 2;
            spriteBatch.DrawString(font, text, pos, Color.White);       
        }

        static public void DrawCenterText(Vector2 pos,Vector2 origin, string text, SpriteFont font)
        {
            int x = (int)font.MeasureString(text).X;
            pos.X = Globals.ScreenWidthOver2 - x / 2;
            spriteBatch.DrawString(font, text, pos, Color.White, 0, origin, 1, SpriteEffects.None, 1);
        }
    }
}
