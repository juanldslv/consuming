using Foundation;
using System;
using UIKit;

namespace ejemplo
{
    public partial class BookCell : UITableViewCell
    {
        public BookCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(BookElement book)
        {

            bookTitleLabel.Text = book.Title;
            bookSubtitleLabel.Text = book.Subtitle;
            bookPriceLabel.Text = book.Price;

            bookImageView.Image = FromUrl(book.Image.ToString());






        }
        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);

        }

    }
}