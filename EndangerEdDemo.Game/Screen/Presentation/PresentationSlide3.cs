using EndangerEdDemo.Game.Screen.Game;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Presentation;

public partial class PresentationSlide3 : EndangerEdDemoPresentationScreen
{
    public override EndangerEdDemoGameScreen GameScreen => new MainMenuScreen();

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText
            {
                Text = "Loading screen before the game starts",
                Font = new FontUsage(size: 50),
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding(10),
            },
            new SpriteText
            {
                Text = "3",
                Font = new FontUsage(size: 30),
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding(10),
            },
            new SpriteText
            {
                Text = "During the loading process, the loading screen is shown.",
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
                Text = "Now the game is currently in contact with the game server to create a new game session.",
                Font = new FontUsage(size: 25),
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
