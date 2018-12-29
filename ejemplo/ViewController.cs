using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using UIKit;
using Syncfusion.SfAutoComplete.iOS;

namespace ejemplo
{
    public partial class ViewController : UIViewController
    {


        SfAutoComplete SfAutoComplete = new SfAutoComplete();
        private string[] searchResults= new string[4];
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            

        }

       

        private BooksListViewModel viewModel => Application.Locator.BooksListMainViewModel;



        BookTVS bookTVS;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            SearchBook.SearchButtonClicked += (sender, e) =>
            {
                SearchbooK(SearchBook.Text);






            };

            SearchBook.TextChanged += (sender, e) =>
            {
                SearchbooK(SearchBook.Text);
            };









        }

      

        private async void SearchbooK(string filter)
        {
            if (!String.IsNullOrEmpty(filter))
            {

                bool number = true;
                while (number)
                {

                    ShowResultLabel.Text = "Results";
                    await viewModel.GetBook(filter);

                    BooksTableView.ReloadData();
                    number = false;


                }


            }
            else
            {
                ShowResultLabel.Text = "Top New Books";
                var element = new List<BookElement>();

                element = await viewModel.InitAsync();
                bookTVS.element = element;
                BooksTableView.Source = new BookTVS();
                BooksTableView.ReloadData();
            }

        }



        public async override  void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            searchResults[0] = "Mongodb";
            /*SfAutoComplete.DataSource = searchResults;
            SfAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;


            SfAutoComplete.Watermark= (NSString)"Enter a book name";


            SfAutoComplete.MaxDropDownHeight = 90;
            SfAutoComplete.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
            SfAutoComplete.PopUpDelay = 100;*/


            SearchBook.Text = string.Empty;
            var element = new List<BookElement>();

            element = await viewModel.InitAsync();
            bookTVS = new BookTVS();
            bookTVS.element=element;
            BooksTableView.Source = bookTVS;


            BooksTableView.RowHeight = UITableView.AutomaticDimension;
            BooksTableView.EstimatedRowHeight = 40f;
            BooksTableView.ReloadData();



            ///this.Add(SfAutoComplete);
        }
      

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.



        }
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {


            base.PrepareForSegue(segue, sender);


            
        }
        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
        }

    }
}
