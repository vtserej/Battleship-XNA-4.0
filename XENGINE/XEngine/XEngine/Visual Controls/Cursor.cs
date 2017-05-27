using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Xengine.WindowsControls
{
    public class Cursor : Control
    {
        #region private attributes

        MouseState mouseState;
        int button;
        Point position;
        Texture2D currentTexture;
        ECursor currentCursor;
        Dictionary<ECursor, Texture2D> cursors = new Dictionary<ECursor, Texture2D>();

        #endregion

        #region properties

        public MouseState MouseState
        {
            get { return mouseState; }
            set { mouseState = value; }
        }

        public ECursor CurrentCursor
        {
            get { return currentCursor; }
            set 
            {
                currentCursor = value;
                currentTexture = cursors[currentCursor]; 
            }
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        } 

        public int Button
        {
            get { return button; }
            set { button = value; }
        }

        #endregion

        public Cursor()
        {
            areaRectangle = new Rectangle(0, 0, 32, 32); 
        }

        public void AddCursor(ECursor cname, string cursorName)
        {
            cursors.Add(cname, EngineContent.GetTextureByName(cursorName));     
        }

        public void Update()
        {
            mouseState = Mouse.GetState();
            
            position.X = mouseState.X;
            position.Y = mouseState.Y;   


            if (currentCursor == ECursor.Arrow)
            {
                areaRectangle.X = position.X;
                areaRectangle.Y = position.Y;
            }
            else
            {
                areaRectangle.X = position.X - 16;
                areaRectangle.Y = position.Y - 16;
            }    
        }

        public void Draw()
        {
            Sprite.SpriteBatch.Begin();
            Sprite.DrawSprite(areaRectangle, currentTexture);
            Sprite.SpriteBatch.End(); 
        }
    }
}
