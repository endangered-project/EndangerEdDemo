using System.Collections.Generic;
using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Graphics;
using EndangerEdDemo.Game.Graphics.Components;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace EndangerEdDemo.Game.Screen
{
    public partial class MainMenuScreen : osu.Framework.Screens.Screen
    {
        private BasicButton startButton;
        private BasicButton leaderboardButton;
        private Container profilePictureContainer;
        private Container profilePicture;
        private AudioVisualizer audioVisualizer;
        private Container knowledgeBaseContainer;

        [Resolved]
        private AudioPlayer audioPlayer { get; set; }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
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
                            Text = "EndangerEd",
                            Font = EndangerEdDemoFont.GetFont(typeface: EndangerEdDemoFont.Typeface.Comfortaa, size: 100, weight: EndangerEdDemoFont.FontWeight.Bold),
                            Y = -200f
                        },
                        knowledgeBaseContainer = new Container
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Y = -130f,
                            X = 230f,
                            Size = new Vector2(150f),
                            Rotation = 315f,
                            Children = new Drawable[]
                            {
                                new SpriteIcon()
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    RelativeSizeAxes = Axes.Both,
                                    Size = new Vector2(0.5f),
                                    Icon = FontAwesome.Solid.BookOpen,
                                    Colour = Color4.White
                                },
                                new SpriteText()
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Text = "Knowledge base",
                                    Font = EndangerEdDemoFont.GetFont(typeface: EndangerEdDemoFont.Typeface.Comfortaa, size: 20, weight: EndangerEdDemoFont.FontWeight.Bold),
                                    Y = 40f
                                }
                            }
                        },
                        new Container
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Children = new List<Drawable>
                            {
                                new EndangerEdDemoButton("Start!")
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Y = -50f,
                                    Width = 100,
                                    Height = 50
                                },
                                new EndangerEdDemoButton("Leaderboard")
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
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
                                    new EndangerEdDemoButton("Login")
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Y = 200f,
                                        Width = 100,
                                        Height = 50,
                                        Margin = new MarginPadding { Right = 120 }
                                    },
                                    {
                                        profilePictureContainer = new Container()
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            RelativeSizeAxes = Axes.Both,
                                            Padding = new MarginPadding { Right = 120 },
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
                                                profilePicture = new Container
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    Width = 75,
                                                    Height = 75,
                                                    CornerRadius = 100,
                                                    Child = new Container()
                                                    {
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        RelativeSizeAxes = Axes.Both,
                                                        Masking = true,
                                                        Children = new Drawable[]
                                                        {
                                                            new Circle
                                                            {
                                                                Anchor = Anchor.Centre,
                                                                Origin = Anchor.Centre,
                                                                RelativeSizeAxes = Axes.Both,
                                                                Colour = Colour4.DarkGreen,
                                                                BorderThickness = 10,
                                                                BorderColour = Color4.White,
                                                                Masking = true
                                                            },
                                                            new Container
                                                            {
                                                                Anchor = Anchor.Centre,
                                                                Origin = Anchor.Centre,
                                                                RelativeSizeAxes = Axes.Both,
                                                                Child = new SpriteIcon
                                                                {
                                                                    Anchor = Anchor.Centre,
                                                                    Origin = Anchor.Centre,
                                                                    RelativeSizeAxes = Axes.Both,
                                                                    Size = new Vector2(0.5f),
                                                                    Icon = FontAwesome.Solid.User,
                                                                    Colour = Color4.White
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    new EndangerEdDemoButton("Sign up")
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
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
            knowledgeBaseContainer.ScaleTo(new Vector2(1.2f), 500, Easing.OutSine).Then().ScaleTo(new Vector2(1f), 500, Easing.OutSine).Loop();
        }
    }
}
