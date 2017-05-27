using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Xengine
{
    public static class DxHelper
    {
        static VertexPositionTexture[] pointList;

        public static void Create()
        {
            pointList = new VertexPositionTexture[6];

            pointList[0] = new VertexPositionTexture(
                   new Vector3(-0.5f, -0.5f, 0), new Vector2(0, 0));

            pointList[1] = new VertexPositionTexture(
                new Vector3(-0.5f, 0.5f, 0), new Vector2(0, 1));

            pointList[2] = new VertexPositionTexture(
                new Vector3(0.5f, -0.5f, 0), new Vector2(1, 0));

            pointList[3] = new VertexPositionTexture(
                new Vector3(-0.5f, 0.5f, 0), new Vector2(0, 1));

            pointList[4] = new VertexPositionTexture(
                new Vector3(0.5f, 0.5f, 0), new Vector2(1, 1));

            pointList[5] = new VertexPositionTexture(
                new Vector3(0.5f, -0.5f, 0), new Vector2(1, 0)); 
        }

        public static void DrawSquare(Texture2D texture)
        {
            Sprite.BasicEffect.TextureEnabled = true;
            Sprite.BasicEffect.Texture = texture;
            Sprite.BasicEffect.LightingEnabled = false;

            //TODO PORT
            //Sprite.BasicEffect.Begin();

            //foreach (EffectPass pass in Sprite.BasicEffect.CurrentTechnique.Passes)
            //{
            //    pass.Begin();
            //    Sprite.Graphics.GraphicsDevice.VertexDeclaration = new VertexDeclaration(Sprite.Graphics.GraphicsDevice,
            //                                VertexPositionTexture.VertexElements);

            //    Sprite.Graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(
            //        PrimitiveType.TriangleList,
            //        pointList,
            //        0,  // vertex buffer offset to add to each element of the index buffer
            //        2  // number of vertices in pointList
            //        );
            //    pass.End();
            //}

            //Sprite.BasicEffect.End();
            Sprite.BasicEffect.LightingEnabled = true;
        }
    }
}
