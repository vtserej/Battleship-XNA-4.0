using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Xengine.WindowsControls
{
    public delegate void MouseClick();
    public delegate void MouseDown();
    public delegate string Function();
    public delegate string FunctionParameter(object objeto);


    public abstract class Control
    {
        protected string accesibleName = "null";
        protected MouseClick mouseClick;
        protected MouseDown mouseDown;
        protected Rectangle areaRectangle;
        protected Color fontColor = Color.White;
        protected int zOrder;
        protected int displayList;
        protected SpriteFont fontId;
        protected bool discard;

        public string Name
        {
            get { return accesibleName; }
        }
    }
}
