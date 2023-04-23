using EndangerEdDemo.Game.Screen.Game;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Presentation;

public partial class PresentationSlide1 : EndangerEdDemoPresentationScreen
{
    public override EndangerEdDemoGameScreen GameScreen => new MainMenuScreen();

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText
            {
                Text = "Main Menu",
                Font = new FontUsage(size: 50),
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding(10),
            },
            new SpriteText
            {
                Text = "1",
                Font = new FontUsage(size: 30),
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding(10),
            },
            new SpriteText
            {
                Text = "The main menu is the first screen that is shown when the game is started.",
                Font = new FontUsage(size: 25),
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding()
                {
                    Top = 60,
                    Left = 10,
                }
            },
            new SpriteText
            {
                Text = "A player need to login first before they can play the game.",
                Font = new FontUsage(size: 25),
                Colour = Colour4.Red,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding()
                {
                    Top = 80,
                    Left = 10,
                }
            },
            new FillFlowContainer
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Direction = FillDirection.Horizontal,
                Margin = new MarginPadding()
                {
                    Bottom = 30,
                    Left = 10,
                },
                Spacing = new Vector2(3),
                Children = new Drawable[]
                {
                    new SpriteIcon
                    {
                        Icon = FontAwesome.Solid.Flask,
                        Size = new Vector2(15),
                    },
                    new SpriteText
                    {
                        Text = "This is a demo version of the EndangerEd project, the final version maybe different.",
                        Font = new FontUsage(size: 15),
                        Margin = new MarginPadding()
                        {
                            Left = 10,
                        }
                    }
                }
            }
        };
    }
}
