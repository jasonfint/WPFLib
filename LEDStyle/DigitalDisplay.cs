using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LEDStyle
{


    public class DigitalDisplay : FrameworkElement
    {

        #region Constants
        public const int WIDTH_PIXEL = 11;
        public const int HEIGHT_PIXELS = 18;
        #endregion



        #region Constructors
        static DigitalDisplay()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitalDisplay), new FrameworkPropertyMetadata(typeof(DigitalDisplay)));
            CreateSegmetsData();
            CreateDefPointsCoordinates();
            CreateSegmentsValuesList();
        }



        #endregion



        #region Private Variables

        /// <summary>

        /// Segments data array

        /// </summary>

        private static readonly SegmentDictionary Segments = new SegmentDictionary();

        /// <summary>

        /// Defaults points coordinates

        /// </summary>

        private static readonly PointsList DefPoints = new PointsList();

        /// <summary>

        /// Segments list of a value

        /// </summary>

        private static readonly SegmentsValueDictionary ValuesSegments = new SegmentsValueDictionary();



        #endregion



        #region Dependency Properties



        private static void OnDisplayPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var digital = d as DigitalDisplay;
            if (digital != null)
                digital.InvalidateVisual();
        }



        public static readonly DependencyProperty ValueProperty =  DependencyProperty.Register("Value", typeof(int), typeof(DigitalDisplay), new PropertyMetadata(0, OnDisplayPropertyChanged));



        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }



        public static readonly DependencyProperty ShowDotProperty =  DependencyProperty.Register("ShowDot", typeof(bool), typeof(DigitalDisplay), new PropertyMetadata(false, OnDisplayPropertyChanged));



        public bool ShowDot
        {
            get { return (bool)GetValue(ShowDotProperty); }
            set { SetValue(ShowDotProperty, value); }
        }



        public static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor", typeof(Color), typeof(DigitalDisplay), new PropertyMetadata(Color.FromRgb(255, 0, 0), OnDisplayPropertyChanged));



        public Color ForeColor
        {
            get { return (Color)GetValue(ForeColorProperty); }
            set { SetValue(ForeColorProperty, value); }
        }



        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor", typeof(Color), typeof(DigitalDisplay), new PropertyMetadata(Color.FromRgb(0, 0, 0), OnDisplayPropertyChanged));



        public Color BackColor
        {
            get { return (Color)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }



        #endregion



        #region Static Methods



        /// <summary>

        /// Creation of the default points list of the

        /// all segments

        /// </summary>

        private static void CreateDefPointsCoordinates()
        {

            var pt = new Point(3F, 1F);

            DefPoints.Add(pt);

            pt = new Point(8F, 1F);

            DefPoints.Add(pt);

            pt = new Point(9F, 2F);

            DefPoints.Add(pt);

            pt = new Point(10F, 3F);

            DefPoints.Add(pt);

            pt = new Point(10F, 8F);

            DefPoints.Add(pt);

            pt = new Point(9F, 9F);

            DefPoints.Add(pt);

            pt = new Point(10F, 10F);

            DefPoints.Add(pt);

            pt = new Point(10F, 15F);

            DefPoints.Add(pt);

            pt = new Point(9F, 16F);

            DefPoints.Add(pt);

            pt = new Point(8F, 17F);

            DefPoints.Add(pt);

            pt = new Point(3F, 17F);

            DefPoints.Add(pt);

            pt = new Point(2F, 16F);

            DefPoints.Add(pt);

            pt = new Point(1F, 15F);

            DefPoints.Add(pt);

            pt = new Point(1F, 10F);

            DefPoints.Add(pt);

            pt = new Point(2F, 9F);

            DefPoints.Add(pt);

            pt = new Point(1F, 8F);

            DefPoints.Add(pt);

            pt = new Point(1F, 3F);

            DefPoints.Add(pt);

            pt = new Point(2F, 2F);

            DefPoints.Add(pt);

            pt = new Point(3F, 3F);

            DefPoints.Add(pt);

            pt = new Point(8F, 3F);

            DefPoints.Add(pt);

            pt = new Point(8F, 8F);

            DefPoints.Add(pt);

            pt = new Point(8F, 10F);

            DefPoints.Add(pt);

            pt = new Point(8F, 15F);

            DefPoints.Add(pt);

            pt = new Point(3F, 15F);

            DefPoints.Add(pt);

            pt = new Point(3F, 10F);

            DefPoints.Add(pt);

            pt = new Point(3F, 8F);

            DefPoints.Add(pt);

        }



        /// <summary>

        /// Create the dictionary of the

        /// segment coordinates

        /// </summary>

        private static void CreateSegmetsData()
        {
            Segments.Clear();
            var s = new Segment();
            s.PointsIndexs[0] = 0;

            s.PointsIndexs[1] = 1;

            s.PointsIndexs[2] = 2;

            s.PointsIndexs[3] = 19;

            s.PointsIndexs[4] = 18;

            s.PointsIndexs[5] = 17;

            Segments.Add('A', s);



            s = new Segment();

            s.PointsIndexs[0] = 2;

            s.PointsIndexs[1] = 3;

            s.PointsIndexs[2] = 4;

            s.PointsIndexs[3] = 5;

            s.PointsIndexs[4] = 20;

            s.PointsIndexs[5] = 19;

            Segments.Add('B', s);



            s = new Segment();

            s.PointsIndexs[0] = 6;

            s.PointsIndexs[1] = 7;

            s.PointsIndexs[2] = 8;

            s.PointsIndexs[3] = 22;

            s.PointsIndexs[4] = 21;

            s.PointsIndexs[5] = 5;

            Segments.Add('C', s);



            s = new Segment();

            s.PointsIndexs[0] = 9;

            s.PointsIndexs[1] = 10;

            s.PointsIndexs[2] = 11;

            s.PointsIndexs[3] = 23;

            s.PointsIndexs[4] = 22;

            s.PointsIndexs[5] = 8;

            Segments.Add('D', s);



            s = new Segment();

            s.PointsIndexs[0] = 12;

            s.PointsIndexs[1] = 13;

            s.PointsIndexs[2] = 14;

            s.PointsIndexs[3] = 24;

            s.PointsIndexs[4] = 23;

            s.PointsIndexs[5] = 11;

            Segments.Add('E', s);



            s = new Segment();

            s.PointsIndexs[0] = 15;

            s.PointsIndexs[1] = 16;

            s.PointsIndexs[2] = 17;

            s.PointsIndexs[3] = 18;

            s.PointsIndexs[4] = 25;

            s.PointsIndexs[5] = 14;

            Segments.Add('F', s);



            s = new Segment();

            s.PointsIndexs[0] = 25;

            s.PointsIndexs[1] = 20;

            s.PointsIndexs[2] = 5;

            s.PointsIndexs[3] = 21;

            s.PointsIndexs[4] = 24;

            s.PointsIndexs[5] = 14;

            Segments.Add('G', s);

        }



        /// <summary>

        /// Create the dictionary of the segments

        /// for the number values

        /// </summary>

        private static void CreateSegmentsValuesList()
        {

            var list = new SegmentsList { 'A', 'B', 'C', 'D', 'E', 'F' };

            ValuesSegments.Add(0, list);



            list = new SegmentsList { 'B', 'C' };

            ValuesSegments.Add(1, list);



            list = new SegmentsList { 'A', 'B', 'G', 'E', 'D' };

            ValuesSegments.Add(2, list);



            list = new SegmentsList { 'A', 'B', 'G', 'C', 'D' };

            ValuesSegments.Add(3, list);



            list = new SegmentsList { 'F', 'G', 'B', 'C' };

            ValuesSegments.Add(4, list);



            list = new SegmentsList { 'A', 'F', 'G', 'C', 'D' };

            ValuesSegments.Add(5, list);



            list = new SegmentsList { 'A', 'F', 'G', 'C', 'D', 'E' };

            ValuesSegments.Add(6, list);



            list = new SegmentsList { 'A', 'B', 'C' };

            ValuesSegments.Add(7, list);



            list = new SegmentsList { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

            ValuesSegments.Add(8, list);



            list = new SegmentsList { 'A', 'B', 'C', 'D', 'F', 'G' };

            ValuesSegments.Add(9, list);



            list = new SegmentsList { 'G' };

            ValuesSegments.Add('-', list);



            list = new SegmentsList { 'A', 'D', 'E', 'F', 'G' };

            ValuesSegments.Add('E', list);

        }



        #endregion



        #region Override Render Logic



        protected override void OnRender(DrawingContext drawingContext)

        {

            double rappW = ActualWidth / WIDTH_PIXEL;

            double rappH = ActualHeight / HEIGHT_PIXELS;



            var dotLocation = new Point

            {

                X = DefPoints[7].X * rappW,

                Y = DefPoints[8].Y * rappH +0.5 * rappH,

            };

            var dotRadiusX = rappW * .8;

            var dotRadiusY = rappH * .8;



            var pth = new StreamGeometry();

            using (var sc = pth.Open())

            {

                foreach (Segment seg in Segments.Values)

                {

                    for (var idx = 0; idx < seg.PointsIndexs.Length; idx++)

                    {

                        var tmpPoint =DefPoints[seg.PointsIndexs[idx]];

                        if (idx == 0)

                            sc.BeginFigure(new Point(tmpPoint.X * rappW,tmpPoint.Y * rappH), true, true);

                        else

                            sc.LineTo(new Point(tmpPoint.X * rappW,tmpPoint.Y * rappH), false, false);

                    }

                }

            }

            pth.Freeze();

            drawingContext.DrawRectangle(new SolidColorBrush(BackColor), null, new Rect(0, 0, ActualWidth,ActualHeight));

            var offColor = ForeColor;

            offColor.A = 50;

            var offBrush = new SolidColorBrush(offColor);


            drawingContext.DrawGeometry(offBrush, null, pth);


            drawingContext.DrawEllipse(offBrush, null, dotLocation, dotRadiusX, dotRadiusY);

            if (ValuesSegments.Contains(Value))
            {
                var pth2 = new StreamGeometry();

                var list = ValuesSegments[Value];

                using (var sc = pth2.Open())
                {
                    foreach (var ch in list)
                    {
                        var seg = Segments[ch];
                        if (seg == null)
                            continue;
                        for (var idx = 0; idx <seg.PointsIndexs.Length; idx++)
                        {
                            var tmpPoint =DefPoints[seg.PointsIndexs[idx]];
                            if (idx == 0)
                                sc.BeginFigure(new Point(tmpPoint.X * rappW,tmpPoint.Y * rappH), true, true);
                            else
                                sc.LineTo(new Point(tmpPoint.X * rappW,tmpPoint.Y * rappH), false, false);
                        }

                    }

                }

                pth2.Freeze();

                var onBrush = new SolidColorBrush(ForeColor);


                drawingContext.DrawGeometry(onBrush, null, pth2);

                if (ShowDot)


                    drawingContext.DrawEllipse(onBrush, null, dotLocation, dotRadiusX, dotRadiusY);

            }

        }



        #endregion

    }



    #region Classes Used By DigitalDisplay



    /// <summary>

    /// Dictionary for the segment associated

    /// to the number

    /// </summary>

    public class SegmentDictionary : DictionaryBase
    {
        public Segment this[char ch]
        {

            set
            {
                if (Dictionary.Contains(ch) == false)
                    Add(ch, value);
                else
                    Dictionary[ch] = value;
            }

            get
            {
                if (Dictionary.Contains(ch) == false)
                    return null;
                return (Segment)Dictionary[ch];
            }

        }



        public void Add(char ch, Segment seg)
        {
            if (Contains(ch) == false)
                Dictionary.Add(ch, seg);
            else
                this[ch] = seg;
        }



        public bool Contains(char ch)

        {

            return Dictionary.Contains(ch);

        }



        public ICollection Values

        {

            get { return Dictionary.Values; }

        }



        public ICollection Keys

        {

            get { return Dictionary.Keys; }

        }

    }



    /// <summary>

    /// Class for the segment data

    /// </summary>

    public class Segment

    {
        private readonly int[] points = new int[6];

        public int[] PointsIndexs
        {
            get { return points; }
        }

    }



    /// <summary>

    /// Points list

    /// </summary>

    public class PointsList : List<Point>
    {
    }



    /// <summary>

    /// Segments list

    /// </summary>

    public class SegmentsList : List<char>
    {
    }



    /// <summary>

    /// Dictionary for value to segments

    /// </summary>

    public class SegmentsValueDictionary : DictionaryBase
    {
        public SegmentsList this[int num]
        {
            set
            {
                if (Dictionary.Contains(num) == false)
                    Add(num, value);
                else
                    Dictionary[num] = value;
            }
            get
            {
                if (Dictionary.Contains(num) == false)
                    return null;
                return (SegmentsList)Dictionary[num];
            }

        }



        public void Add(int num, SegmentsList seg)
        {
            if (Contains(num) == false)
                Dictionary.Add(num, seg);
            else
                this[num] = seg;
        }



        public bool Contains(int ch)
        {
            return Dictionary.Contains(ch);
        }



        public ICollection Values
        {
            get { return Dictionary.Values; }
        }



        public ICollection Keys
        {
            get { return Dictionary.Keys; }
        }

    }
    #endregion
}
