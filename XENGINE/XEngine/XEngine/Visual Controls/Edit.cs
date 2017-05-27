using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;   

namespace Xengine.WindowsControls
{
    public class Edit : Control, IControl
    {
        string text = "";
        bool pressed;
        int maxLenght;
        Vector2 textSize;
        Vector2 textPosition;
        int cursorCount;
        Keys keyPressed;
        Keys keyLast;
        Rectangle scissorRectangle;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Edit(Rectangle rect, string name, string text)
        {
            base.areaRectangle = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            scissorRectangle = new Rectangle(rect.X, rect.Y, areaRectangle.Width - 5, rect.Height);      
            base.zOrder = 0;
            maxLenght = 15;
            textSize = Sprite.SpriteFont.MeasureString(text);
            textPosition = new Vector2(areaRectangle.X + 5, areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2));
            accesibleName = name;
            this.text = text;
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
        { }

        public void Update(Cursor cursor)
        {
            cursorCount += 2;
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                keyPressed = Keyboard.GetState().GetPressedKeys()[0];
                if (keyPressed.ToString().Length > 1 && keyPressed != Keys.Back && keyPressed != Keys.Space )
                    keyPressed = Keys.None;  
            }

            else
                keyPressed = Keys.None; 
                if (keyLast != keyPressed || pressed == true)
                {
                    if (char.IsLetter((char)keyPressed) && text.Length < maxLenght)
                    {
                        string keyString = keyPressed.ToString();

                        if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) == false)
                            keyString = keyString.ToLower();

                        text += keyString;
                        pressed = false;
                    }
                    else
                        switch (keyPressed)
                        {
                            case Keys.Back:
                                {
                                    if (text.Length > 0)
                                    {
                                        text = text.Remove(text.Length - 1);
                                        pressed = false;
                                    }
                                    break;
                                }
                            case Keys.Space:
                                {
                                    text += " ";
                                    pressed = false;
                                    break;
                                }
                            default:
                                break;
                        }
                }
                keyLast = keyPressed;
        }

        public void Draw()
        {
            //Sprite.Graphics.GraphicsDevice.ScissorRectangle = scissorRectangle;
            //Sprite.DrawBoxFrame(areaRectangle, Color.White, Color.Black, 1);
            //border of the control 
            Sprite.SpriteBatch.End();

            #region Scissor testing

            //TODO PORTSprite.Graphics.GraphicsDevice.RenderState.ScissorTestEnable = true; 
            Sprite.SpriteBatch.Begin();

            if (cursorCount > 48)
            {
                Sprite.SpriteBatch.DrawString(Sprite.SpriteFont, text + "|", textPosition, Color.White);
                if (cursorCount == 96)
                {
                    cursorCount = 0;
                }
            }
            else
                 Sprite.SpriteBatch.DrawString(Sprite.SpriteFont, text, textPosition, Color.White);

                Sprite.SpriteBatch.End();
            //TODO PORTSprite.Graphics.GraphicsDevice.RenderState.ScissorTestEnable = false;

            #endregion

               Sprite.SpriteBatch.Begin();
        }
    }
}
