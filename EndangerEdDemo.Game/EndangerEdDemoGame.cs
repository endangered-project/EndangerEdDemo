using System;
using System.Diagnostics;
using System.Threading.Tasks;
using EndangerEdDemo.Game.Audio;
using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Logging;
using osu.Framework.Threading;
using MainMenuScreen = EndangerEdDemo.Game.Screen.Game.MainMenuScreen;
using WarningScreen = EndangerEdDemo.Game.Screen.Game.WarningScreen;

namespace EndangerEdDemo.Game
{
    public partial class EndangerEdDemoGame : EndangerEdDemoGameBase
    {
        private DependencyContainer dependencies;

        private EndangerEdDemoScreenStack screenStack;

        private AudioPlayer audioPlayer;

        private Container overlayContent;

        private Container leftFloatingOverlayContent;

        private SessionStore sessionStore;

        private SwapModeButton swapModeButton;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        [BackgroundDependencyLoader]
        private void load()
        {
            dependencies.CacheAs(this);
            dependencies.CacheAs(sessionStore = new SessionStore());
            Add(screenStack = new EndangerEdDemoScreenStack());
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            AddRange(new Drawable[]
            {
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        screenStack = new EndangerEdDemoScreenStack
                        {
                            RelativeSizeAxes = Axes.Both,
                        }
                    }
                },
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        overlayContent = new Container { RelativeSizeAxes = Axes.Both },
                        leftFloatingOverlayContent = new Container { RelativeSizeAxes = Axes.Both },
                    }
                }
            });

            dependencies.CacheAs(screenStack);
            loadComponentSingleFile(audioPlayer = new AudioPlayer("dota.mp3", true), overlayContent.Add, true);
            loadComponentSingleFile(swapModeButton = new SwapModeButton(), leftFloatingOverlayContent.Add, true);

            screenStack.GameScreenStack.Push(new WarningScreen(new MainMenuScreen()));
        }

        private Task asyncLoadStream;

        /// <summary>
        /// Queues loading the provided component in sequential fashion.
        /// This operation is limited to a single thread to avoid saturating all cores.
        /// </summary>
        /// <param name="component">The component to load.</param>
        /// <param name="loadCompleteAction">An action to invoke on load completion (generally to add the component to the hierarchy).</param>
        /// <param name="cache">Whether to cache the component as type <typeparamref name="T"/> into the game dependencies before any scheduling.</param>
        private T loadComponentSingleFile<T>(T component, Action<Drawable> loadCompleteAction, bool cache = false)
            where T : class
        {
            if (cache)
                dependencies.CacheAs(component);

            var drawableComponent = component as Drawable ?? throw new ArgumentException($"Component must be a {nameof(Drawable)}", nameof(component));

            // schedule is here to ensure that all component loads are done after LoadComplete is run (and thus all dependencies are cached).
            // with some better organisation of LoadComplete to do construction and dependency caching in one step, followed by calls to loadComponentSingleFile,
            // we could avoid the need for scheduling altogether.
            Schedule(() =>
            {
                var previousLoadStream = asyncLoadStream;

                // chain with existing load stream
                asyncLoadStream = Task.Run(async () =>
                {
                    if (previousLoadStream != null)
                        await previousLoadStream.ConfigureAwait(false);

                    try
                    {
                        Logger.Log($"💉 Loading {component}...");

                        // Since this is running in a separate thread, it is possible for maisimGame to be disposed after LoadComponentAsync has been called
                        // throwing an exception. To avoid this, the call is scheduled on the update thread, which does not run if IsDisposed = true
                        Task task = null;
                        var del = new ScheduledDelegate(() => task = LoadComponentAsync(drawableComponent, loadCompleteAction));
                        Scheduler.Add(del);

                        // The delegate won't complete if maisimGame has been disposed in the meantime
                        while (!IsDisposed && !del.Completed)
                            await Task.Delay(10).ConfigureAwait(false);

                        // Either we're disposed or the load process has started successfully
                        if (IsDisposed)
                            return;

                        Debug.Assert(task != null);

                        await task.ConfigureAwait(false);

                        Logger.Log($"💉 Loaded {component}!");
                    }
                    catch (OperationCanceledException)
                    {
                    }
                });
            });

            return component;
        }
    }
}
