using System.Collections.Generic;
using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace EndangerEdDemo.Game.Screen
{
    public partial class MainMenuScreen : osu.Framework.Screens.Screen
    {
        private BasicButton startButton;
        private BasicButton leaderboardButton;
        private Container profileContainer;
        private AudioVisualizer audioVisualizer;

        [Resolved]
        private AudioPlayer audioPlayer { get; set; }

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
                            Font = EndangerEdDemoFont.GetFont(size: 100f),
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
                                        Margin = new MarginPadding { Right = 100 }
                                    },
                                    {
                                        profileContainer = new Container()
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            RelativeSizeAxes = Axes.Both,
                                            Padding = new MarginPadding { Right = 100 },
                                            Children = new Drawable[]
                                            {
                                                audioVisualizer = new AudioVisualizer
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    Width = 75,
                                                    Height = 75,
                                                    Alpha = 0.5f
                                                },
                                                new Circle
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    Colour = Color4.ForestGreen,
                                                    Width = 75,
                                                    Height = 75,
                                                }
                                            }
                                        }
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

        protected override void LoadComplete()
        {
            base.LoadComplete();
            audioVisualizer.AddAmplitudeSource(audioPlayer.Track.Value);
        }
    }
}
