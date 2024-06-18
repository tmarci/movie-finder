using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MovieFinder.Converters
{
    class ScoreToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var averageScore = (float)value;
            if (averageScore == 0)
            {
                return new SolidColorBrush(Colors.Black);
            }

            if (averageScore >= 8.0f)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else if (averageScore >= 6.0f)
            {
                return new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                return new SolidColorBrush(Colors.Red);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
