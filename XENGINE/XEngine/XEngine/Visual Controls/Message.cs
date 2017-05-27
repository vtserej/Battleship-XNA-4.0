using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Xengine.WindowsControls
{
    public class Message : Control, IControl
    {
        #region Private Atributes

        string textData;
        int time;
        Vector2 pos;
        Color textColor = Color.White;
        int number;
        static int mutex;
        Texture2D textBack;

        #endregion

        public Message(string text, int time, SpriteFont font, Color color, int half, Texture2D texture)
        {
            mutex++;
            number = mutex;
            base.zOrder = 0;
            base.fontId = font; 
            this.textData = text;
            this.time = time;
            this.textColor = color;
            areaRectangle.X = half - (int)fontId.MeasureString(text).X / 2 - 15;
            areaRectangle.Y = Globals.ScreenHeightOver2 - 55;
            areaRectangle.Width = (int)fontId.MeasureString(text).X + 30;
            areaRectangle.Height = 35;
            Vector2 textSize = font.MeasureString(text);  
            pos = new Vector2(areaRectangle.X + (areaRectangle.Width - textSize.X) / 2,
                                     areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2));
            textBack = texture;
        }

        public bool Discard()
        {
            return base.discard;
        }

        public int ZOrder()
        {
            return zOrder;
        }

        public string AccesibleName()
        {
            return accesibleName;
        }

        public void Create()
        { }

        public void Update(Cursor cursor)
        {
            if (time > 0 && mutex == number)
                time--;
            else
                base.discard = true; 
        }

        public void Draw()
        {
            if (time > 0 && mutex == number)
            {
                Sprite.DrawSprite(areaRectangle, textBack);
                Sprite.SpriteBatch.DrawString(fontId, textData, pos, textColor);
            }
        }
    }
}
