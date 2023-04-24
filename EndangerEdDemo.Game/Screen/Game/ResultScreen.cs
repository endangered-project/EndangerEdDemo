using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Game;

public partial class ResultScreen : EndangerEdDemoGameScreen
{
    public override PresentationSlideNumber PresentationSlideNumber { get; set; } = PresentationSlideNumber.Slide5;

    [Resolved]
    private SessionStore sessionStore { get; set; }

    [Resolved]
    private GameSessionStore gameSessionStore { get; set; }

    [Resolved]
    private EndangerEdDemoScreenStack screenStack { get; set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            // leaderboard
            new FillFlowContainer()
            {
                Direction = FillDirection.Vertical,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding()
                {
                    Top = 80,
                    Left = 100,
                },
                Spacing = new Vector2(10),
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = "Leaderboard",
                        Font = new FontUsage(size: 50),
                    },
                    new SpriteText
                    {
                        Text = "1. Player 1",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "2. Player 2",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "3. Player 3",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "4. Player 4",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "5. Player 5",
                        Font = new FontUsage(size: 30),
                    },
                }
            },
            // leaderboard score
            new FillFlowContainer()
            {
                Direction = FillDirection.Vertical,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding()
                {
                    Top = 140,
                    Left = 400,
                },
                Spacing = new Vector2(10),
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = "100",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "90",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "80",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "70",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "60",
                        Font = new FontUsage(size: 30),
                    },
                }
            },
            // score
            new FillFlowContainer()
            {
                Direction = FillDirection.Vertical,
                Anchor = Anchor.TopRight,
                Origin = Anchor.TopRight,
                Margin = new MarginPadding()
                {
                    Top = 80,
                    Right = 500,
                },
                Spacing = new Vector2(10),
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = "Score",
                        Font = new FontUsage(size: 50),
                    },
                    new SpriteText
                    {
                        Text = "Your score : 100",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "Current rank : 1",
                        Font = new FontUsage(size: 30),
                    },
                }
            },
            // Session score
            new FillFlowContainer()
            {
                Direction = FillDirection.Vertical,
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Margin = new MarginPadding()
                {
                    Bottom = 350,
                    Left = 100,
                },
                Spacing = new Vector2(10),
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = "This session detail",
                        Font = new FontUsage(size: 50),
                    },
                    new SpriteText
                    {
                        Text = "Corrent : 1, Wrong : 1",
                        Font = new FontUsage(size: 20),
                        Colour = Colour4.WhiteSmoke,
                        Alpha = 0.8f,
                    },
                    new SpriteText
                    {
                        Text = "1. (Type to answer) นี่คือสัตว์ชนิดใด ?",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "You answered correctly",
                        Colour = Colour4.LimeGreen,
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "2. (Type to answer) นี่คือสัตว์ชนิดใด ?",
                        Font = new FontUsage(size: 30),
                    },
                    new SpriteText
                    {
                        Text = "Correct answer : ปลากระโดดได้",
                        Colour = Colour4.Red,
                        Font = new FontUsage(size: 30),
                    },
                }
            },
            // Session ID
            new FillFlowContainer()
            {
                Direction = FillDirection.Vertical,
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Margin = new MarginPadding()
                {
                    Bottom = 60,
                    Left = 10,
                },
                Spacing = new Vector2(10),
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = "Session ID : 1234",
                        Font = new FontUsage(size: 20),
                    },
                    new SpriteText
                    {
                        Text = "Score ID : 1230",
                        Font = new FontUsage(size: 20),
                    }
                }
            },
            // Back to menu
            new EndangerEdDemoButton("Back to menu")
            {
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding()
                {
                    Bottom = 10,
                    Right = 10,
                },
                Size = new Vector2(200, 50),
                Action = () =>
                {
                    screenStack.GameScreenStack.Push(new MainMenuScreen());
                    sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber.Slide1;
                }
            },
            // Play again
            new EndangerEdDemoButton("Play again")
            {
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding()
                {
                    Bottom = 10,
                    Right = 220,
                },
                Size = new Vector2(200, 50)
            },
        };
    }
}
