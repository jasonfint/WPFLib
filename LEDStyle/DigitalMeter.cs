using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LEDStyle
{
    public class DigitalMeter : Canvas

    {

        private int numDigits;



        static DigitalMeter()

        {


            DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitalMeter), new FrameworkPropertyMetadata(typeof(DigitalMeter)));

        }



        public DigitalMeter()

        {

            UpdateControls();

        }



        public static readonly DependencyProperty FormatStringProperty =

            DependencyProperty.Register("FormatString", typeof(string), typeof(DigitalMeter), new PropertyMetadata("000.00", OnLayoutPropertyChanged));



        public string FormatString

        {

            get => (string)GetValue(FormatStringProperty);

            set => SetValue(FormatStringProperty, value);

        }



        public static readonly DependencyProperty BackColorProperty =

            DependencyProperty.Register("BackColor", typeof(Color), typeof(DigitalMeter), new PropertyMetadata(Color.FromArgb(0, 0, 0, 0), OnColorPropertyChanged));



        public Color BackColor

        {

            get { return (Color)GetValue(BackColorProperty); }

            set

            {

                SetValue(BackColorProperty, value);

            }

        }



        public static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor", typeof(Color), typeof(DigitalMeter), new PropertyMetadata(Color.FromRgb(255, 0, 0), OnColorPropertyChanged));



        public Color ForeColor
        {
            get => (Color)GetValue(ForeColorProperty);
            set { SetValue(ForeColorProperty, value); }
        }



        public static readonly DependencyProperty SignedProperty =
            DependencyProperty.Register("Signed", typeof(bool), typeof(DigitalMeter), new PropertyMetadata(false, OnLayoutPropertyChanged));



        public bool Signed
        {
            get { return (bool)GetValue(SignedProperty); }
            set { SetValue(SignedProperty, value); }

        }



        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(DigitalMeter), new PropertyMetadata(default(double), OnValuePropertyChanged));



        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }



        private static void OnLayoutPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is DigitalMeter meters))
                return;
            meters.UpdateControls();
        }



        private static void OnColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var meters = d as DigitalMeter;
            if (meters == null || meters.Children.Count < 1)
                return;
            foreach (var child in meters.Children)
            {
                if (!(child is DigitalDisplay disp))
                    continue;
                disp.BackColor =meters.BackColor;
                disp.ForeColor =meters.ForeColor;
            }
        }



        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var meters = d as DigitalMeter;
            if (meters == null)
                return;
            var str = meters.Value.ToString(meters.FormatString);
            str = str.Replace(".", string.Empty);
            str = str.Replace(",", string.Empty);
            var sign = false;
            if (str[0] == '-')
            {
                sign = true;
                str = str.TrimStart(new[] { '-' });
            }
            if (str.Length > meters.numDigits)
            {
                foreach (var child in meters.Children)
                {
                    if (child is DigitalDisplay disp) disp.Value = 'E';
                }
                return;
            }

            int idx;
            for (idx = str.Length - 1; idx >= 0; idx--)
            {
                var id = idx;
                if (meters.Signed)
                    id++;
                if (meters.Children[id] is DigitalDisplay disp) disp.Value = Convert.ToInt32(str[idx].ToString(CultureInfo.InvariantCulture));
            }



            var s = meters.Children[0] as DigitalDisplay;

            if (s != null && s.Name.Equals("digit_sign", StringComparison.CurrentCulture))
            {
                if (sign)
                    s.Value = '-';
                else
                    s.Value = -1;
            }
        }



        /// <summary>

        /// Update the controls of the meter

        /// </summary>

        private void UpdateControls()
        {
            string strFormat = FormatString;

            var count = strFormat.Length;

            var seps = new[] { '.', ',' };

            var sepIndex = strFormat.IndexOfAny(seps);

            if (sepIndex > 0)
            {
                count--;
                numDigits = count;
            }

            numDigits = count;
            Children.Clear();
            if (Signed)
            {
                var disp = new DigitalDisplay
                {
                    Name = "digit_sign",
                    Value = -1,
                    BackColor = BackColor,
                    ForeColor =ForeColor
                };

                Children.Add(disp);

            }



            for (var idx = 0; idx < count; idx++)
            {
                var disp = new DigitalDisplay
                {
                    Name = "digit_" + idx,
                    BackColor = BackColor,
                    ForeColor =ForeColor
                };

                if (sepIndex - 1 == idx)

                    disp.ShowDot = true;
                Children.Add(disp);
            }
            RepositionControls();

        }



        /// <summary>

        /// Reposition of the digital displaies

        /// </summary>

        private void RepositionControls()
        {
            if (Children.Count <= 0)
                return;

            var digitW = RenderSize.Width / Children.Count;
            var signFind = false;
            foreach (var disp in Children)
            {
                if (!(disp is DigitalDisplay d))
                    continue;
                var idDigit = 0;
                if (d.Name.Contains("digit_sign"))
                {
                    signFind = true;
                }

                else
                {
                    if (d.Name.Contains("digit_"))
                    {
                        var s = d.Name.Remove(0, 6);
                        idDigit = Convert.ToInt32(s);
                        if (signFind)
                            idDigit++;
                    }
                }
                               
                d.Width = digitW;
                d.Height = RenderSize.Height;
                SetLeft(d, idDigit * (digitW -0.5));
                SetTop(d, 0);
            }
            OnValuePropertyChanged(this, new DependencyPropertyChangedEventArgs(ValueProperty, 0,Value));
        }



        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            RepositionControls();
        }

    }



}
