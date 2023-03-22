using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK.Graphics;

namespace EndangerEdDemo.Game
{
    public partial class MainMenuScreen : osu.Framework.Screens.Screen
    {
        private BasicButton startButton;
        private BasicButton leaderboardButton;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Container()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Text = "EndangerEd Demo",
                            Font = new FontUsage(size: 50),
                            Y = -200f
                        },
                        new Container
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Children = new List<Drawable>
                            {
                                new BasicButton
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Text = "Start!",
                                    Colour = Color4.GreenYellow,
                                    BackgroundColour = Color4.Brown,
                                    Y = -50f,
                                    Width = 100,
                                    Height = 50
                                },
                                new BasicButton
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Text = "Leaderboard",
                                    Colour = Color4.GreenYellow,
                                    BackgroundColour = Color4.Brown,
                                    Y = 50f,
                                    Width = 150,
                                    Height = 50
                                }
                            }
                        },
                        new Container
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Y = 200f,
                            Child = new FillFlowContainer
                            {
                                Direction = FillDirection.Horizontal,
                                // Login and signup buttons
                                Children = new List<Drawable>()
                                {
                                    new BasicButton
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Text = "Login",
                                        Colour = Color4.GreenYellow,
                                        BackgroundColour = Color4.Brown,
                                        Y = 200f,
                                        Width = 100,
                                        Height = 50,
                                        Margin = new MarginPadding { Right = 30 }
                                    },
                                    new Circle
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Colour = Color4.ForestGreen,
                                        Width = 75,
                                        Height = 75,
                                        Margin = new MarginPadding { Right = 30 }
                                    },
                                    new BasicButton
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Text = "Sign up",
                                        Colour = Color4.GreenYellow,
                                        BackgroundColour = Color4.Brown,
                                        Y = 250f,
                                        Width = 100,
                                        Height = 50
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
