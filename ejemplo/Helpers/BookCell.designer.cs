// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ejemplo
{
    [Register ("BookCell")]
    partial class BookCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView bookImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel bookPriceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel bookSubtitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel bookTitleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bookImageView != null) {
                bookImageView.Dispose ();
                bookImageView = null;
            }

            if (bookPriceLabel != null) {
                bookPriceLabel.Dispose ();
                bookPriceLabel = null;
            }

            if (bookSubtitleLabel != null) {
                bookSubtitleLabel.Dispose ();
                bookSubtitleLabel = null;
            }

            if (bookTitleLabel != null) {
                bookTitleLabel.Dispose ();
                bookTitleLabel = null;
            }
        }
    }
}