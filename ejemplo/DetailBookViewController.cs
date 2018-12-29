using Foundation;
using System;
using UIKit;

namespace ejemplo
{
    public partial class DetailBookViewController : UIViewController
    {

        public string ISB;
        public DetailBookViewModel viewModelDetail => Application.Locator.DetailBookViewModel;
        BookDetail bookDetail;
        
        public DetailBookViewController(IntPtr handle) : base(handle)
        {

             
        }




        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

           

        }
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            titleDetailView.Text = string.Empty;
            subtitleBookDetailView.Text = string.Empty;

            descriptionDetailBookView.Text = string.Empty;
            authorsDetailBookView.Text = string.Empty;
            publisherDetailBookView.Text = string.Empty;
            pagesDetailBookView.Text = string.Empty;
            yearDetailBookView.Text = string.Empty;
            isbn10DetailBookView.Text = string.Empty;
            ratingDetailBookView.Text = string.Empty;
            priceDetailBookView.Text = string.Empty;
        }
        public async override void ViewWillAppear(bool animated)
        {

            base.ViewWillAppear(animated);


            ISB = viewModelDetail.ISB;
            bookDetail = await viewModelDetail.GetDetailBook(ISB);
            titleDetailView.Text = bookDetail.Title;
            subtitleBookDetailView.Text = bookDetail.Subtitle;
            bookDetailImageView.Image=FromUrl( bookDetail.Image.ToString());
            descriptionDetailBookView.Text= bookDetail.Desc;
            authorsDetailBookView.Text = bookDetail.Authors;
            publisherDetailBookView.Text = bookDetail.Publisher;
            pagesDetailBookView.Text = bookDetail.Pages;
            yearDetailBookView.Text = bookDetail.Year;
            isbn10DetailBookView.Text = bookDetail.Isbn10;
            ratingDetailBookView.Text = bookDetail.Rating;
            priceDetailBookView.Text = bookDetail.Price;




        }
        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
        }
        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);

        }
    }

}