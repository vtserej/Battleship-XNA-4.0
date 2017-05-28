using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Xengine
{
    public enum ScreenFormat
    { Format4X3, Format16X9, FormatOther };

    public static class DxManager
    {
        #region private attributes

        static int widht, height;

        static Game game;

        static GraphicsDeviceManager graphics;

        static SpriteBatch spriteBatch;

        static SpriteFont spriteFont;

        const float aspect16X9 = 16 / (float)9;

        const float aspect4X3 = 4 / (float)3;

        #endregion

        #region properties

        public static Game Game
        {
            get { return DxManager.game; }
            set { DxManager.game = value; }
        }

        public static GraphicsDeviceManager Graphics
        {
            get { return DxManager.graphics; }
            set { DxManager.graphics = value; }
        }

        public static SpriteBatch SpriteBatch
        {
            get { return DxManager.spriteBatch; }
            set { DxManager.spriteBatch = value; }
        }

        public static SpriteFont SpriteFont
        {
            get { return DxManager.spriteFont; }
            set { DxManager.spriteFont = value; }
        }


        #endregion

        public static GraphicsDeviceManager XNAInit(Game game, string contentRoot)
        {
            DisplayMode displayMode = GetGameDisplayMode(); 
            Layout.CreateLayouts(displayMode.Width, displayMode.Height);  
            DxManager.game = game;
            graphics = new GraphicsDeviceManager(DxManager.game);
            game.Content.RootDirectory = contentRoot;
            EngineContent.ContentRoot = contentRoot;
            graphics.PreferredBackBufferWidth = displayMode.Width;
            graphics.PreferredBackBufferHeight = displayMode.Height;
            widht = displayMode.Width;
            height = displayMode.Height;
            Globals.ScreenHeight = height;
            Globals.ScreenWidth = widht;
            DxHelper.Create();
            return graphics; 
        }

        public static GraphicsDeviceManager XNAInit(Game game, string contentRoot, int screenWidth, int screenHeight)
        {
            Layout.CreateLayouts(screenWidth, screenHeight);
            DxManager.game = game;
            graphics = new GraphicsDeviceManager(DxManager.game);
            game.Content.RootDirectory = contentRoot;
            EngineContent.ContentRoot = contentRoot;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            widht = screenWidth;
            height = screenHeight;
            Globals.ScreenHeight = height;
            Globals.ScreenWidth = widht;
            DxHelper.Create();

            return graphics;
        }

        public static DisplayMode GetGameDisplayMode()
        {
            DisplayMode d = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;

            //if aspect ratio is 4X3 and width is higher than 1024 
            if ((Math.Abs((d.AspectRatio - aspect4X3)) < 0.0005f) && d.Width > 1024)
            {
                foreach (DisplayMode displayMode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
                {
                    //search a 4/3 resolution 
                    if (displayMode.Width == 1024 && displayMode.Height == 768)
                    {
                        return displayMode;
                    }
                }
            }

            if (d.Width >= 1024)
            {
                //if aspect ration of the current resolution is 4X3(supported)
                if (Math.Abs((d.AspectRatio - aspect4X3)) < 0.0005f)
                {
                    return d;
                }
                //if aspect ratio of the current resolution is 16X9(supported)
                if (Math.Abs((d.AspectRatio - aspect16X9)) < 0.0005f)
                {
                    return d;
                }
            }       

            //if current resolution is not 16X9 or 4X3 find the supported resolution that is 
            //most equal to the current resolution (not supported)

            if ((Math.Abs(aspect16X9 - d.AspectRatio) < (Math.Abs(aspect4X3 - d.AspectRatio))))
            {
                foreach (DisplayMode displayMode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
                {
                    //search a 16/9 resolution 
                    ScreenFormat f = Layout.CalculateScreenFormat(displayMode.Width, displayMode.Height);
                    if ((f == ScreenFormat.Format16X9 && displayMode.Width >= 1024))
                    {
                        return displayMode;
                    }
                }
            }
            else
            {
                foreach (DisplayMode displayMode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
                {
                    //search a 4X3 resolution 
                    ScreenFormat f = Layout.CalculateScreenFormat(displayMode.Width, displayMode.Height);
                    if (f == ScreenFormat.Format4X3 && displayMode.Width >= 1024)
                    {
                        return displayMode;
                    }
                }
            }
            return d;
        }
    }
}
