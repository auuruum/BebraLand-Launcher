﻿using Avalonia.Media;

// ReSharper disable UnusedMember.Global
// ReSharper disable RedundantEmptySwitchSection

namespace GamerVII.Notification.Avalonia;

/// <summary>
/// The notification message builder LINQ helper.
/// </summary>
public static class NotificationMessageBuilderLinq
{
    /// <summary>
    /// Sets the notification message background.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="backgroundBrush">The background brush.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder Background(
        this NotificationMessageBuilder builder,
        IBrush backgroundBrush)
    {
        builder.SetBackground(backgroundBrush);

        return builder;
    }

    public static NotificationMessageBuilder Foreground(
        this NotificationMessageBuilder builder,
        string foregroundBrush)
    {
        var brush = new BrushConverter().ConvertFrom(foregroundBrush) as IBrush;
        builder.SetForeground(brush);

        return builder;
    }

    /// <summary>
    /// Sets the notification message background.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="backgroundBrush">The background brush.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder Background(
        this NotificationMessageBuilder builder,
        string backgroundBrush)
    {
        var brush = new BrushConverter().ConvertFrom(backgroundBrush) as IBrush;
        builder.SetBackground(brush);

        return builder;
    }

    /// <summary>
    /// Sets the notification message accent.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="accentBrush">The accent brush.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder Accent(
        this NotificationMessageBuilder builder,
        IBrush accentBrush)
    {
        builder.SetAccent(accentBrush);

        return builder;
    }

    /// <summary>
    /// Sets the notification message accent.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="accentBrush">The accent brush.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder Accent(
        this NotificationMessageBuilder builder,
        string accentBrush)
    {
        var brush = new BrushConverter().ConvertFrom(accentBrush) as IBrush;
        builder.SetAccent(brush);

        return builder;
    }

    /// <summary>
    /// Sets the badge text.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="badgeText">The badge text.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder HasBadge(
        this NotificationMessageBuilder builder,
        string badgeText)
    {
        builder.SetBadge(badgeText);

        return builder;
    }

    /// <summary>
    /// Sets the message header text.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="header">The header text.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder HasHeader(
        this NotificationMessageBuilder builder,
        string header)
    {
        builder.SetHeader(header);

        return builder;
    }

    /// <summary>
    /// Sets the message text.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="message">The message text.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder HasMessage(
        this NotificationMessageBuilder builder,
        string message)
    {
        builder.SetMessage(message);

        return builder;
    }

    /// <summary>
    /// Creates the message.
    /// </summary>
    /// <param name="manager">The manager.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder CreateMessage(
        this INotificationMessageManager manager)
    {
        var builder = NotificationMessageBuilder.CreateMessage();
        builder.Manager = manager;
        builder.Message = manager.Factory.GetMessage();

        return builder;
    }



    public static NotificationMessageBuilder CreateMessage(this INotificationMessageManager manager, bool animations, string background, string title, string content)
    {
        var builder = NotificationMessageBuilder.CreateMessage();
        builder.Manager = manager;
        builder.Message = manager.Factory.GetMessage();
        builder.Animates(animations);
        builder.HasHeader(title);
        builder.Background(background);
        builder.HasMessage(content);

        return builder;
    }

    /// <summary>
    /// Marks next button to be dismiss.
    /// This button will dismiss the notification message when clicked.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder.DismissNotificationMessage Dismiss(
        this NotificationMessageBuilder builder)
    {
        return new NotificationMessageBuilder.DismissNotificationMessage(builder);
    }

    /// <summary>
    /// Dismisses the notification message after specified time.
    /// </summary>
    /// <param name="dismiss">The dismiss.</param>
    /// <param name="delayMilliseconds">The delay in milliseconds.</param>
    /// <param name="callback">The callback.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder WithDelay(
        this NotificationMessageBuilder.DismissNotificationMessage dismiss,
        int delayMilliseconds,
        Action<INotificationMessage> callback = null)
    {
        dismiss.Builder.Delay(delayMilliseconds, dismiss.Builder.DismissBefore(callback));

        return dismiss.Builder;
    }

    /// <summary>
    /// Withes the delay.
    /// </summary>
    /// <param name="dismiss">The dismiss.</param>
    /// <param name="delay">The delay.</param>
    /// <param name="callback">The callback.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder WithDelay(
        this NotificationMessageBuilder.DismissNotificationMessage dismiss,
        TimeSpan delay,
        Action<INotificationMessage> callback = null)
    {
        dismiss.Builder.Delay(delay, dismiss.Builder.DismissBefore(callback));

        return dismiss.Builder;
    }

    /// <summary>
    /// Adds the button to the notification message.
    /// </summary>
    /// <param name="dismiss">The dismiss.</param>
    /// <param name="content">The content.</param>
    /// <param name="callback">The callback.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder WithButton(
        this NotificationMessageBuilder.DismissNotificationMessage dismiss,
        object content,
        Action<INotificationMessageButton> callback)
    {
        return dismiss.Builder.WithButton(content, dismiss.Builder.DismissBefore(callback));
    }

    /// <summary>
    /// Adds the button to the notification message.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="content">The content.</param>
    /// <param name="callback">The callback.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder WithButton(
        this NotificationMessageBuilder builder,
        object content,
        Action<INotificationMessageButton> callback)
    {
        var button = builder.Manager.Factory.GetButton();
        button.Callback = callback;
        button.Content = content;

        builder.AddButton(button);

        return builder;
    }

    /// <summary>
    /// Attaches the dismiss action before callback action.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="callback">The callback.</param>
    /// <returns>
    /// Returns the action that will call manager dismiss for notification
    /// message builder when called and then call the callback action.
    /// </returns>
    private static Action<INotificationMessage> DismissBefore(
        this NotificationMessageBuilder builder,
        Action<INotificationMessage> callback)
    {
        return call =>
        {
            builder.Manager.Dismiss(builder.Message);
            callback?.Invoke(builder.Message);
        };
    }

    /// <summary>
    /// Attached the dismiss action before callback action.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="callback">The callback.</param>
    /// <returns>
    /// Returns the action that will call manager dismiss for notification
    /// message in builder when button is clicked and then call the callback action.
    /// </returns>
    private static Action<INotificationMessageButton> DismissBefore(
        this NotificationMessageBuilder builder,
        Action<INotificationMessageButton> callback)
    {
        return button =>
        {
            builder.Manager.Dismiss(builder.Message);
            callback?.Invoke(button);
        };
    }

    /// <summary>
    /// Sets the notification message overlay.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="overlay">The overlay.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder WithOverlay(
        this NotificationMessageBuilder builder,
        object overlay)
    {
        builder.SetOverlay(overlay);

        return builder;
    }

    /// <summary>
    /// Sets the notification message top additional content.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="additionalContent">The additional content.</param>
    /// <param name="contentLocation">The location of the content.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder WithAdditionalContent(
        this NotificationMessageBuilder builder,
        ContentLocation contentLocation,
        object additionalContent)
    {
        switch (contentLocation)
        {
            case ContentLocation.Top:
            {
                builder.SetAdditionalContentTop(additionalContent);
                break;
            }
            case ContentLocation.Bottom:
            {
                builder.SetAdditionalContentBottom(additionalContent);
                break;
            }
            case ContentLocation.Left:
            {
                builder.SetAdditionalContentLeft(additionalContent);
                break;
            }
            case ContentLocation.Right:
            {
                builder.SetAdditionalContentRight(additionalContent);
                break;
            }
            case ContentLocation.Main:
            {
                builder.SetAdditionalContentMain(additionalContent);
                break;
            }
            case ContentLocation.AboveBadge:
            {
                builder.SetAdditionalContentOverBadge(additionalContent);
                break;
            }
            default:
            {
                break;
            }
        }


        return builder;
    }

    //TODO
    /*/// <summary>
    /// Sets the foreground brush.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="foregroundBrush">The foreground brush.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder Foreground(
        this NotificationMessageBuilder builder,
        string foregroundBrush)
    {
        var brush = new BrushConverter().ConvertFrom(foregroundBrush) as Brush;
        //builder.SetForeground(brush);

        return builder;
    }*/

    /// <summary>
    /// Sets whether or not the message animates.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="animates">Whether or not the message should animate.</param>
    /// <returns>Returns the notification message builder.</returns>
    public static NotificationMessageBuilder Animates(
        this NotificationMessageBuilder builder,
        bool animates)
    {
        builder.SetAnimates(animates);

        return builder;
    }
}
