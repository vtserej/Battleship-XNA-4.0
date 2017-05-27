using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Xengine
{
    public static class Layout
    {
        #region private attributes

        static ScreenFormat screenFormat;

        static Vector2 layoutPosition;

        static Vector2 layoutSize;

        #endregion

        #region properties

        public static Vector2 LayoutPosition
        {
            get { return Layout.layoutPosition; }
            set { Layout.layoutPosition = value; }
        }

        public static Vector2 LayoutSize
        {
            get { return Layout.layoutSize; }
            set { Layout.layoutSize = value; }
        }

        public static ScreenFormat ScreenFormat
        {
            get { return Layout.screenFormat; }
            set { Layout.screenFormat = value; }
        }

        #endregion

        static public ScreenFormat CalculateScreenFormat(int width, int height)
        {
            if (Math.Abs(((width / (float)height) - (4 / (float)3))) < 0.05f)
            {
                return ScreenFormat.Format4X3;
            }

            if (Math.Abs(((width / (float)height) - (16 / (float)9))) < 0.05f)
            {
                return ScreenFormat.Format16X9;
            }
            return ScreenFormat.FormatOther;  
        }

        static public void CreateLayouts(int screenWidth, int screenHeight)
        {
            if (((screenWidth / (float)screenHeight) - (4 / (float)3)) < 0.05f)
            {
                screenFormat = ScreenFormat.Format4X3;
                layoutPosition = new Vector2(screenWidth / (float)1024, screenHeight / (float)768);
            }
            else
            {
                if (((screenWidth / (float)screenHeight) - (16 / (float)9)) < 0.05f)
                {
                    screenFormat = ScreenFormat.Format16X9;
                    layoutPosition = new Vector2(screenWidth / (float)1280, screenHeight / (float)720);
                }
                else
                {
                    screenFormat = ScreenFormat.Format4X3;// to implement in future versions
                    layoutPosition = new Vector2(screenWidth / (float)1024, screenHeight / (float)768);
                }
            }
        }

        static public int CalculateLayoutY(int top)
        {
            return (int)(top * layoutPosition.Y);
        }

        static public int CalculateLayoutX(int left)
        {
            return (int)(left * layoutPosition.X);
        }

        static public Rectangle CalculateLayoutXY(Rectangle rect)
        {
            rect.X = (int)(rect.X * layoutPosition.X);
            rect.Y = (int)(rect.Y * layoutPosition.Y);
            return rect;
        }

        static public Vector2 CalculateLayoutXY(int left, int top)
        {
            return new Vector2(left * layoutPosition.X, top * layoutPosition.Y);
        }

        static public Rectangle CalculateTotalLayout(Rectangle rect)
        {
            rect.X = (int)(rect.X * layoutPosition.X);
            rect.Y = (int)(rect.Y * layoutPosition.Y);
            rect.Width = (int)(rect.Width * layoutPosition.X);
            rect.Height = (int)(rect.Height * layoutPosition.Y);
            return rect;
        }

        static public Rectangle CenterRectangle(Rectangle rect)
        {
            rect.X = (1280 / 2) - (rect.Width / 2);
            rect.Y = (720 / 2) - (rect.Height / 2);
            return rect;
        }

        static public Rectangle CenterRectangle(int width, int height)
        {
            if (screenFormat == ScreenFormat.Format4X3)
                return new Rectangle((1024 / 2) - (width / 2), (768 / 2) - (height / 2), width, height);
            else
                return new Rectangle((1280 / 2) - (width / 2), (720 / 2) - (height / 2), width, height);
        }

        static public Rectangle CenterRectangleX(int top, int width, int height)
        {
            if (screenFormat == ScreenFormat.Format4X3)
                return new Rectangle((1024 / 2) - (width / 2), top, width, height);
            else
                return new Rectangle((1280 / 2) - (width / 2), top, width, height);
        }

        static public Rectangle CenterRectangleY(int left, int width, int height)
        {
            if (screenFormat == ScreenFormat.Format4X3)
                return new Rectangle(left, (768 / 2) - (height / 2), width, height);
            else
                return new Rectangle(left, (720 / 2) - (height / 2), width, height);
        }

        static public Rectangle CenterRectangleOverMiddleX(int top, int width, int height, int displacement)
        {
            if (screenFormat == ScreenFormat.Format4X3)
                return new Rectangle(((1024 / 2) - (width / 2)) + displacement, top, width, height);
            else
                return new Rectangle(((1280 / 2) - (width / 2)) + displacement, top, width, height);
        }
    }
}
