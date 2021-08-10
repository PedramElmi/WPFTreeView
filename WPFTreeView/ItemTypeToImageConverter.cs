using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFTreeView
{
    /// <summary>
    /// Converts full path to a specific image type of a drive, folder or file
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class ItemTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string image;
            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/drive.png";
                    break;
                case DirectoryItemType.File:
                    image = "Images/file.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/folder-closed.png";
                    break;
                default:
                    image = "Images/file.png";
                    break;
            }

            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri($"pack://application:,,,/{image}", UriKind.Absolute);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();

            return src;

            //return new BitmapImage(new Uri($"pack://application:,,,/{image}", UriKind.Relative));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
