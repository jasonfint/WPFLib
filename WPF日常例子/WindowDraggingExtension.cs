using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF日常例子
{
    /// <summary>
    /// 窗口拖拽的附加方法
    /// </summary>
    public class WindowDraggingExtension
    {
        /// <summary>
        /// 表示元素作为附加某个窗口提供拖拽的功能
        /// </summary>
        public static readonly DependencyProperty DragWindowProperty = DependencyProperty.RegisterAttached(
            "DragWindow", typeof(WindowDraggingExtension), typeof(WindowDraggingExtension),
            new PropertyMetadata(default(WindowDraggingExtension),
                new PropertyChangedCallback(OnDragWindowPropertyChanged)));

        private static void OnDragWindowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // 仅有设置，不会存在多次设置，也没有反过来
            if (e.NewValue is WindowDraggingExtension windowDragging && d is UIElement element)
            {
                InputHelper.AttachMouseDownMoveUpToClick(element,
                    delegate { windowDragging.DraggingElementClicked?.Invoke(null, EventArgs.Empty); }, delegate
                    {
                        if (Mouse.LeftButton == MouseButtonState.Pressed)
                        {
                            var targetWindow = windowDragging.TargetWindow
                                               ?? Window.GetWindow(element);

                            targetWindow?.DragMove();
                        }
                    });
            }
        }

        /// <summary>
        /// 设置元素作为窗口的拖拽元素
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetDragWindow(DependencyObject element, WindowDraggingExtension value)
        {
            element.SetValue(DragWindowProperty, value);
        }

        /// <summary>
        /// 获取元素作为窗口拖拽属性
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static WindowDraggingExtension GetDragWindow(DependencyObject element)
        {
            return (WindowDraggingExtension)element.GetValue(DragWindowProperty);
        }

        /// <summary>
        /// 附加的拖动的窗口，提供此属性仅仅是为了提升性能，可以不设置。如不设置将使用 Window.GetWindow 方法获取当前元素所在窗口
        /// </summary>
        public Window TargetWindow { set; get; }

        /// <summary>
        /// 拖动的元素实际是被点击时触发
        /// </summary>
        public event EventHandler DraggingElementClicked;
    }
}
