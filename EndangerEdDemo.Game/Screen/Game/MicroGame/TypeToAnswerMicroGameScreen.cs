using EndangerEdDemo.Game.Graphics;
using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Game.MicroGame;

public partial class TypeToAnswerMicroGameScreen : osu.Framework.Screens.Screen
{
    [Resolved]
    private GameSessionStore gameSessionStore { get; set; }

    private EndangerEdDemoTextBox textBox;
    private FillFlowContainer correctTextContainer;
    private SpriteIcon correctIcon;
    private SpriteText correctText;

    [BackgroundDependencyLoader]
    private void load(TextureStore store)
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "นี่คือสัตว์ชนิดใด ?",
                Margin = new MarginPadding
                {
                    Bottom = 400
                },
                Font = EndangerEdDemoFont.GetFont(size: 50, weight: EndangerEdDemoFont.FontWeight.Bold)
            },
            new Sprite()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = store.Get("blahaj.jpeg")
            },
            // Text input
            textBox = new EndangerEdDemoTextBox()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(500, 50),
                CornerRadius = 20,
                Masking = true,
                Margin = new MarginPadding
                {
                    Bottom = -400
                }
            },
            correctTextContainer = new FillFlowContainer()
            {
                Spacing = new Vector2(10),
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Direction = FillDirection.Horizontal,
                Margin = new MarginPadding
                {
                    Bottom = -500,
                    Right = 500
                },
                Alpha = 0,
                Children = new Drawable[]
                {
                    correctIcon = new SpriteIcon()
                    {
                        Icon = FontAwesome.Solid.Check,
                        Size = new Vector2(30),
                        Colour = Colour4.GreenYellow
                    },
                    correctText = new SpriteText()
                    {
                        Text = "ถูกต้อง นี่คือฉลาม! รู้มั้ยมันเหลือน้อยแล้วนะ หมายถึงใน IKEA น่ะ",
                        Margin = new MarginPadding
                        {
                            Bottom = -600
                        },
                        Font = EndangerEdDemoFont.GetFont(size: 30, weight: EndangerEdDemoFont.FontWeight.Bold),
                        Colour = Colour4.GreenYellow,
                    }
                }
            },
            new SpriteText()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "กด Enter เพื่อยืนยันคำตอบ",
                Margin = new MarginPadding
                {
                    Bottom = -600
                },
                Font = EndangerEdDemoFont.GetFont(size: 30, weight: EndangerEdDemoFont.FontWeight.Bold),
                Colour = Colour4.LightGray
            },
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        textBox.OnCommit += (sender, e) =>
        {
            if (textBox.Text == "ฉลาม")
            {
                // Show correct message
                correctTextContainer.FadeIn(300);
                gameSessionStore.StopwatchClock.Stop();
                gameSessionStore.Score.Value += gameSessionStore.GetTimeLeft();
            }
            else
            {
                // Show incorrect message
                correctText.Text = "ผิด นี่มันคือฉลาม! นายอาจจะต้องไปบางใหญ่แล้วล่ะ";
                correctText.Colour = Colour4.Red;
                correctIcon.Icon = FontAwesome.Solid.Times;
                correctIcon.Colour = Colour4.Red;
                correctTextContainer.FadeIn(300);
                gameSessionStore.StopwatchClock.Stop();
                gameSessionStore.Life.Value -= 1;
            }

            Scheduler.AddDelayed(this.Exit, 2000);
        };
    }
}
