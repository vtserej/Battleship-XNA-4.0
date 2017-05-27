using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Xengine.WindowsControls
{
    public class Button : Control, IControl 
    {
        bool isPressed;
        string text = "";
        string textHoverS, texPressedS, texNormalS;
        Texture2D textHover, texPressed, texNormal, texCurrent;
        Vector2 textSize;
        int fontSize;
        SpriteFont font;
        Vector2 textPosition = new Vector2(0, 0);
         

        public Button(Rectangle rectangle, string text, MouseClick onClick)
        {
            base.zOrder = 0; 
            this.text = text;
            this.areaRectangle = rectangle;
            base.mouseClick = onClick;
            texNormalS = "normal";
            texPressedS = "pressed";
            textHoverS = "hover";
            texCurrent = texNormal;
            font = Sprite.SpriteFont;
            textSize = font.MeasureString(text);
            textPosition = new Vector2(areaRectangle.X + (areaRectangle.Width - textSize.X) / 2,
                                        areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2));
        }

        public Button(Rectangle rectangle, MouseClick onClick, string texHover,
                      string texPressed, string texNormal, SpriteFont fontSize)
        {
            base.zOrder = 0;
            this.areaRectangle = rectangle;
            this.mouseClick = onClick;
            this.texNormalS = texNormal;
            this.texPressedS = texPressed;
            this.textHoverS = texHover;
            this.font = Sprite.SpriteFont;  
        }

        public Button(Rectangle rectangle, string text, MouseDown mouseDown)
        {
            base.zOrder = 0;
            this.text = text;
            this.areaRectangle = rectangle;
            base.mouseDown = mouseDown;
            texNormalS = "normal";
            texPressedS = "pressed";
            textHoverS = "hover";
            texCurrent = texNormal;
            font = Sprite.SpriteFont;
            textSize = font.MeasureString(text);
            textPosition = new Vector2(areaRectangle.X + (areaRectangle.Width - textSize.X) / 2,
                                        areaRectangle.Y + ((areaRectangle.Height - textSize.Y) / 2));
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
        {
            textHover = EngineContent.GetTextureByName(textHoverS);
            texPressed = EngineContent.GetTextureByName(texPressedS);
            texNormal = EngineContent.GetTextureByName(texNormalS);
            texCurrent = texNormal; 
        }

        public void Update(Cursor cursor)
        {
            if (areaRectangle.Contains(cursor.Position))
            {
                texCurrent = textHover;
                if (cursor.MouseState.LeftButton == ButtonState.Pressed)
                {
                    isPressed = true;
                    texCurrent = texPressed;
                    if (mouseDown != null)
                        mouseDown.Invoke();
                }
                else

                    if (isPressed)
                    {
                        if (cursor.MouseState.LeftButton == ButtonState.Released)
                        {
                            isPressed = false;
                            texCurrent = texNormal;

                            if (mouseClick != null)
                                mouseClick.Invoke();
                        }
                    }
            }
            else
            {
                isPressed = false;
                texCurrent = texNormal;
            }
        }

        public void Draw()
        {
            Sprite.DrawSprite(areaRectangle, texCurrent);
            Sprite.SpriteBatch.DrawString(font, text, textPosition, Color.White);  
        }
    }
}
