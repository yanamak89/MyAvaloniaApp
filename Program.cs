using Avalonia;
using System;

namespace MyAvaloniaApp;

/*
 *  Завдання 4
 * Створіть програму WPF Application, яка дозволяє користувачам
 * зберігати дані в ізольованому сховищі.
 *
 * Використання Avalonia UI для кросплатформеного графічного
 * інтерфейсу на маку.
 */
sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
