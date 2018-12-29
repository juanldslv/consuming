using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace ejemplo
{
    internal class BookTVS : UITableViewSource
    {
        public List<BookElement> element { get; set; }



        public BookDetail bookDetail { get; set; }
        public DetailBookViewModel viewModelDetail => Application.Locator.DetailBookViewModel;

        public BookTVS()
        {
            element = new List<BookElement>();

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            var cell = (BookCell)tableView.DequeueReusableCell("book_id", indexPath);
            var book = element[indexPath.Row];
            cell.UpdateCell(book);
            return cell;

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {

            return element.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {

            viewModelDetail.ISB = element[indexPath.Row].Isbn13;
            tableView.DeselectRow(indexPath, false);

        }

    }

}
