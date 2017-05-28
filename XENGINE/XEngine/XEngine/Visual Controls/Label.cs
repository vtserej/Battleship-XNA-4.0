using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Xengine.WindowsControls
{
    public class Label : Control, IControl
    {
        #region private atributes

        string text;
        Vector2 pos;
        Vector2 textSize;
        Function myFunction;
        FunctionParameter functionParameter;
        Aligment aligment = Aligment.Left;
        object objeto;

        #endregion

        public Label(string text, Vector2 pos, SpriteFont font)
        {
            base.zOrder = 0;
            this.text = text;
            this.pos = pos;
            base.fontId = font;
        }

        public Label(Function function, Vector2 pos, SpriteFont font)
        {
            myFunction = function;
            base.zOrder = 0;
            this.text = "";
            this.pos = pos;
            base.fontId = font;
        }

        public Label(Function function, Rectangle rec, SpriteFont font, Aligment aligment)
        {
            myFunction = function;
            base.areaRectangle = rec;
            base.zOrder = 0;
            this.text = "";
            base.fontId = font;
            this.aligment = aligment;
        }

        public Label(string text, Rectangle rec, SpriteFont font, Aligment aligment)
        {
            base.areaRectangle = rec;
            base.zOrder = 0;
            this.text = text;
            base.fontId = font;
            this.aligment = aligment;
        }

        public Label(FunctionParameter func, object objeto, Rectangle rec, SpriteFont font, Aligment aligment)
        {
            functionParameter = func;
            this.objeto = objeto;
            base.areaRectangle = rec;
            base.zOrder = 0;
            this.text = "";
            base.fontId = font;
            this.aligment = aligment;
        }

        public string AccesibleName()
        {
            return base.accesibleName;
        }

        public bool Discard()
        {
            return base.discard;
        }

        public int ZOrder()
        {
            return base.zOrder;
        }

        public void Create()
        {
            if (!areaRectangle.IsEmpty)
            {
                textSize = fontId.MeasureString(text);
                if (textSize.X < areaRectangle.Width && textSize.Y < areaRectangle.Height)
                {
                    if (aligment == Aligment.Center)
                    {
                        pos = new Vector2(areaRectangle.X + (areaRectangle.Width - textSize.X) / 2,
                                areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2));
                    }
                    else
                    if (aligment == Aligment.Right)
                    {
                        pos.X = areaRectangle.X + areaRectangle.Width - (int)textSize.X;
                        pos.Y = areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2);
                    }
                    else
                    {
                        pos.X = areaRectangle.X;
                        pos.Y = areaRectangle.Y;
                    }
                }
                else
                {
                    if (aligment == Aligment.Center)
                    {
                        pos = new Vector2(areaRectangle.X + (areaRectangle.Width - textSize.X) / 2,
                                areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2));
                    }
                }
            }
        }

        public void Update(Cursor cursor)
        {
            if (myFunction != null)
            {
                text = myFunction.Invoke();
                textSize = fontId.MeasureString(text);
                if (!areaRectangle.IsEmpty)
                    pos = new Vector2(areaRectangle.X + (areaRectangle.Width - textSize.X) / 2,
                         areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2));

            }
            else
            {
                if (functionParameter != null)
                {
                    text = functionParameter(objeto);
                    textSize = fontId.MeasureString(text);
                    if (!areaRectangle.IsEmpty)
                        pos = new Vector2(areaRectangle.X + (areaRectangle.Width - textSize.X) / 2,
                               areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2));
                }
            }
        }

        public void Draw()
        {
            //Sprite.DrawSprite(areaRectangle, Color.Red);     
            Sprite.SpriteBatch.DrawString(fontId, text, pos, Color.White);
        }
    }
}
