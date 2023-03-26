using System.Collections.Generic;
using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Graphics;
using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace EndangerEdDemo.Game.Screen.Game
{
    public partial class MainMenuScreen : EndangerEdDemoGameScreen
    {
        public override PresentationSlideNumber PresentationSlideNumber => PresentationSlideNumber.Slide1;

        private BasicButton startButton;
        private BasicButton leaderboardButton;
        private Container profilePictureContainer;
        private Container guestProfilePicture;
        private Sprite loggedInProfilePicture;
        private AudioVisualizer audioVisualizer;
        private Container knowledgeBaseContainer;
        private EndangerEdDemoButton loginButton;
        private EndangerEdDemoButton signUpButton;

        [Resolved]
        private AudioPlayer audioPlayer { get; set; }

        [Resolved]
        private EndangerEdDemoScreenStack screenStack { get; set; }

        [Resolved]
        private SessionStore sessionStore { get; set; }

        private void onLoginChanged(ValueChangedEvent<bool> isLoggedIn)
        {
            {
                if (isLoggedIn.NewValue)
                {
                    loggedInProfilePicture.FadeIn(500, Easing.OutQuint);
                    guestProfilePicture.FadeOut(500, Easing.OutQuint);
                    signUpButton.FadeOut(500, Easing.OutQuint);
                    loginButton.SetText("Logout");
                    Schedule(() => sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber.Slide2);
                }
                else
                {
                    loggedInProfilePicture.FadeOut(500, Easing.OutQuint);
                    guestProfilePicture.FadeIn(500, Easing.OutQuint);
                    signUpButton.FadeIn(500, Easing.OutQuint);
                    loginButton.SetText("Login");
                    Schedule(() => sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber.Slide1);
                }
            }
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            Y = 3000f;
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
                                    Height = 50,
                                    Action = () => screenStack.GameScreenStack.Push(new LoadingScreen())
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
                                    {
                                        loginButton = new EndangerEdDemoButton("Login")
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            Y = 200f,
                                            Width = 100,
                                            Height = 50,
                                            Margin = new MarginPadding { Right = 120 },
                                            Action = () =>
                                            {
                                                sessionStore.SwitchLoggedInState();
                                            }
                                        }
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
                                                loggedInProfilePicture = new Sprite
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    Name = "Profile picture",
                                                    Width = 75,
                                                    Height = 75,
                                                    FillMode = FillMode.Fit,
                                                    Texture = textureStore.Get("fuji.png")
                                                },
                                                audioVisualizer = new AudioVisualizer
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    Width = 75,
                                                    Height = 75,
                                                    // TODO: Fix this after profile picture is circle
                                                    Alpha = 0f
                                                },
                                                guestProfilePicture = new Container
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
                                    {
                                        signUpButton = new EndangerEdDemoButton("Sign up")
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            Y = 250f,
                                            Width = 100,
                                            Height = 50,
                                            AlwaysPresent = true
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            sessionStore.IsLoggedIn.BindValueChanged(onLoginChanged, true);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            audioVisualizer.AddAmplitudeSource(audioPlayer.Track.Value);
            knowledgeBaseContainer.ScaleTo(new Vector2(1.2f), 500, Easing.OutSine).Then().ScaleTo(new Vector2(1f), 500, Easing.OutSine).Loop();
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            base.OnEntering(e);
            this.MoveToY(0f, 1000, Easing.OutQuint)
                .FadeInFromZero(1000, Easing.OutQuint);
        }

        public override void OnSuspending(ScreenTransitionEvent e)
        {
            base.OnSuspending(e);
            this.MoveToY(3000f, 1000, Easing.OutQuint)
                .FadeTo(0f, 1000, Easing.OutQuint);
        }

        public override void OnResuming(ScreenTransitionEvent e)
        {
            base.OnResuming(e);
            this.MoveToY(0f, 1000, Easing.OutQuint)
                .FadeInFromZero(1000, Easing.OutQuint);
            audioPlayer.Play();

            if (sessionStore.IsLoggedIn.Value)
            {
                sessionStore.CurrentSlideNumber.Value = PresentationSlideNumber.Slide2;
            }
        }
    }
}
