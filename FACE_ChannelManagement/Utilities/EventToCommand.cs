using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FACE_ChannelManagement.Utilities
{
    public class EventToCommand : System.Windows.Interactivity.TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventToCommand), new PropertyMetadata((object)null, (PropertyChangedCallback)((s, e) =>
        {
            EventToCommand eventToCommand = s as EventToCommand;
            if (eventToCommand == null || eventToCommand.AssociatedObject == null)
                return;
            eventToCommand.EnableDisableElement();
        })));
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(EventToCommand), new PropertyMetadata((object)null, (PropertyChangedCallback)((s, e) => EventToCommand.OnCommandChanged(s as EventToCommand, e))));
        public static readonly DependencyProperty MustToggleIsEnabledProperty = DependencyProperty.Register("MustToggleIsEnabled", typeof(bool), typeof(EventToCommand), new PropertyMetadata((object)false, (PropertyChangedCallback)((s, e) =>
        {
            EventToCommand eventToCommand = s as EventToCommand;
            if (eventToCommand == null || eventToCommand.AssociatedObject == null)
                return;
            eventToCommand.EnableDisableElement();
        })));
        public static readonly DependencyProperty EventArgsConverterParameterProperty = DependencyProperty.Register("EventArgsConverterParameter", typeof(object), typeof(EventToCommand), new PropertyMetadata((PropertyChangedCallback)null));
        public const string EventArgsConverterParameterPropertyName = "EventArgsConverterParameter";
        private object _commandParameterValue;
        private bool? _mustToggleValue;

        public ICommand Command
        {
            get
            {
                return (ICommand)this.GetValue(EventToCommand.CommandProperty);
            }
            set
            {
                this.SetValue(EventToCommand.CommandProperty, (object)value);
            }
        }

        public object CommandParameter
        {
            get
            {
                return this.GetValue(EventToCommand.CommandParameterProperty);
            }
            set
            {
                this.SetValue(EventToCommand.CommandParameterProperty, value);
            }
        }

        public object CommandParameterValue
        {
            get
            {
                return this._commandParameterValue ?? this.CommandParameter;
            }
            set
            {
                this._commandParameterValue = value;
                this.EnableDisableElement();
            }
        }

        public bool MustToggleIsEnabled
        {
            get
            {
                return (bool)this.GetValue(EventToCommand.MustToggleIsEnabledProperty);
            }
            set
            {
                this.SetValue(EventToCommand.MustToggleIsEnabledProperty, (object)value);
            }
        }

        public bool MustToggleIsEnabledValue
        {
            get
            {
                if (this._mustToggleValue.HasValue)
                    return this._mustToggleValue.Value;
                return this.MustToggleIsEnabled;
            }
            set
            {
                this._mustToggleValue = new bool?(value);
                this.EnableDisableElement();
            }
        }

        public bool PassEventArgsToCommand { get; set; }

        public IEventArgsConverter EventArgsConverter { get; set; }

        public object EventArgsConverterParameter
        {
            get
            {
                return this.GetValue(EventToCommand.EventArgsConverterParameterProperty);
            }
            set
            {
                this.SetValue(EventToCommand.EventArgsConverterParameterProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.EnableDisableElement();
        }

        private FrameworkElement GetAssociatedObject()
        {
            return this.AssociatedObject as FrameworkElement;
        }

        private ICommand GetCommand()
        {
            return this.Command;
        }

        public void Invoke()
        {
            this.Invoke((object)null);
        }

        protected override void Invoke(object parameter)
        {
            if (this.AssociatedElementIsDisabled())
                return;
            ICommand command = this.GetCommand();
            object parameter1 = this.CommandParameterValue;
            if (parameter1 == null && this.PassEventArgsToCommand)
                parameter1 = this.EventArgsConverter == null ? parameter : this.EventArgsConverter.Convert(parameter, this.EventArgsConverterParameter);
            if (command == null || !command.CanExecute(parameter1))
                return;
            command.Execute(parameter1);
        }

        private static void OnCommandChanged(EventToCommand element, DependencyPropertyChangedEventArgs e)
        {
            if (element == null)
                return;
            if (e.OldValue != null)
                ((ICommand)e.OldValue).CanExecuteChanged -= new EventHandler(element.OnCommandCanExecuteChanged);
            ICommand newValue = (ICommand)e.NewValue;
            if (newValue != null)
                newValue.CanExecuteChanged += new EventHandler(element.OnCommandCanExecuteChanged);
            element.EnableDisableElement();
        }

        private bool AssociatedElementIsDisabled()
        {
            FrameworkElement associatedObject = this.GetAssociatedObject();
            if (this.AssociatedObject == null)
                return true;
            if (associatedObject != null)
                return !associatedObject.IsEnabled;
            return false;
        }

        private void EnableDisableElement()
        {
            FrameworkElement associatedObject = this.GetAssociatedObject();
            if (associatedObject == null)
                return;
            ICommand command = this.GetCommand();
            if (!this.MustToggleIsEnabledValue || command == null)
                return;
            associatedObject.IsEnabled = command.CanExecute(this.CommandParameterValue);
        }

        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            this.EnableDisableElement();
        }
    }

    public interface IEventArgsConverter
    {
        object Convert(object value, object parameter);
    }
}
