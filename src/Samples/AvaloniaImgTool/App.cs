﻿using AvaloniaImgTool.GenerateImageFromText;
using AvaloniaImgTool.Services;
using Microsoft.Extensions.DependencyInjection;

var lifetime = new ClassicDesktopStyleApplicationLifetime { Args = args, ShutdownMode = ShutdownMode.OnLastWindowClose };

var services = new ServiceCollection();
services.AddSingleton<HuggingFaceService>();
services.AddSingleton(new SettingsService());
services.AddSingleton(new SaveFilePickerService(() => lifetime.MainWindow.StorageProvider));
var sp = services.BuildServiceProvider();

FluentTheme GetFluentTheme() => new(sp);

AppBuilder.Configure<Application>()
    .UsePlatformDetect()
    .AfterSetup(b => b.Instance?.Styles.Add(GetFluentTheme()))
    .UseServiceProvider(sp)
    .SetupWithLifetime(lifetime);

lifetime.MainWindow = new Window()
    .Title("Avalonia Image tool app")
    .Content(new GenerateImageComponent());

lifetime.Start(args);