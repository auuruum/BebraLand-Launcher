﻿using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Media;
using Avalonia.Reactive;

namespace GamerVII.Notification.Avalonia.Controls;

/// <summary>
/// The notification message control.
/// </summary>
/// <seealso cref="INotificationMessage" />
/// <seealso cref="Control" />
public class NotificationMessage : TemplatedControl, INotificationMessage, INotificationAnimation
{

    /// <summary>
    /// Gets or sets the content of the overlay.
    /// </summary>
    /// <value>
    /// The content of the overlay.
    /// </value>
    public object OverlayContent
    {
        get => GetValue(OverlayContentProperty);
        set => SetValue(OverlayContentProperty, value);
    }

    /// <summary>
    /// Gets or sets the content of the top additional content area.
    /// </summary>
    /// <value>
    /// The content of the top additional content area.
    /// </value>
    public object AdditionalContentTop
    {
        get => GetValue(AdditionalContentTopProperty);
        set => SetValue(AdditionalContentTopProperty, value);
    }

    /// <summary>
    /// Gets or sets the content of the bottom additional content area.
    /// </summary>
    /// <value>
    /// The content of the bottom additional content area.
    /// </value>
    public object AdditionalContentBottom
    {
        get => GetValue(AdditionalContentBottomProperty);
        set => SetValue(AdditionalContentBottomProperty, value);
    }

    /// <summary>
    /// Gets or sets the content of the left additional content area.
    /// </summary>
    /// <value>
    /// The content of the left additional content area.
    /// </value>
    public object AdditionalContentLeft
    {
        get => GetValue(AdditionalContentLeftProperty);
        set => SetValue(AdditionalContentLeftProperty, value);
    }

    /// <summary>
    /// Gets or sets the content of the right additional content area.
    /// </summary>
    /// <value>
    /// The content of the right additional content area.
    /// </value>
    public object AdditionalContentRight
    {
        get => GetValue(AdditionalContentRightProperty);
        set => SetValue(AdditionalContentRightProperty, value);
    }

    /// <summary>
    /// Gets or sets the content of the center additional content area.
    /// </summary>
    /// <value>
    /// The content of the center additional content area.
    /// </value>
    public object AdditionalContentMain
    {
        get => GetValue(AdditionalContentMainProperty);
        set => SetValue(AdditionalContentMainProperty, value);
    }

    /// <summary>
    /// Gets or sets the content of the top additional content area.
    /// </summary>
    /// <value>
    /// The content of the top additional content area.
    /// </value>
    public object AdditionalContentOverBadge
    {
        get => GetValue(AdditionalContentOverBadgeProperty);
        set => SetValue(AdditionalContentOverBadgeProperty, value);
    }


    /// <summary>
    /// Gets or sets the accent brush.
    /// </summary>
    /// <value>
    /// The accent brush.
    /// </value>
    public IBrush AccentBrush
    {
        get => GetValue(AccentBrushProperty);
        set => SetValue(AccentBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets the button accent brush.
    /// </summary>
    /// <value>
    /// The button accent brush.
    /// </value>
    public IBrush ButtonAccentBrush
    {
        get => GetValue(ButtonAccentBrushProperty);
        set => SetValue(ButtonAccentBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets the badge visibility.
    /// </summary>
    /// <value>
    /// The badge visibility.
    /// </value>
    public bool BadgeVisibility
    {
        get => GetValue(BadgeVisibilityProperty);
        set => SetValue(BadgeVisibilityProperty, value);
    }

    /// <summary>
    /// Gets or sets the badge accent brush.
    /// </summary>
    /// <value>
    /// The badge accent brush.
    /// </value>
    public IBrush BadgeAccentBrush
    {
        get => GetValue(BadgeAccentBrushProperty);
        set => SetValue(BadgeAccentBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets the badge text.
    /// </summary>
    /// <value>
    /// The badge text.
    /// </value>
    public string BadgeText
    {
        get => GetValue(BadgeTextProperty);
        set => SetValue(BadgeTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the header visibility.
    /// </summary>
    /// <value>
    /// The header visibility.
    /// </value>
    public bool HeaderVisibility
    {
        get => GetValue(HeaderVisibilityProperty);
        set => SetValue(HeaderVisibilityProperty, value);
    }

    /// <summary>
    /// Gets or sets the header.
    /// </summary>
    /// <value>
    /// The header.
    /// </value>
    public string Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    /// Gets or sets the message visibility.
    /// </summary>
    /// <value>
    /// The message visibility.
    /// </value>
    public bool MessageVisibility
    {
        get => GetValue(MessageVisibilityProperty);
        set => SetValue(MessageVisibilityProperty, value);
    }

    /// <summary>
    /// Gets or sets the buttons visibility.
    /// </summary>
    /// <value>
    /// The buttons visibility.
    /// </value>
    public bool ButtonsVisibility
    {
        get => GetValue(ButtonsVisibilityProperty);
        set => SetValue(ButtonsVisibilityProperty, value);
    }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    /// <value>
    /// The message.
    /// </value>
    public string Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <summary>
    /// Gets or sets the buttons.
    /// </summary>
    /// <value>
    /// The buttons.
    /// </value>
    public ObservableCollection<object> Buttons
    {
        get => GetValue(ButtonsProperty);
        set => SetValue(ButtonsProperty, value);
    }

    /// <summary>
    /// Gets or sets whether the message animates.
    /// </summary>
    /// <value>
    /// Whether or not the message animates.
    /// </value>
    public bool Animates
    {
        get => GetValue(AnimatesProperty);
        set => SetValue(AnimatesProperty, value);
    }


    /// <summary>
    /// Gets or sets start animation class
    /// </summary>
    public bool StartAnimation
    {
        get => GetValue(StartAnimationProperty);
        set => SetValue(StartAnimationProperty, value);
    }


    /// <summary>
    /// Gets or sets end animation class
    /// </summary>
    public bool DismissAnimation
    {
        get => GetValue(DismissAnimationProperty);
        set => SetValue(DismissAnimationProperty, value);
    }

    public static readonly StyledProperty<ICommand> CloseCommandProperty =
        AvaloniaProperty.Register<NotificationMessage, ICommand>(nameof(CloseCommand), new CloseCommand(CloseNotification));

    private static void CloseNotification(object parameter)
    {
        if (parameter is NotificationMessage message)
        {
            message.IsVisible = false;
        }
    }

    public ICommand CloseCommand
    {
        get => GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }


    /// <summary>
    /// The animatable element used for show/hide animations.
    /// </summary>
    public INotificationAnimation AnimatableElement => this;

    /// <summary>
    /// Hide animation class
    /// </summary>
    public static readonly StyledProperty<bool> DismissAnimationProperty =
        AvaloniaProperty.Register<NotificationMessage, bool>("DismissAnimation");

    /// <summary>
    /// Start animation class
    /// </summary>
    public static readonly StyledProperty<bool> StartAnimationProperty =
        AvaloniaProperty.Register<NotificationMessage, bool>("StartAnimation");

    /// <summary>
    /// The overlay content property.
    /// </summary>
    public static readonly StyledProperty<object> OverlayContentProperty =
        AvaloniaProperty.Register<NotificationMessage, object>("OverlayContent");

    /// <summary>
    /// The additional content top property.
    /// </summary>
    public static readonly StyledProperty<object> AdditionalContentTopProperty =
        AvaloniaProperty.Register<NotificationMessage, object>("AdditionalContentTop");

    /// <summary>
    /// The additional content bottom property.
    /// </summary>
    public static readonly StyledProperty<object> AdditionalContentBottomProperty =
        AvaloniaProperty.Register<NotificationMessage, object>("AdditionalContentBottom");

    /// <summary>
    /// The additional content left property.
    /// </summary>
    public static readonly StyledProperty<object> AdditionalContentLeftProperty =
        AvaloniaProperty.Register<NotificationMessage, object>("AdditionalContentLeft");

    /// <summary>
    /// The additional content right property.
    /// </summary>
    public static readonly StyledProperty<object> AdditionalContentRightProperty =
        AvaloniaProperty.Register<NotificationMessage, object>("AdditionalContentRight");

    /// <summary>
    /// The additional content main property.
    /// </summary>
    public static readonly StyledProperty<object> AdditionalContentMainProperty =
        AvaloniaProperty.Register<NotificationMessage, object>("AdditionalContentMain");

    /// <summary>
    /// The additional content over badge property.
    /// </summary>
    public static readonly StyledProperty<object> AdditionalContentOverBadgeProperty =
        AvaloniaProperty.Register<NotificationMessage, object>("AdditionalContentOverBadge");

    /// <summary>
    /// The accent brush property.
    /// </summary>
    public static readonly StyledProperty<IBrush> AccentBrushProperty =
        AvaloniaProperty.Register<NotificationMessage, IBrush>("AccentBrush");

    /// <summary>
    /// Accents the brush property changed callback.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="dependencyPropertyChangedEventArgs">The <see cref="dependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
    private static void AccentBrushPropertyChangedCallback(AvaloniaObject dependencyObject,
        AvaloniaPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        if (dependencyObject is not NotificationMessage @this)
            throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

        @this.BadgeAccentBrush ??= dependencyPropertyChangedEventArgs.NewValue as IBrush
                                   ?? throw new InvalidOperationException();

        @this.ButtonAccentBrush ??= dependencyPropertyChangedEventArgs.NewValue as IBrush
                                    ?? throw new InvalidOperationException();
    }

    /// <summary>
    /// The button accent brush property.
    /// </summary>
    public static readonly StyledProperty<IBrush> ButtonAccentBrushProperty =
        AvaloniaProperty.Register<NotificationMessage, IBrush>("ButtonAccentBrush");

    /// <summary>
    /// The badge visibility property.
    /// </summary>
    public static readonly StyledProperty<bool> BadgeVisibilityProperty =
        AvaloniaProperty.Register<NotificationMessage, bool>("BadgeVisibility");

    /// <summary>
    /// The badge accent brush property.
    /// </summary>
    public static readonly StyledProperty<IBrush> BadgeAccentBrushProperty =
        AvaloniaProperty.Register<NotificationMessage, IBrush>("BadgeAccentBrush");

    /// <summary>
    /// The badge text property.
    /// </summary>
    public static readonly StyledProperty<string> BadgeTextProperty =
        AvaloniaProperty.Register<NotificationMessage, string>("BadgeText");

    /// <summary>
    /// Badges the text property changed callback.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="dependencyPropertyChangedEventArgs">The <see cref="dependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
    private static void BadgeTextPropertyChangedCallback(AvaloniaObject dependencyObject,
        AvaloniaPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        if (dependencyObject is not NotificationMessage @this)
            throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

        @this.BadgeVisibility = dependencyPropertyChangedEventArgs.NewValue != null;
    }

    /// <summary>
    /// The header visibility property.
    /// </summary>
    public static readonly StyledProperty<bool> HeaderVisibilityProperty =
        AvaloniaProperty.Register<NotificationMessage, bool>("HeaderVisibility");

    /// <summary>
    /// The header property.
    /// </summary>
    public static readonly StyledProperty<string> HeaderProperty =
        AvaloniaProperty.Register<NotificationMessage, string>("Header");

    /// <summary>
    /// Headers the property changes callback.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="dependencyPropertyChangedEventArgs">The <see cref="dependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
    private static void HeaderPropertyChangesCallback(AvaloniaObject dependencyObject,
        AvaloniaPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        if (dependencyObject is not NotificationMessage @this)
            throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

        @this.HeaderVisibility = dependencyPropertyChangedEventArgs.NewValue != null;
    }

    /// <summary>
    /// Buttons the property changes callback.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="dependencyPropertyChangedEventArgs">The <see cref="dependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
    private static void ButtonsPropertyChangesCallback(AvaloniaObject dependencyObject, AvaloniaPropertyChangedEventArgs<ObservableCollection<object>> dependencyPropertyChangedEventArgs)
    {
        if (dependencyObject is not NotificationMessage @this)
            throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

        if (dependencyPropertyChangedEventArgs.NewValue.Value.Count > 0)
        {
            @this.ButtonsVisibility = true;
        }

        @this.ButtonsVisibility = false;
    }

    /// <summary>
    /// The message visibility property.
    /// </summary>
    public static readonly StyledProperty<bool> MessageVisibilityProperty =
        AvaloniaProperty.Register<NotificationMessage, bool>("MessageVisibility");

    /// <summary>
    /// The buttons visibility property.
    /// </summary>
    public static readonly StyledProperty<bool> ButtonsVisibilityProperty =
        AvaloniaProperty.Register<NotificationMessage, bool>("ButtonsVisibilityProperty");

    /// <summary>
    /// The message property.
    /// </summary>
    public static readonly StyledProperty<string> MessageProperty =
        AvaloniaProperty.Register<NotificationMessage, string>("Message");

    /// <summary>
    /// Messages the property changes callback.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="dependencyPropertyChangedEventArgs">The <see cref="dependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
    private static void MessagePropertyChangesCallback(AvaloniaObject dependencyObject,
        AvaloniaPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        if (!(dependencyObject is NotificationMessage @this))
            throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

        @this.MessageVisibility = dependencyPropertyChangedEventArgs.NewValue != null;
    }

    /// <summary>
    /// The buttons property.
    /// </summary>
    public static readonly StyledProperty<ObservableCollection<object>> ButtonsProperty =
        AvaloniaProperty.Register<NotificationMessage, ObservableCollection<object>>("Buttons");

    /// <summary>
    /// The animates property.
    /// </summary>
    public static readonly StyledProperty<bool> AnimatesProperty =
        AvaloniaProperty.Register<NotificationMessage, bool>("Animates");

    /// <summary>
    /// Initializes the <see cref="NotificationMessage" /> class.
    /// </summary>
    static NotificationMessage()
    {
        AccentBrushProperty.Changed.Subscribe(
            new AnonymousObserver<AvaloniaPropertyChangedEventArgs<IBrush>>(x =>
                AccentBrushPropertyChangedCallback(x.Sender, x)));

        BadgeTextProperty.Changed.Subscribe(
            new AnonymousObserver<AvaloniaPropertyChangedEventArgs<string>>(x =>
                BadgeTextPropertyChangedCallback(x.Sender, x)));

        MessageProperty.Changed.Subscribe(
            new AnonymousObserver<AvaloniaPropertyChangedEventArgs<string>>(x =>
                MessagePropertyChangesCallback(x.Sender, x)));

        HeaderProperty.Changed.Subscribe(
            new AnonymousObserver<AvaloniaPropertyChangedEventArgs<string>>(x =>
                HeaderPropertyChangesCallback(x.Sender, x)));

        ButtonsProperty.Changed.Subscribe(
            new AnonymousObserver<AvaloniaPropertyChangedEventArgs<ObservableCollection<object>>>(x =>
                ButtonsPropertyChangesCallback(x.Sender, x)));


        //TODO what is this
        // DefaultStyleKeyProperty.OverrideMetadata(typeof(NotificationMessage), new FrameworkPropertyMetadata(typeof(NotificationMessage)));
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationMessage" /> class.
    /// </summary>
    /// <param name="notificationMessageBuilder"></param>
    public NotificationMessage()
    {
        this.Buttons = new ObservableCollection<object>();
        Background = new SolidColorBrush(new Color(100, 0, 0, 0));

        this.Foreground = new BrushConverter().ConvertFromString("#DDDDDD") as IBrush;
        this.Classes.Add("notificationMessage");
    }
}
