namespace WpfWatch
{
    using System;
    using System.Timers;
    using System.Windows.Controls;
    using System.Windows.Threading;

    /// <summary>
    /// Логика взаимодействия для Watch.xaml
    /// </summary>
    public partial class Watch : UserControl
    {
        /// <summary>
        /// Управление часами
        /// </summary>
        public Timer Timer = new Timer(1000);

        /// <inheritdoc />
        /// <summary>
        /// Стрелочные часы
        /// </summary>
        public Watch()
        {
            InitializeComponent();

            Timer.Elapsed += TimerElapsed;
            Timer.Enabled = true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var time = DateTime.Now;
            Dispatcher.Invoke(
                DispatcherPriority.Normal,
                (Action)(() =>
                                {
                                    // Положение секундной стрелки
                                    RotateSecond.Angle = 6 * (time.Second);

                                    // Положение минутной стрелки
                                    RotateMinute.Angle = 6 * time.Minute + RotateSecond.Angle / 60;

                                    // Положение часовой стрелки
                                    RotateHour.Angle =
                                        30 * (time.Hour % 12) + RotateMinute.Angle / 60;
                                }));
        }
    }
}
