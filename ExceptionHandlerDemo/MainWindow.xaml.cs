using Handlers;
using System.Windows;

namespace ExceptionHandlerDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }



    private void Button_Click1(object sender, RoutedEventArgs e)
    {
        throw new SampleException();
    }

    private void Button_Click2(object sender, RoutedEventArgs e)
    {
        throw new InvalidOperationException("一些非法操作！！！！");

    }

    private void Button_Click3(object sender, RoutedEventArgs e)
    {

        throw new NotImplementedException("吊毛、你的成员没有去实现！！！这种异常不应该处理，这是程序员的错误！！！");
    }

    private void Button_Click4(object sender, RoutedEventArgs e)
    {
        throw new Sample222222222Exception();

    }
}