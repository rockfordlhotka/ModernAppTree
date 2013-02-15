using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ModernAppTree
{
  /// <summary>
  /// A basic page that provides characteristics common to most applications.
  /// </summary>
  public sealed partial class StartPage : ModernAppTree.Common.LayoutAwarePage
  {
    public StartPage()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Populates the page with content passed during navigation.  Any saved state is also
    /// provided when recreating a page from a prior session.
    /// </summary>
    /// <param name="navigationParameter">The parameter value passed to
    /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
    /// </param>
    /// <param name="pageState">A dictionary of state preserved by this page during an earlier
    /// session.  This will be null the first time a page is visited.</param>
    protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
      if (navigationParameter == null || navigationParameter.ToString() == string.Empty)
        InitRoot();
      else
        _root = (QuestionInfo)navigationParameter;
      DataContext = _root;
      YesButton.Visibility = (_root.YesAnswer == null) ? Windows.UI.Xaml.Visibility.Collapsed : Windows.UI.Xaml.Visibility.Visible;
      NoButton.Visibility = (_root.NoAnswer == null) ? Windows.UI.Xaml.Visibility.Collapsed : Windows.UI.Xaml.Visibility.Visible;
      SmileIcon.Visibility = (_root.YesAnswer == null && _root.NoAnswer == null) ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
    }

    private QuestionInfo _root;

    private void InitRoot()
    {
      var controlDevice = new QuestionInfo
      {
        Title = "Device control",
        Question = "Do you control the type of device being used?",
        YesAnswer = new QuestionInfo
        {
          Title = "Microsoft shop",
          Question = "Are you a Microsoft dev shop?",
          YesAnswer = new QuestionInfo
          {
            Title = "Final answer",
            Question = "Windows 8 and Windows Runtime (WinRT) are right for you!"
          },
          NoAnswer = new QuestionInfo
          {
            Title = "Java shop",
            Question = "Are you a Java dev shop?",
            YesAnswer = new QuestionInfo
            {
              Title = "Final answer",
              Question = "Android is right for you!"
            },
            NoAnswer = new QuestionInfo
            {
              Title = "C++ shop",
              Question = "Are you a C or C++ dev shop?",
              YesAnswer = new QuestionInfo
              {
                Title = "Final answer",
                Question = "iOS is right for you!"
              },
              NoAnswer = new QuestionInfo
              {
                Title = "Final answer",
                Question = "You are out of the mainstream and are in for a serious challenge going forward"
              }
            }
          }
        },
        NoAnswer = new QuestionInfo
        {
          Title = "Final answer",
          Question = "Sorry, you're stuck writing and maintaining the same app at least three times (WinRT, Android, iOS)"
        }
      };

      _root = new QuestionInfo
      {
        Title = "HTML 5 vs Native",
        Question = "Do you believe HTML 5 is the future of client app dev?",
        YesAnswer = new QuestionInfo
        {
          Title = "HTML 5 Complexity",
          Question = "Can you deal with the fluid and complex nature of the HTML 5 platform?",
          YesAnswer = new QuestionInfo
          {
            Title = "HTML 5 App Perception",
            Question = "Will your users accept an HTML 5 app vs a native app?",
            YesAnswer = new QuestionInfo
            {
              Title = "Offline support",
              Question = "Does your app need to work if the device is offline?",
              YesAnswer = controlDevice,
              NoAnswer = new QuestionInfo
              {
                Title = "Final answer",
                Question = "HTML 5 is right for you!"
              }
            },
            NoAnswer = controlDevice
          },
          NoAnswer = controlDevice
        },
        NoAnswer = controlDevice
      };
    }

    /// <summary>
    /// Preserves state associated with this page in case the application is suspended or the
    /// page is discarded from the navigation cache.  Values must conform to the serialization
    /// requirements of <see cref="SuspensionManager.SessionState"/>.
    /// </summary>
    /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    protected override void SaveState(Dictionary<String, Object> pageState)
    {
    }

    private void ShowNextQuestion(QuestionInfo q)
    {
      Frame rootFrame = Window.Current.Content as Frame;
      if (rootFrame != null)
      {
        rootFrame.Navigate(typeof(StartPage), q);
      }
    }

    private void AnswerNo(object sender, RoutedEventArgs e)
    {
      ShowNextQuestion(_root.NoAnswer);
    }

    private void AnswerYes(object sender, RoutedEventArgs e)
    {
      ShowNextQuestion(_root.YesAnswer);
    }
  }
}
